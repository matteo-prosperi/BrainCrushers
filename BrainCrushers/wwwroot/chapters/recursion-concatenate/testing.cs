namespace BrainCrushersTests;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class Tester
{
    public static Action? TimeoutCheckAction { get; set; }

    public async IAsyncEnumerable<string> TestAsync()
    {
        foreach (var data in new BrainCrushers.Exercise.TextSpan[]
            {
                new("Foo"),
                new(new("I"), new(" "), new("💗"), new(" "), new("BrainCrushers")),
                new(new("I"), new(new("💗"), new("Brain"), new("Crushers")), new("!")),
                new()
            })
        {
            StringBuilder log = new();
            Print(data, log);
            yield return $"{log.ToString()} =>";
            await Task.Yield();

            string result;
            try
            {
                BrainCrushers.Exercise exercise = new();
                StringBuilder stringBuilder = new();
                exercise.Concatenate(data, stringBuilder);
                result = stringBuilder.ToString();
            }
            catch (Exception e)
            {
                throw new ApplicationException("Error while running test", e);
            }

            StringBuilder expected = new();
            Concatenate(data, expected);
            bool success = result.ToString() == expected.ToString();
            yield return $" \"{result}\" {(success ? '✓' : '✗')}{Environment.NewLine}";
            if (!success)
            {
                throw new ApplicationException("Invalid test result");
            }
        }
    }

    private void Concatenate(BrainCrushers.Exercise.TextSpan span, StringBuilder s)
    {
        if (span.Text is not null)
        {
            s.Append(span.Text);
        }
        else
        {
            foreach (var child in span.Spans)
            {
                Concatenate(child, s);
            }
        }
    }

    private void Print(BrainCrushers.Exercise.TextSpan span, StringBuilder s)
    {
        if (span.Text is not null)
        {
            s.Append("\"");
            s.Append(span.Text);
            s.Append("\"");
        }
        else
        {
            s.Append('[');
            bool first = true;
            foreach (var child in span.Spans)
            {
                if (first)
                    first = false;
                else
                    s.Append(", ");
                Print(child, s);
            }
            s.Append("]");
        }
    }
}