namespace BrainCrushersTests;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class TesterAddition : Tester
{
    public IAsyncEnumerable<string> TestAsync()
    {
        return RunAsync(
            new BrainCrushers.Matrix(
                0, 1, 2,
                3, 4, 5,
                6, 7, 8),
            new BrainCrushers.Matrix(
                3, 2, 5,
                1, 2, 2,
                1, 2, 0),
            new BrainCrushers.Matrix(
                3, 3, 7,
                4, 6, 7,
                7, 9, 8),
            '+', (a, b) => a + b);
    }
}

public class TesterSubtraction : Tester
{
    public IAsyncEnumerable<string> TestAsync()
    {
        return RunAsync(
            new BrainCrushers.Matrix(
                3, 3, 7,
                4, 6, 7,
                7, 9, 8),
            new BrainCrushers.Matrix(
                0, 1, 2,
                3, 4, 5,
                6, 7, 8),
            new BrainCrushers.Matrix(
                3, 2, 5,
                1, 2, 2,
                1, 2, 0),
            '-', (a, b) => a - b);
    }
}

public class TesterMultiplication : Tester
{
    public IAsyncEnumerable<string> TestAsync()
    {
        return RunAsync(
            new BrainCrushers.Matrix(
                1, 2, 4,
                0, 2, 0,
                0, 0, 3),
            new BrainCrushers.Matrix(
                4, 0, 0,
                0, 2, 2,
                1, 0, 1),
            new BrainCrushers.Matrix(
                8, 4, 8,
                0, 4, 4,
                3, 0, 3),
            '*', (a, b) => a * b);
    }
}

public class TesterVectorMultiplication : Tester
{
    public async IAsyncEnumerable<string> TestAsync()
    {
        BrainCrushers.Matrix a = new(
            1, 2, 4,
            0, 2, 0,
            0, 0, 3);

        double[] b = new double[] { 2, 0, 1 };
        double[] expectedResult = new double[] { 6, 0, 3 };


        yield return $"{Print(a, b, '*')}{Environment.NewLine} ⇓⇓⇓{Environment.NewLine}";
        await Task.Yield();

        double[] result;
        try
        {
            result = a * b;
        }
        catch (Exception e)
        {
            throw new ApplicationException("Error while running test", e);
        }

        bool success = result?.SequenceEqual(expectedResult) ?? false;
        yield return $"{Print(result)} {(success ? '✓' : '✗')}{Environment.NewLine}{Environment.NewLine}";
        if (!success)
        {
            throw new ApplicationException("Invalid test result");
        }
    }
}

public abstract class Tester
{
    public static Action? TimeoutCheckAction { get; set; }

    protected async IAsyncEnumerable<string> RunAsync(BrainCrushers.Matrix a, BrainCrushers.Matrix b, BrainCrushers.Matrix expectedResult, char op, Func<BrainCrushers.Matrix, BrainCrushers.Matrix, BrainCrushers.Matrix> callback)
    {
        yield return $"{Print(a, b, op)}{Environment.NewLine} ⇓⇓⇓{Environment.NewLine}";
        await Task.Yield();

        BrainCrushers.Matrix result;
        try
        {
            result = callback(a, b);
        }
        catch (Exception e)
        {
            throw new ApplicationException("Error while running test", e);
        }

        bool success = expectedResult == result;
        yield return $"{Print(result)} {(success ? '✓' : '✗')}{Environment.NewLine}{Environment.NewLine}";
        if (!success)
        {
            throw new ApplicationException("Invalid test result");
        }
    }

    protected static string Print(BrainCrushers.Matrix? a)
    {
        if (a is null)
            return "null";

        StringBuilder result = new();
        for (int y = 0; y < 3; y++)
        {
            result.Append("[");
            for (int x = 0; x < 3; x++)
            {
                if (x != 0)
                    result.Append(' ');
                result.Append(a[y, x]);
            }
            result.Append("]");
            if (y <= 1)
                result.AppendLine();
        }

        return result.ToString();
    }

    protected static string Print(BrainCrushers.Matrix a, BrainCrushers.Matrix b, char op)
    {
        StringBuilder result = new();
        for (int y = 0; y < 3; y++)
        {
            result.Append("[");
            for (int x = 0; x < 3; x++)
            {
                if (x != 0)
                    result.Append(' ');
                result.Append(a[y, x]);
            }
            result.Append(y switch
            {
                1 => $"] {op} [",
                _ => "]   [",
            });
            for (int x = 0; x < 3; x++)
            {
                if (x != 0)
                    result.Append(' ');
                result.Append(b[y, x]);
            }
            result.Append("]");
            if (y <= 1)
                result.AppendLine();
        }

        return result.ToString();
    }

    protected static string Print(BrainCrushers.Matrix a, double[] b, char op)
    {
        StringBuilder result = new();
        for (int y = 0; y < 3; y++)
        {
            result.Append("[");
            for (int x = 0; x < 3; x++)
            {
                if (x != 0)
                    result.Append(' ');
                result.Append(a[y, x]);
            }
            result.Append(y switch
            {
                0 => $"]   [{b[y]}]{Environment.NewLine}",
                1 => $"] {op} [{b[y]}]{Environment.NewLine}",
                _ => $"]   [{b[y]}]",
            });
        }

        return result.ToString();
    }

    protected static string Print(double[] b) => $"[{b[0]}]{Environment.NewLine}[{b[1]}]{Environment.NewLine}[{b[2]}]";
}