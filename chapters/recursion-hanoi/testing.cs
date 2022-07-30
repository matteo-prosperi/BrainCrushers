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
        for (int n = 3; n <= 8; n++)
        {
            yield return $"{n}|0|0 =>";
            await Task.Yield();

            BrainCrushers.Exercise.Hanoi result;
            try
            {
                BrainCrushers.Exercise exercise = new();
                result = exercise.Solve(n);
            }
            catch (Exception e)
            {
                throw new ApplicationException("Error while running test", e);
            }

            bool success = result.Count(0) == 0 && result.Count(1) == 0 && result.Count(2) == n;
            yield return $" {result.Count(0)}|{result.Count(1)}|{result.Count(2)} {(success ? '✓' : '✗')}{Environment.NewLine}";
            if (!success)
            {
                throw new ApplicationException("Invalid test result");
            }
        }
    }
}