namespace BrainCrushersTests;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

public class Tester
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
                BrainCrushers.SortAlgorithms toBeTested = new();
                toBeTested.Sort(data);
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
}