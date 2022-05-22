using BlazorMonaco;
using System.Collections.ObjectModel;
using System.Text.RegularExpressions;

namespace BrainCrushers;

public class CodeFile
{
    private static readonly Regex RegionsRegex = new Regex(@"^(\s*#region(\s.*))|(\s*#endregion(?:\s.*)?)$", RegexOptions.Compiled | RegexOptions.Multiline);

	public ReadOnlyCollection<Region> Regions { get; private set; }

	public CodeFile(string code)
    {
		List<Region> regions = new();

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
					regions.Add(new Region(name: null, code.Substring(regionEnd, startRegionCapture.Index - regionEnd)));
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
					regions.Add(new Region(regionName, code.Substring(regionStart.Value, endRegionCapture.Index - regionStart.Value).TrimStart('\r', '\n')));
					regionStart = null;
					regionEnd = endRegionCapture.Index + endRegionCapture.Length;
				}
			}
		}

		if (regionEnd < code.Length)
        {
			regions.Add(new Region(name: null, code.Substring(regionEnd)));
		}

		Regions = regions.AsReadOnly();
	}

	public record Region
	{
		public Region(string? name, string code)
		{
			Name = name;
			OriginalCode = code;

			LineCount = OriginalCode.Where(c => c == '\n').Count() + 1;
		}

		public string? Name { get; private set; }

		private MonacoEditor? editor;
		public MonacoEditor? Editor
		{
			get => editor;
			set
            {
				if (editor is not null)
                {
					throw new InvalidOperationException("The editor for a region can only be set once.");
                }
				editor = value;
            }
        }

		public string OriginalCode { get; private set; }

		public int LineCount { get; set; }

		public async Task<string> GetCurrentCodeAsync() => Editor is null ? OriginalCode : await Editor.GetValue();

		public void OnEditorCodeChange(ModelContentChangedEvent modelContentChangedEvent)
		{
			foreach (var change in modelContentChangedEvent.Changes)
			{
				LineCount += change.Range.StartLineNumber - change.Range.EndLineNumber + change.Text.Where(c => c == '\n').Count();
			}
		}
	}
}
