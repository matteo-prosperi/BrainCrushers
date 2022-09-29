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
        foreach (var data in new (int[] A, int[] B)[]
            {
                (new int[] { 1, 4, 5, 7 }, new int[] { 2, 3, 5, 6 }),
                (new int[] { 1, 4, 5, 7 }, new int[] { 1, 4, 5, 7 }),
                (new int[] { -13 }, new int[] { -2, 9, 12 }),
                (new int[] { }, new int[] { }),
                (new int[] { }, new int[] { 2, 4 }),
                (new int[] { 3 }, new int[] { }),
            })
        {
            yield return $"({PrintArray(data.A)}, {PrintArray(data.B)}) =>";
            await Task.Yield();

            int[]? result;
            try
            {
                BrainCrushers.Exercise exercise = new();
                result = exercise.Merge(data.A, data.B);
            }
            catch (Exception e)
            {
                throw new ApplicationException("Error while running test", e);
            }

            bool success = result?.SequenceEqual(data.A.Concat(data.B).OrderBy(x => x)) ?? false;
            yield return $" {PrintArray(result)} {(success ? '✓' : '✗')}{Environment.NewLine}";
            if (!success)
            {
                throw new ApplicationException("Invalid test result");
            }
        }
    }

    protected static string PrintArray(int[]? data)
        => data is null ? "null" : "[" + string.Join(", ", data) + "]";
}