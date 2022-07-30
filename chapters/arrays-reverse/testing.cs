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
        foreach (var data in new int[][]
            {
                new int[] { 4, 5, 7, 2 },
                new int[] { 1, 2, 3 },
                new int[] { -1 },
                new int[] { },
            })
        {
            yield return $"{PrintArray(data)} =>";
            await Task.Yield();

            var result = (int[])data.Clone();
            try
            {
                BrainCrushers.Exercise exercise = new();
                exercise.Reverse(result);
            }
            catch (Exception e)
            {
                throw new ApplicationException("Error while running test", e);
            }

            bool success = result.SequenceEqual(data.Reverse());
            yield return $" {PrintArray(result)} {(success ? '✓' : '✗')}{Environment.NewLine}";
            if (!success)
            {
                throw new ApplicationException("Invalid test result");
            }
        }
    }

    protected static string PrintArray(int[] data)
        => "[" + string.Join(", ", data) + "]";
}