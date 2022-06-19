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
        foreach (var data in new (int[] Data, int Positions)[]
            {
                (new int[] { 1, 2, 3, 4, 5 }, 2),
                (new int[] { 1, 3, 4, 2, 5 }, 0),
                (new int[] { 2, 1, 4, 3, 5 }, 5),
                (new int[] { 2, 3, 5, 9, 1, 4 }, 8),
                (new int[] { 2, 1, 3, 4, 5 }, -2),
                (new int[] { 1, 2, 4, 5 }, -4),
                (new int[] { 3, 4, 2, 1, 5 }, -7),
                (new int[] {}, 0),
                (new int[] {}, 1),
            })
        {
            yield return $"([{string.Join(", ", data.Data)}], {data.Positions}) =>";
            await Task.Yield();

            var result = (int[])data.Data.Clone();
            try
            {
                BrainCrushers.Exercise exercise = new();
                exercise.Rotate(result, data.Positions);
            }
            catch (Exception e)
            {
                throw new ApplicationException("Error while running test", e);
            }

            int normalizedRotation = data.Data.Length > 0
                ? data.Positions >= 0 ? data.Positions % data.Data.Length : data.Data.Length - (-data.Positions % data.Data.Length)
                : 0;
            bool success = result.SequenceEqual(Enumerable.Concat(data.Data.Skip(normalizedRotation), data.Data.Take(normalizedRotation)));
            yield return $" [{string.Join(", ", result)}] {(success ? '✓' : '✗')}{Environment.NewLine}";
            if (!success)
            {
                throw new ApplicationException("Invalid test result");
            }
        }
    }
}