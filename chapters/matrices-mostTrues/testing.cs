namespace BrainCrushersTests;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class Tester
{
    public static Action? TimeoutCheckAction { get; set; }

    public async IAsyncEnumerable<string> TestAsync()
    {
        foreach (var data in new bool[][,] {
                new bool[,] { { true,  true,  false, false },
                              { true,  false, false, false },
                              { true,  true,  true,  true  },
                              { false, false, false, false },
                              { true,  true,  true,  true  } },
                new bool[,] { { true } },
                new bool[,] { { false } },
                new bool[,] { { false, false } },
                new bool[,] { { true, true } },
                new bool[,] { { true  },
                              { true },
                              { false },
                              { true } },
                new bool[,] { { true,  true,  false, false, false },
                              { true,  false, false, false, false },
                              { false, false, false, false, false },
                              { true,  true,  true,  true,  false  },
                              { true,  true,  true,  false, false  } } })
        {
            yield return $"{Print(data)}{Environment.NewLine}⇓{Environment.NewLine}";
            await Task.Yield();

            int result;
            try
            {
                BrainCrushers.Exercise exercise = new();
                result = exercise.FirstMostTrue(data);
            }
            catch (Exception e)
            {
                throw new ApplicationException("Error while running test", e);
            }

            int expectedResult = CountFalse(data).Select((c, y) => new { Row = y, Count = c }).OrderBy(r => r.Count * data.GetLength(0) + r.Row).First().Row;
            bool success = result == expectedResult;
            yield return $"{result} {(success ? '✓' : '✗')}{Environment.NewLine}{Environment.NewLine}";
            if (!success)
            {
                throw new ApplicationException("Invalid test result");
            }
        }
    }

    private static int CountFalse(bool[,] data, int y)
    {
        int count = 0;
        for (int x = data.GetLength(1) - 1; x >= 0; x--)
        {
            if (data[y, x])
                break;
            else
                count++;
        }

        return count;
    }

    private static IEnumerable<int> CountFalse(bool[,] data)
    {
        for (int y = 0; y < data.GetLength(0); y++)
        {
            yield return CountFalse(data, y);
        }
    }

    private static string Print(bool[,] data)
    {
        StringBuilder result = new();
        for (int y = 0; y < data.GetLength(0); y++)
        {
            result.Append("[");
            for (int x = 0; x < data.GetLength(1); x++)
            {
                if (x != 0)
                    result.Append(' ');
                result.Append(data[y, x] ? "true " : "false");
            }
            result.Append("]");
            if (y < data.GetLength(0) - 1)
                result.AppendLine();
        }

        return result.ToString();
    }
}