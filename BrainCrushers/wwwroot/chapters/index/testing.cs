namespace BrainCrushers;

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

public partial class SortAlgorithms
{
    public async IAsyncEnumerable<string> TestAsync()
    {
        Random random = new();
        foreach (int size in new int[] { 0, 1, 2, 5, 10 })
        {
            int[] data = new int[size];
            for (int i = 0; i < size; i++)
            {
                data[i] = random.Next(1000);
            }

            int[] sorted = (int[])data.Clone();
            Array.Sort(sorted);

            yield return $"[{string.Join(", ", data)}] => ...";
            await Task.Yield();

            try
            {
                Sort(data);
            }
            catch (Exception e)
            {
                throw new ApplicationException("Error while running test", e);
            }

            bool success = data.SequenceEqual(sorted);
            yield return $" [{string.Join(", ", data)}] {(success ? '✓' : '✗')}{Environment.NewLine}";
            if (!success)
            {
                throw new ApplicationException("Invalid test result");
            }
        }
    }

    public Task<KeyValuePair<int, TimeSpan>> BenchmarkAsync(int? problemSize)
    {
        if (problemSize is null)
        {
            problemSize = 10;
        }

        Random random = new();
        int[] data = new int[problemSize.Value];
        for (int i = 0; i < problemSize; i++)
        {
            data[i] = random.Next(1000);
        }

        int[] sorted = (int[])data.Clone();
        Array.Sort(sorted);

        TimeSpan time;
        try
        {
            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();
            Sort(data);
            stopwatch.Stop();
            time = stopwatch.Elapsed;
        }
        catch (Exception e)
        {
            throw new ApplicationException("Error while running test", e);
        }

        if (data.SequenceEqual(sorted))
        {
            return Task.FromResult(KeyValuePair.Create(problemSize.Value, time));
        }
        else
        {
            throw new ApplicationException("Invalid test result");
        }
    }
}