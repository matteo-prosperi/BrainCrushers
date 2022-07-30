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
        foreach (var data in new (int[], int[])[]
            {
                (new int[] { 1, 2, 3, 3, 4, 5 }, new int[] { 0, 2, 3, 7, 8, 8 }),
                (new int[] { 1, 2, 3, 4, 5 }, new int[] { 3, 7, 7, 8 }),
                (new int[] { 1, 2, 3, 4, 5 }, new int[] { }),
                (new int[] { 1 }, new int[] { 1 }),
                (new int[] { 5, 7 }, new int[] { }),
                (new int[] { }, new int[] { 5, 7 }),
                (new int[] { }, new int[] { })
            })
        {
            yield return $"{PrintArray(data.Item1)}, {PrintArray(data.Item2)} =>";
            await Task.Yield();

            int[] result;
            try
            {
                BrainCrushers.Exercise exercise = new();
                result = Iterate(exercise.Merge(AsLinkedList(data.Item1), AsLinkedList(data.Item2))).ToArray();
            }
            catch (Exception e)
            {
                throw new ApplicationException("Error while running test", e);
            }

            bool success = result.SequenceEqual(data.Item1.Concat(data.Item2).OrderBy(x => x));
            yield return $" {PrintArray(result)} {(success ? '✓' : '✗')}{Environment.NewLine}";
            if (!success)
            {
                throw new ApplicationException("Invalid test result");
            }
        }
    }

    private static string PrintArray(int[]? data)
        => data is null ? "null" : "[" + string.Join(", ", data) + "]";

    private static IEnumerable<int> Iterate(BrainCrushers.Exercise.Node? head)
    {
        while (head is not null)
        {
            yield return head.Value;
            head = head.Next;
        }
    }

    private static BrainCrushers.Exercise.Node? AsLinkedList(int[] data)
    {
        BrainCrushers.Exercise.Node? head = null;
        ref BrainCrushers.Exercise.Node? curRef = ref head;
        foreach (int n in data)
        {
            curRef = new() { Value = n };
            curRef = ref curRef.Next;
        }

        return head;
    }
}