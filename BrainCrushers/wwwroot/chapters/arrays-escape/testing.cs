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
        foreach (var data in new (char[] Text, int Len)[]
            {
                (new char[] { 'f', 'o', 'o', '\\', 'b', 'a', 'r', '_' }, 7 ),
                (new char[] { '\"', 'f', 'o', 'o', '\"', '_', '_' }, 5 ),
                (new char[] { '_', '_' }, 0 ),
                (new char[] {  }, 0 ),
                (new char[] { '\"', '\\', '\"', '_', '_', '_' }, 3 ),
            })
        {
            yield return $"({PrintArray(data.Text)}, {data.Len}) =>";
            await Task.Yield();

            var resultText = (char[])data.Text.Clone();
            int resultLen;
            try
            {
                BrainCrushers.Exercise exercise = new();
                resultLen = exercise.Escape(resultText, data.Len);
            }
            catch (Exception e)
            {
                throw new ApplicationException("Error while running test", e);
            }

            bool success = Escape().SequenceEqual(resultText.Take(resultLen));
            yield return $" {resultLen}, text={PrintArray(resultText)} {(success ? '✓' : '✗')}{Environment.NewLine}";
            if (!success)
            {
                throw new ApplicationException("Invalid test result");
            }

            IEnumerable<char> Escape()
            {
                foreach (var c in data.Text.Take(data.Len))
                {
                    if (c == '\\' || c == '\"')
                    {
                        yield return '\\';

                    }
                    yield return c;
                }
            }
        }
    }

    protected static string PrintArray(char[] data)
        => "[" + string.Join(", ", data) + "]";
}