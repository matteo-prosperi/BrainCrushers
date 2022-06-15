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
        foreach (double[] data in new double[][]
            {
                new double[] { 0, 1, 5, 7, 3, 4, 5, 5, 6 },
                new double[] { 0, 1, 5, 7, -6, -4, -3, -2, 1, -2 },
                new double[] { 0, 1, 25, 0, 1 },
                new double[] { 7.3, 3.2, 5.4 },
                new double[] { 8 },
                new double[] { },
            })
        {
            yield return $"{PrintArray(data)} =>";
            await Task.Yield();

            double? result;
            try
            {
                BrainCrushers.Exercise exercise = new();
                result = exercise.FindMaxAverageOfIncreasingSequence(data);
            }
            catch (Exception e)
            {
                throw new ApplicationException("Error while running test", e);
            }

            bool success = result == (data.Length == 0 ? null : IncreasingSequenceAverages().Max());
            yield return $" {result} {(success ? '✓' : '✗')}{Environment.NewLine}";
            if (!success)
            {
                throw new ApplicationException("Invalid test result");
            }  

            IEnumerable<double> IncreasingSequenceAverages()
            {
                double sum = data[0];
                int len = 1;
                for (int i = 1; i < data.Length; i++)
                {
                    if (data[i].CompareTo(data[i - 1]) <= 0)
                    {
                        yield return sum / len;
                        sum = data[i];
                        len = 1;
                    }
                    else
                    {
                        sum += data[i];
                        len++;
                    }
                }
                yield return sum / len;
            }
        }
    }

    protected static string PrintArray(double[] data)
        => "[" + string.Join(", ", data) + "]";
}