#region Using statements
using System;
using System.Text;
#endregion

namespace BrainCrushers;

#region Intro
public class Exercise
{
    public void Concatenate(TextSpan span, StringBuilder stringBuilder)
	{
#endregion
#region Solution

#endregion
#region Outro
    }

    public class TextSpan
    {
        public readonly string? Text;
        public readonly TextSpan[]? Spans;

        public TextSpan(string text)
        {
            Text = text ?? throw new ArgumentNullException(nameof(text));
        }

        public TextSpan(params TextSpan[] spans)
        {
            Spans = spans ?? throw new ArgumentNullException(nameof(spans));
        }

        public static implicit operator TextSpan(string text)
        {
            return new TextSpan(text);
        }
    }
}
#endregion
