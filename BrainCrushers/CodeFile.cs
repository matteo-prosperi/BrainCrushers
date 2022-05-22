using Blazored.LocalStorage;
using BlazorMonaco;
using System.Collections.ObjectModel;
using System.Security.Cryptography;
using System.Text;
using System.Text.RegularExpressions;

namespace BrainCrushers;

public class CodeFile
{
    private static readonly Regex RegionsRegex = new Regex(@"^(\s*#region(\s.*))|(\s*#endregion(?:\s.*)?)$", RegexOptions.Compiled | RegexOptions.Multiline);

	private readonly ISyncLocalStorageService LocalStorage;
	private readonly string Chapter;
	private readonly string OriginalCodeHash;

	private Task? DelayedSave;

	private string LocalStorageSaveKey => $"SAVE-{Chapter}";

	public ReadOnlyCollection<Region> Regions { get; private set; }

	public CodeFile(string code, string chapter, ISyncLocalStorageService localStorage)
    {
		LocalStorage = localStorage;
		Chapter = chapter;

        {
			var hashGenerator = SHA256.Create();
			var codeBytes = Encoding.UTF8.GetBytes(code);
			OriginalCodeHash = Convert.ToBase64String(hashGenerator.ComputeHash(codeBytes, 0, codeBytes.Length));
		}

		ChapterLocalSave? localSave = LocalStorage.GetItem<ChapterLocalSave>(LocalStorageSaveKey);
		if (localSave is not null && localSave.Hash != OriginalCodeHash)
        {
			LocalStorage.RemoveItem(LocalStorageSaveKey);
		}

		List <Region> regions = new();

		var regionsMatches = RegionsRegex.Matches(code);
		int? regionStart = null;
		string? regionName = null;
		int regionEnd = 0;
		int nestedRegionCount = 0;
		foreach (Match match in regionsMatches)
		{
			Group startRegionGroup = match.Groups[1];
			Group regionNameGroup = match.Groups[2];
			Group endRegionGroup = match.Groups[3];
			if (startRegionGroup.Captures.Count > 0) // Start of region
			{
				if (regionStart is null)
				{
					regionName = regionNameGroup.Captures.SingleOrDefault()?.Value.Trim();
					Capture startRegionCapture = startRegionGroup.Captures.Single();
					regionStart = startRegionCapture.Index + startRegionCapture.Length;
					string regionCode = code.Substring(regionEnd, startRegionCapture.Index - regionEnd).TrimStart('\r', '\n');
					regions.Add(new Region(name: null, regionCode, localSave?.GetRegionBackup(regions.Count), this));
				}
				else // Region is nested
				{
					nestedRegionCount++;
				}
			}
			else if (endRegionGroup.Captures.Count > 0 && regionStart is not null) // End of region
			{
				if (nestedRegionCount > 0)
				{
					nestedRegionCount--;
				}
				else
				{
					Capture endRegionCapture = endRegionGroup.Captures.Single();
					string regionCode = code.Substring(regionStart.Value, endRegionCapture.Index - regionStart.Value).TrimStart('\r', '\n');
					regions.Add(new Region(regionName, regionCode, localSave?.GetRegionBackup(regions.Count), this));
					regionStart = null;
					regionEnd = endRegionCapture.Index + endRegionCapture.Length;
				}
			}
		}

		if (regionEnd < code.Length)
        {
			string regionCode = code.Substring(regionEnd).TrimStart('\r', '\n');
			regions.Add(new Region(name: null, regionCode, localSave?.GetRegionBackup(regions.Count), this));
		}

		Regions = regions.AsReadOnly();
	}

	private void CodeHasChanged()
    {
		if (DelayedSave is null)
        {
			DelayedSave = Task.Run(async () =>
			{
				await Task.Delay(TimeSpan.FromSeconds(5));
				var data = new string[Regions.Count];
				for (int i = 0; i < data.Length; i++)
                {
					if (Regions[i].IsModifiable)
                    {
						data[i] = await Regions[i].GetCurrentCodeAsync();
					}
				}
				ChapterLocalSave save = new ChapterLocalSave(OriginalCodeHash)
				{
					CodeBackup = data,
				};

				LocalStorage.SetItem(LocalStorageSaveKey, save);
				DelayedSave = null;
			});
		}
    }

	public record Region
	{
		private readonly CodeFile CodeFile;
		private readonly string OriginalCode;
		private readonly string? SavedCode;

		public Region(string? name, string code, string? savedCode, CodeFile codeFile)
		{
			Name = name;
			OriginalCode = code;
			CodeFile = codeFile;
			SavedCode = savedCode;

			LineCount = Code.Where(c => c == '\n').Count() + 1;
		}

		public string? Name { get; private set; }

		private MonacoEditor? _editor;
		public MonacoEditor? Editor
		{
			get => _editor;
			set
            {
				if (_editor is not null)
                {
					throw new InvalidOperationException("The editor for a region can only be set once.");
                }
				_editor = value;
            }
        }

		public bool IsModifiable { get; set; }

		public string Code => SavedCode ?? OriginalCode;

		public int LineCount { get; private set; }

		public async Task<string> GetCurrentCodeAsync() => Editor is null ? SavedCode ?? OriginalCode : await Editor.GetValue();

		public void OnEditorCodeChange(ModelContentChangedEvent modelContentChangedEvent)
		{
			foreach (var change in modelContentChangedEvent.Changes)
			{
				LineCount += change.Range.StartLineNumber - change.Range.EndLineNumber + change.Text.Where(c => c == '\n').Count();
			}
			CodeFile.CodeHasChanged();
		}

		public async Task ResetCode()
        {
			if (SavedCode is not null && Editor is not null)
            {
				await Editor.SetValue(OriginalCode);
            }
        }
	}

	public class ChapterLocalSave
    {
		public ChapterLocalSave(string hash)
        {
            Hash = hash;
        }

        public string Hash { get; set; }
	
		public string?[] CodeBackup { get; set; }

		public string? GetRegionBackup(int index)
        {
			if (CodeBackup.Length > index)
            {
				return CodeBackup[index];
            }
			return null;
        }
	}
}
