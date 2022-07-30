namespace BrainCrushersTests;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

public class Tester
{
    public static Action? TimeoutCheckAction { get; set; }

    public async IAsyncEnumerable<string> TestAsync()
    {
        foreach (var text in new string[] { "foo;bar;baz", "foo bar", "", "foo;;barbaz;", ";;" })
        {
            yield return $"\"{text}\" =>";
            await Task.Yield();

            string[] result;
            try
            {
                BrainCrushers.Exercise exercise = new();
                result = exercise.Split(text);
            }
            catch (Exception e)
            {
                throw new ApplicationException("Error while running test", e);
            }

            bool success = result?.SequenceEqual(text.Split(';')) ?? false;
            yield return $" {(result is null ? "null" : "[" + string.Join(", ", result.Select(t => t is null ? "null" : @"""" + t + @"""")) + "]")} {(success ? '✓' : '✗')}{Environment.NewLine}";
            if (!success)
            {
                throw new ApplicationException("Invalid test result");
            }
        }
    }
}