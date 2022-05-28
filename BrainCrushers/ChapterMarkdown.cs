using BlazorMonaco;
using System.Collections.ObjectModel;
using System.Text.RegularExpressions;

namespace BrainCrushers;

public class ChapterMarkdown
{
	public static readonly Regex NewLineRegex = new Regex(@"(?:\n\r)|(?:\r\n)|\n|\r", RegexOptions.Compiled);
	private static readonly Regex MarkdownRegex = new Regex(@"\[\]\((?:(?:EDITABLE\s+(.*?))|(?:READONLY\s+(.*?))|(?:RUN\s+(.*?)))\)", RegexOptions.Compiled | RegexOptions.Singleline);

	public ReadOnlyCollection<object> Sections { get; private set; }

	private readonly CodeFile? _code;
	public CodeFile Code => _code ?? throw new InvalidOperationException("The code for this chapter is unavailable");

	public ChapterMarkdown(string markdown, CodeFile? code)
    {
		markdown = NewLineRegex.Replace(markdown, "\r\n");
		_code = code;

		List<object> sections = new List<object>();

		var markdownMatches = MarkdownRegex.Matches(markdown);
		int end = 0;
		foreach (Match match in markdownMatches)
		{
			Capture wholeCapture = match.Groups[0].Captures.Single();
			Capture? editableCapture = match.Groups[1].Captures.SingleOrDefault();
			Capture? readonlyCapture = match.Groups[2].Captures.SingleOrDefault();
			Capture? runCapture = match.Groups[3].Captures.SingleOrDefault();

			string? regionName = (editableCapture?.Value ?? readonlyCapture?.Value)?.Trim();
			string? runName = runCapture?.Value.Trim();

			sections.Add(new Html(markdown.Substring(end, wholeCapture.Index - end)));
			if (regionName is not null)
            {
				CodeFile.Region? region = Code.Regions.Where(r => r.Name == regionName).FirstOrDefault();
				if (region is not null)
				{
					sections.Add(new CodeRegion(region, isReadonly : readonlyCapture is not null));
				}
			}
			else
            {
				sections.Add(new RunCommand(runName!));
			}
			end = wholeCapture.Index + wholeCapture.Length;
		}

		if (end < markdown.Length)
		{
			sections.Add(new Html(markdown.Substring(end)));
		}

		Sections = sections.AsReadOnly();
    }

    public class Html
    {
		public string Value { get; private set; }

		public Html(string markdown)
        {
			Value = Markdig.Markdown.ToHtml(markdown);
		}
	}

	public class CodeRegion
	{
		public CodeFile.Region Region { get; private set; }
		public bool IsReadonly { get; private set; }

		public CodeRegion(CodeFile.Region region, bool isReadonly)
		{
			Region = region;
			IsReadonly = isReadonly;

			if (isReadonly is false)
            {
				Region.IsModifiable = true;
            }
		}
	}

	public class RunCommand
    {
		public string TypeName { get; private set; }

		public string Result { get; private set; } = String.Empty;

		public int LineCount { get; private set; } = 1;

		public MonacoEditor? Editor { get; set; }

		public bool? Success { get; private set; }

		public RunCommand(string typeName)
		{
			TypeName = typeName;
		}

		public async Task SetResultAsync(string? result, bool? success)
        {
			Success = success;
			if (result is not null)
            {
				Result = result;
				LineCount = result.Where(c => c == '\n').Count() + 1;
				if (Editor is not null)
				{
					await Editor.SetValue(result);
				}
			}
		}
	}
}
