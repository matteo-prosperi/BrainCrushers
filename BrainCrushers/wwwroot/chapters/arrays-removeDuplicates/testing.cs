namespace BrainCrushersTests;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

public class Tester1 : Tester
{
    public async IAsyncEnumerable<string> TestAsync()
    {
        foreach (var data in new int[][]
            {
                new int[] { 5, 0, 1, 4, 2, 3, 6 },
                new int[] { 2, 6, 1, 1, 2, 7, 1, 6, 2, 0, 0, 9, 2 },
                new int[] { -1, -1, -1, -1 },
                new int[] { 0 },
                new int[] { },
            })
        {
            yield return $"{PrintArray(data)} =>";
            await Task.Yield();

            int[] resultData = (int[])data.Clone();
            int resultLen;
            try
            {
                BrainCrushers.Exercise exercise = new();
                resultLen = exercise.RemoveDuplicates(resultData);
            }
            catch (Exception e)
            {
                throw new ApplicationException("Error while running test", e);
            }

            var distinct = data.Distinct().ToArray();
            bool success = resultLen == distinct.Length &&
                           resultData.Skip(resultLen).All(n => n == 0) &&
                           resultData.Take(resultLen).OrderBy(n => n).SequenceEqual(distinct.OrderBy(n => n));
            yield return $" {resultLen}, data={PrintArray(resultData)} {(success ? '✓' : '✗')}{Environment.NewLine}";
            if (!success)
            {
                throw new ApplicationException("Invalid test result");
            }
        }
    }
}

public class Tester2 : Tester
{
    public async IAsyncEnumerable<string> TestAsync()
    {
        foreach (var data in new int[][]
            {
                new int[] { 0, 1, 2, 3, 4, 5, 6 },
                new int[] { 0, 0, 1, 1, 1, 2, 2, 2, 2, 6, 6, 7, 9 },
                new int[] { -1, -1, -1, -1 },
                new int[] { 0 },
                new int[] { },
            })
        {
            yield return $"{PrintArray(data)} =>";
            await Task.Yield();

            int[] resultData = (int[])data.Clone();
            int resultLen;
            try
            {
                BrainCrushers.Exercise exercise = new();
                resultLen = exercise.RemoveDuplicates(resultData);
            }
            catch (Exception e)
            {
                throw new ApplicationException("Error while running test", e);
            }

            var distinct = data.Distinct().OrderBy(n => n).ToArray();
            bool success = resultLen == distinct.Length &&
                           resultData.Skip(resultLen).All(n => n == 0) &&
                           resultData.Take(resultLen).SequenceEqual(distinct);
            yield return $" {resultLen}, data={PrintArray(resultData)} {(success ? '✓' : '✗')}{Environment.NewLine}";
            if (!success)
            {
                throw new ApplicationException("Invalid test result");
            }
        }
    }
}

public class Tester
{
    public static Action? TimeoutCheckAction { get; set; }

    protected static string PrintArray(int[] data)
        => "[" + string.Join(", ", data) + "]";
}