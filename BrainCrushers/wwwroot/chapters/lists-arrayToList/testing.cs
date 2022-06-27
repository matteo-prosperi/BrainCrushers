namespace BrainCrushersTests;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

public class Tester1 : BaseTester
{
    protected override int[]? RunTest(BrainCrushers.Exercise exercise, int[] data)
    {
        var head = exercise.ArrayToList(data);
        return Iterate(head).ToArray();
    }
}

public class Tester2 : BaseTester
{
    protected override int[]? RunTest(BrainCrushers.Exercise exercise, int[] data)
    {
        BrainCrushers.Exercise.Node? head = null;
        ref BrainCrushers.Exercise.Node? curRef = ref head;
        foreach (int n in data)
        {
            curRef = new() { Value = n };
            curRef = ref curRef.Next;
        }

        return exercise.ListToArray(head);
    }
}

public abstract class BaseTester
{
    public static Action? TimeoutCheckAction { get; set; }

    public async IAsyncEnumerable<string> TestAsync()
    {
        foreach (var data in new int[][]
            {
                new int[] { 1, 2, 3, 4, 5 },
                new int[] { 17 },
                new int[] { }
            })
        {
            yield return $"{PrintArray(data)} =>";
            await Task.Yield();

            int[]? result;
            try
            {
                BrainCrushers.Exercise exercise = new();
                result = RunTest(exercise, data);
            }
            catch (Exception e)
            {
                throw new ApplicationException("Error while running test", e);
            }

            bool success = result?.SequenceEqual(data) ?? false;
            yield return $" {PrintArray(result)} {(success ? '✓' : '✗')}{Environment.NewLine}";
            if (!success)
            {
                throw new ApplicationException("Invalid test result");
            }
        }
    }

    protected abstract int[]? RunTest(BrainCrushers.Exercise exercise, int[] data);

    protected static string PrintArray(int[]? data)
        => data is null ? "null" : "[" + string.Join(", ", data) + "]";

    protected static IEnumerable<int> Iterate(BrainCrushers.Exercise.Node? head)
    {
        while (head is not null)
        {
            yield return head.Value;
            head = head.Next;
        }
    }
}