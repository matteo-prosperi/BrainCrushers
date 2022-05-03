namespace BrainCrushers;

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

public partial class SortAlgorithms
{
    public async IAsyncEnumerable<string> RunAsync()
    {
        Random random = new();
        for (int size = 10; size < 20; size++)
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

            string? exception = null;
            TimeSpan? time = null;
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
                exception = $"{Environment.NewLine}{e}";
            }

            if (exception is not null)
            {
                yield return exception;
                yield break;
            }

            bool success = data.SequenceEqual(sorted);
            yield return $" [{string.Join(", ", data)}] {(success ? '✓' : '✗')} {time!.Value.TotalMilliseconds}ms{Environment.NewLine}";
            if (!success)
            {
                yield break;
            }
            else
            {
                await Task.Yield();
            }
        }
    }
}