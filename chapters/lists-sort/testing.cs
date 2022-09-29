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
        await foreach (string s in RunTestAsync(new int[] { 1, 2, 3, 4, 5 }))
            yield return s;
        await foreach (string s in RunTestAsync(new int[] { 3, 5, 4, 1, 2 }))
            yield return s;
        await foreach (string s in RunTestAsync(new char[] { 'b', 'a', 'c' }))
            yield return s;
        await foreach (string s in RunTestAsync(new int[] { 1 }))
            yield return s;
        await foreach (string s in RunTestAsync(new int[] { }))
            yield return s;
        await foreach (string s in RunTestAsync(new string[] { "foo", "bar", "baz" }))
            yield return s;

        async IAsyncEnumerable<string> RunTestAsync<T>(T[] data)
            where T : IComparable<T>
        {
            yield return $"{PrintArray(data)} =>";
            await Task.Yield();

            T[] result;
            try
            {
                BrainCrushers.Exercise exercise = new();
                var list = AsLinkedList(data);
                exercise.Sort(ref list);
                result = Iterate(list).ToArray();
            }
            catch (Exception e)
            {
                throw new ApplicationException("Error while running test", e);
            }

            bool success = result.SequenceEqual(data.OrderBy(x => x));
            yield return $" {PrintArray(result)} {(success ? '✓' : '✗')}{Environment.NewLine}";
            if (!success)
            {
                throw new ApplicationException("Invalid test result");
            }
        }
    }

    private static string PrintArray<T>(T[]? data)
        => data is null ? "null" : "[" + string.Join(", ", data) + "]";

    private static IEnumerable<T> Iterate<T>(BrainCrushers.Exercise.Node<T>? head)
        where T : IComparable<T>
    {
        while (head is not null)
        {
            yield return head.Value;
            head = head.Next;
        }
    }

    private static BrainCrushers.Exercise.Node<T>? AsLinkedList<T>(T[] data)
        where T : IComparable<T>
    {
        BrainCrushers.Exercise.Node<T>? head = null;
        ref BrainCrushers.Exercise.Node<T>? curRef = ref head;
        foreach (T n in data)
        {
            curRef = new() { Value = n };
            curRef = ref curRef.Next;
        }

        return head;
    }
}