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
        foreach (var data in new (BrainCrushers.Exercise.Expression Expression, double ExprectedResult)[]
            {
                (5, 5),
                (new BrainCrushers.Exercise.Addition(2, 3), 5),
                (new BrainCrushers.Exercise.Multiplication(
                    new BrainCrushers.Exercise.Subtraction(4.5, 2),
                    2), 5),
                (new BrainCrushers.Exercise.Multiplication(
                    new BrainCrushers.Exercise.Subtraction(4.5, 2.5),
                    new BrainCrushers.Exercise.Division(
                        4,
                        new BrainCrushers.Exercise.Addition(1, 1))), 4)
            })
        {
            yield return $"{data.Expression} =>";
            await Task.Yield();

            double result;
            try
            {
                BrainCrushers.Exercise exercise = new();
                result = exercise.Solve(data.Expression);
            }
            catch (Exception e)
            {
                throw new ApplicationException("Error while running test", e);
            }

            bool success = result == data.ExprectedResult;
            yield return $" {result} {(success ? '✓' : '✗')}{Environment.NewLine}";
            if (!success)
            {
                throw new ApplicationException("Invalid test result");
            }
        }
    }
}