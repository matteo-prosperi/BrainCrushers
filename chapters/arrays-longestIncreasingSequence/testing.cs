namespace BrainCrushersTests;

using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

public class Tester
{
    public static Action? TimeoutCheckAction { get; set; }

    public async IAsyncEnumerable<string> TestAsync()
    {
        await foreach (string s in TestArrayAsync(new int[] { 0, 1, 5, 7, 3, 4, 5, 5, 6 }))
            yield return s;
        await foreach (string s in TestArrayAsync(new int[] { 0, 1, 5, 7, -6, -4, -3, -2, 1, -2 }))
            yield return s;
        await foreach (string s in TestArrayAsync(new char[] { 'a', 'b', 'z', 'a', 'b' }))
            yield return s;
        await foreach (string s in TestArrayAsync(new double[] { 7.3, 3.2, 5.4 }))
            yield return s;
        await foreach (string s in TestArrayAsync(new int[] { 8 }))
            yield return s;
        await foreach (string s in TestArrayAsync(new int[] { }))
            yield return s;
    }

    private async IAsyncEnumerable<string> TestArrayAsync<T>(T[] data)
        where T : IComparable<T>
    {
        yield return $"{PrintArray(data)} =>";
        await Task.Yield();

        (int Start, int Length) result;
        try
        {
            BrainCrushers.Exercise exercise = new();
            result = exercise.FindLongestIncreasingSequence(data);
        }
        catch (Exception e)
        {
            throw new ApplicationException("Error while running test", e);
        }

        bool success = result == IncreasingSequences().MaxBy(s => s.Length);
        yield return $" (Start={result.Start}, Length={result.Length}) {(success ? '✓' : '✗')}{Environment.NewLine}";
        if (!success)
        {
            throw new ApplicationException("Invalid test result");
        }

        IEnumerable<(int Start, int Length)> IncreasingSequences()
        {
            if (data.Length == 0)
            {
                yield return (0, 0);
                yield break;
            }

            int start = 0;
            int len = 1;
            for (int i = 1; i < data.Length; i++)
            {
                if (data[i].CompareTo(data[i - 1]) <= 0)
                {
                    yield return new(start, len);
                    start = i;
                    len = 1;
                }
                else
                {
                    len++;
                }
            }
            yield return new(start, len);
        }
    }

    protected static string PrintArray(IEnumerable data)
        => "[" + string.Join(", ", data.Cast<object>()) + "]";
}