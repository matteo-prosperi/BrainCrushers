namespace BrainCrushersTests;

using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

public class Tester1 : Tester
{
    public Tester1()
        : base(countReads: false)
    {
    }
}

public class Tester2 : Tester
{
    public Tester2()
        : base(countReads: true)
    {
    }
}

public class Tester
{
    private readonly bool CountReads;

    public Tester(bool countReads)
    {
        CountReads = countReads;
    }

    public static Action? TimeoutCheckAction { get; set; }

    public async IAsyncEnumerable<string> TestAsync()
    {
        await foreach (string s in TestArrayAsync(new int[] { 0, 1, 2, 3, 4, 5, 6, 7 }, 3))
            yield return s;
        await foreach (string s in TestArrayAsync(new int[] { 0, 1, 2, 3, 4, 5, 6, 7 }, 0))
            yield return s;
        await foreach (string s in TestArrayAsync(new int[] { 0, 1, 2, 3, 4, 5, 6, 7 }, 7))
            yield return s;
        await foreach (string s in TestArrayAsync(new int[] { 0, 1, 2, 3, 4, 5, 6, 7 }, 9))
            yield return s;
        await foreach (string s in TestArrayAsync(new int[] { 1, 12, 40 }, 1))
            yield return s;
        await foreach (string s in TestArrayAsync(new char[] { 'a', 'b', 'e', 'g', 'u' }, 'b'))
            yield return s;
        await foreach (string s in TestArrayAsync(new char[] { 'a', 'b', 'e', 'g', 'u' }, 'f'))
            yield return s;
        await foreach (string s in TestArrayAsync(new double[] { 7.3 }, 7.3))
            yield return s;
        await foreach (string s in TestArrayAsync(new int[] { 8 }, 1))
            yield return s;
        await foreach (string s in TestArrayAsync(new int[] { }, 1))
            yield return s;
        await foreach (string s in TestArrayAsync(Enumerable.Range(0, 100).ToArray(), 77))
            yield return s;
    }

    protected async IAsyncEnumerable<string> TestArrayAsync<T>(T[] data, T value)
        where T : IComparable<T>
    {
        yield return $"({PrintArray(data)}, {value}) =>";
        await Task.Yield();

        int result;
        DataContainer<T> container = new(data);
        try
        {
            BrainCrushers.Exercise exercise = new();
            result = exercise.FindValue(container, value);
        }
        catch (Exception e)
        {
            throw new ApplicationException("Error while running test", e);
        }

        
        bool success = result == Array.IndexOf(data, value);
        yield return $" {result} {(success ? '✓' : '✗')}";
        if (!success)
        {
            throw new ApplicationException("Invalid test result");
        }
        if (CountReads)
        {
            int expectedReads = data.Length > 0 ? (int)Math.Log2(data.Length) + 1 : 0;
            yield return $" Reads: {container.ReadCount} {(container.ReadCount > expectedReads ? ">" : "<=")} {expectedReads}";
            if (container.ReadCount > expectedReads)
            {
                throw new ApplicationException("Too many reads");
            }
        }
        yield return Environment.NewLine;
    }

    protected static string PrintArray(IEnumerable data)
        => "[" + string.Join(", ", data.Cast<object>()) + "]";

    private class DataContainer<T> : IReadOnlyList<T>
    {
        private T[] Data;
        public int ReadCount { get; private set; }

        public DataContainer(T[] data)
        {
            Data = data;
        }

        public T this[int index]
        {
            get
            {
                ReadCount++;
                return Data[index];
            }
        }

        public int Count => Data.Length;

        public IEnumerator<T> GetEnumerator()
        {
            return Enumerate().GetEnumerator();

            IEnumerable<T> Enumerate()
            {
                for (int i = 0; i < Count; i++)
                {
                    yield return this[i];
                }
            }
        }

        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
    }
}