using System.Collections.ObjectModel;
using System.Text.RegularExpressions;

namespace BrainCrushers;

public class ChapterMarkdown
{
	private static readonly Regex MarkdownRegex = new Regex(@"\[\]\((?:(?:CODE\s+(.*?))|(?:RUN\s+(.*?)))\)", RegexOptions.Compiled | RegexOptions.Singleline);

	public ReadOnlyCollection<object> Sections { get; private set; }

	private readonly CodeFile? _code;
	public CodeFile Code => _code ?? throw new InvalidOperationException("The code for this chapter is unavailable");

	public ChapterMarkdown(string markdown, CodeFile? code)
    {
		_code = code;

		List<object> sections = new List<object>();

		var markdownMatches = MarkdownRegex.Matches(markdown);
		int end = 0;
		foreach (Match match in markdownMatches)
		{
			Capture codePointerCapture = match.Groups[0].Captures.Single();
			string? regionName = match.Groups[1].Captures.SingleOrDefault()?.Value.Trim();
			string? runName = match.Groups[2].Captures.SingleOrDefault()?.Value.Trim();

			sections.Add(new Html(markdown.Substring(end, codePointerCapture.Index - end)));
			if (regionName is not null)
            {
				CodeFile.Region? region = Code.Regions.Where(r => r.Name == regionName).FirstOrDefault();
				if (region is not null)
				{
					sections.Add(region);
				}
			}
			else
            {
				sections.Add(new RunCommand(runName!));
			}
			end = codePointerCapture.Index + codePointerCapture.Length;
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

    public class RunCommand
    {
		public string TypeName { get; private set; }

		public string Result { get; set; } = String.Empty;

		public RunCommand(string typeName)
		{
			TypeName = typeName;
		}
	}
}
