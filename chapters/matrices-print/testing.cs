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
        foreach (var data in new int[][,] {
                new int[,] { { 1, 2 },
                             { 3, 4 } },
                new int[,] { },
                new int[,] { { 3 } },
                new int[,] { { 2, 3 } },
                new int[,] { { 2 },
                             { 3 } },
                new int[,] { { 1, 2, 3 },
                             { 4, 5, 6 },
                             { 7, 8, 9 }}})
        {
            StringBuilder expectedResult = new();
            for(int y = 0; y < data.GetLength(0); y++)
            {
                if (y != 0)
                    expectedResult.AppendLine();
                for (int x = 0; x < data.GetLength(1); x++)
                {
                    if (x != 0)
                        expectedResult.Append('\t');
                    expectedResult.Append(data[y, x]);
                }
            }
            yield return $"\"{expectedResult}\"{Environment.NewLine} ⇓⇓⇓{Environment.NewLine}";
            await Task.Yield();

            string result;
            try
            {
                BrainCrushers.Exercise exercise = new();
                StringBuilder stringBuilder = new();
                result = exercise.Print(data);
            }
            catch (Exception e)
            {
                throw new ApplicationException("Error while running test", e);
            }

            bool success = result == expectedResult.ToString();
            yield return $"\"{result}\" {(success ? '✓' : '✗')}{Environment.NewLine}{Environment.NewLine}";
            if (!success)
            {
                throw new ApplicationException("Invalid test result");
            }
        }
    }
}