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
                new int[] { 4, 5, 7, 2, 6, 3, 4, 10, 9, 2, 1, 4, 5, 7, 8 },
                new int[] { 1, 2, 3 },
            })
        {
            yield return $"{PrintArray(data)} =>";
            await Task.Yield();

            double result;
            try
            {
                BrainCrushers.Exercise exercise = new();
                result = exercise.MaxMovingAverage3(data);
            }
            catch (Exception e)
            {
                throw new ApplicationException("Error while running test", e);
            }

            bool success = MovingAverage().Max() == result;
            yield return $" {result} {(success ? '✓' : '✗')}{Environment.NewLine}";
            if (!success)
            {
                throw new ApplicationException("Invalid test result");
            }

            IEnumerable<double> MovingAverage()
            {
                for (int i = 2; i < data.Length; i++)
                {
                    yield return ((double)data[i - 2] + data[i - 1] + data[i]) / 3;
                }
            }
        }
    }
}

public class Tester2 : Tester
{
    public async IAsyncEnumerable<string> TestAsync()
    {
        foreach (var data in new (int[] Array, int Len)[]
            {
                (new int[] { 4, 5, 7, 2, 6, 3, 4, 10, 9, 2, 1, 4, 5, 7, 8 }, 3),
                (new int[] { 1, 2, 3 }, 3),
                (new int[] { 4, 5, 7, 2, 6, 3, 4, 10, 9, 2, 1, 4, 5, 7, 8 }, 4),
                (new int[] { 4, 5, 7, 2, 6, 3, 4, 10, 9, 2, 1, 4, 5, 7, 8 }, 1),
                (new int[] { 1, 2, 3 }, 4),
                (new int[] { -4, -5, 7, 2, 6, 3, 6, 5, 9, 2, -1, 4, 5, 7, 8}, 3),
            })
        {
            yield return $"({PrintArray(data.Array)}, {data.Len}) =>";
            await Task.Yield();

            int? resultPos;
            double resultAvg;
            try
            {
                BrainCrushers.Exercise exercise = new();
                resultPos = exercise.MaxMovingAverage(data.Array, data.Len, out resultAvg);
            }
            catch (Exception e)
            {
                throw new ApplicationException("Error while running test", e);
            }

            var expectedMovingAvg = MovingAverage().ToArray();
            bool success;
            if (expectedMovingAvg.Length == 0)
            {
                success = resultPos == -1;
            }
            else
            {
                double maxAvg = expectedMovingAvg.Max();
                var pos = expectedMovingAvg.Select((avg, idx) => (avg, idx)).Where(x => x.avg == maxAvg).Select((_, idx) => idx).Min();
                success = resultPos == pos && resultAvg == maxAvg;
            }

            yield return (resultPos == -1 ? $" -1" : $" {resultPos}, average = {resultAvg}") + $" {(success ? '✓' : '✗')}{Environment.NewLine}";
            if (!success)
            {
                throw new ApplicationException("Invalid test result");
            }

            IEnumerable<double> MovingAverage()
            {
                for (int i = 0; i < data.Array.Length - data.Len + 1; i++)
                {
                    yield return data.Array.Skip(i).Take(data.Len).Average();
                }
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