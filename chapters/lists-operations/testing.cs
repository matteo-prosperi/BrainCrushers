namespace BrainCrushersTests;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

public class AddAsHeadTester : BaseTester
{   
    public async IAsyncEnumerable<string> TestAsync()
    {
        await foreach (string s in RunTestAsync(
            new int[] { },
            (list) => RunOperationAsync(list, () => list.AddAsHead(3), "AddAsHead(3)", new int[] { 3 }),
            (list) => RunOperationAsync(list, () => list.AddAsHead(2), "AddAsHead(2)", new int[] { 2, 3 }),
            (list) => RunOperationAsync(list, () => list.AddAsHead(1), "AddAsHead(1)", new int[] { 1, 2, 3 })))
            yield return s;
    }
}

public class RemoveHeadTester : BaseTester
{
    public async IAsyncEnumerable<string> TestAsync()
    {
        await foreach (string s in RunTestAsync(
            new int[] { 1, 2, 3 },
            (list) => RunOperationAsync(list, () => list.RemoveHead(), "RemoveHead() => ", new int[] { 2, 3 }, 1),
            (list) => RunOperationAsync(list, () => list.RemoveHead(), "RemoveHead() => ", new int[] { 3 }, 2),
            (list) => RunOperationAsync(list, () => list.RemoveHead(), "RemoveHead() => ", new int[] { }, 3),
            (list) => RunOperationAsync(list, () => list.RemoveHead(), "RemoveHead() => ", new int[] { }, typeof(InvalidOperationException))))
            yield return s;
    }
}

public class AddAsTailTester : BaseTester
{
    public async IAsyncEnumerable<string> TestAsync()
    {
        await foreach (string s in RunTestAsync(
            new int[] { },
            (list) => RunOperationAsync(list, () => list.AddAsTail(1), "AddAsTail(1)", new int[] { 1 }),
            (list) => RunOperationAsync(list, () => list.AddAsTail(2), "AddAsHead(2)", new int[] { 1, 2 }),
            (list) => RunOperationAsync(list, () => list.AddAsTail(3), "AddAsHead(3)", new int[] { 1, 2, 3 })))
            yield return s;
    }
}

public class RemoveTailTester : BaseTester
{
    public async IAsyncEnumerable<string> TestAsync()
    {
        await foreach (string s in RunTestAsync(
            new int[] { 1, 2, 3 },
            (list) => RunOperationAsync(list, () => list.RemoveTail(), "RemoveHead() => ", new int[] { 1, 2 }, 3),
            (list) => RunOperationAsync(list, () => list.RemoveTail(), "RemoveHead() => ", new int[] { 1 }, 2),
            (list) => RunOperationAsync(list, () => list.RemoveTail(), "RemoveHead() => ", new int[] { }, 1),
            (list) => RunOperationAsync(list, () => list.RemoveTail(), "RemoveHead() => ", new int[] { }, typeof(InvalidOperationException))))
            yield return s;
    }
}

public class ClearTester : BaseTester
{
    public async IAsyncEnumerable<string> TestAsync()
    {
        await foreach (string s in RunTestAsync(
            new int[] { 1, 2, 3 },
            (list) => RunOperationAsync(list, () => list.Clear(), "Clear()", new int[] {})))
            yield return s;
        await foreach (string s in RunTestAsync(
            new int[] { 1 },
            (list) => RunOperationAsync(list, () => list.Clear(), "Clear()", new int[] { })))
            yield return s;
        await foreach (string s in RunTestAsync(
            new int[] { },
            (list) => RunOperationAsync(list, () => list.Clear(), "Clear()", new int[] { })))
            yield return s;
    }
}

public class FindTester : BaseTester
{
    public async IAsyncEnumerable<string> TestAsync()
    {
        await foreach (string s in RunTestAsync(
            new int[] { 1, 2, 3 },
            (list) => RunOperationAsync(list, () => list.Find(1)?.Value, "Find(1) => ", new int[] { 1, 2, 3 }, 1),
            (list) => RunOperationAsync(list, () => list.Find(2)?.Value, "Find(2) => ", new int[] { 1, 2, 3 }, 2),
            (list) => RunOperationAsync(list, () => list.Find(3)?.Value, "Find(3) => ", new int[] { 1, 2, 3 }, 3),
            (list) => RunOperationAsync<int?>(list, () => list.Find(4)?.Value, "Find(4) => ", new int[] { 1, 2, 3 }, null)))
            yield return s;
        await foreach (string s in RunTestAsync(
            new int[] { 1 },
            (list) => RunOperationAsync(list, () => list.Find(1)?.Value, "Find(1) => ", new int[] { 1 }, 1),
            (list) => RunOperationAsync<int?>(list, () => list.Find(2)?.Value, "Find(2) => ", new int[] { 1 }, null)))
            yield return s;
        await foreach (string s in RunTestAsync(
            new int[] { },
            (list) => RunOperationAsync<int?>(list, () => list.Find(1)?.Value, "Find(1) => ", new int[] { }, null)))
            yield return s;
    }
}

public class GetNodeAtTester : BaseTester
{
    public async IAsyncEnumerable<string> TestAsync()
    {
        await foreach (string s in RunTestAsync(
            new int[] { 1, 2, 3 },
            (list) => RunOperationAsync(list, () => list.GetNodeAt(0)?.Value, "GetNodeAt(0) => ", new int[] { 1, 2, 3 }, 1),
            (list) => RunOperationAsync(list, () => list.GetNodeAt(1)?.Value, "GetNodeAt(1) => ", new int[] { 1, 2, 3 }, 2),
            (list) => RunOperationAsync(list, () => list.GetNodeAt(2)?.Value, "GetNodeAt(2) => ", new int[] { 1, 2, 3 }, 3),
            (list) => RunOperationAsync<int?>(list, () => list.GetNodeAt(3)?.Value, "GetNodeAt(3) => ", new int[] { 1, 2, 3 }, null)))
            yield return s;
        await foreach (string s in RunTestAsync(
            new int[] { 1 },
            (list) => RunOperationAsync(list, () => list.GetNodeAt(0)?.Value, "GetNodeAt(0) => ", new int[] { 1 }, 1),
            (list) => RunOperationAsync<int?>(list, () => list.GetNodeAt(1)?.Value, "GetNodeAt(1) => ", new int[] { 1 }, null)))
            yield return s;
        await foreach (string s in RunTestAsync(
            new int[] { },
            (list) => RunOperationAsync<int?>(list, () => list.GetNodeAt(0)?.Value, "GetNodeAt(0) => ", new int[] { }, null)))
            yield return s;
    }
}

public class IndexOfTester : BaseTester
{
    public async IAsyncEnumerable<string> TestAsync()
    {
        await foreach (string s in RunTestAsync(
            new int[] { 1, 2, 3 },
            (list) => RunOperationAsync(list, () => list.IndexOf(1), "IndexOf(1) => ", new int[] { 1, 2, 3 }, 0),
            (list) => RunOperationAsync(list, () => list.IndexOf(2), "IndexOf(2) => ", new int[] { 1, 2, 3 }, 1),
            (list) => RunOperationAsync(list, () => list.IndexOf(3), "IndexOf(3) => ", new int[] { 1, 2, 3 }, 2),
            (list) => RunOperationAsync(list, () => list.IndexOf(4), "IndexOf(4) => ", new int[] { 1, 2, 3 }, -1)))
            yield return s;
        await foreach (string s in RunTestAsync(
            new int[] { 1 },
            (list) => RunOperationAsync(list, () => list.IndexOf(1), "IndexOf(1) => ", new int[] { 1 }, 0),
            (list) => RunOperationAsync(list, () => list.IndexOf(2), "IndexOf(2) => ", new int[] { 1 }, -1)))
            yield return s;
        await foreach (string s in RunTestAsync(
            new int[] { },
            (list) => RunOperationAsync(list, () => list.IndexOf(1), "IndexOf(1) => ", new int[] { }, -1)))
            yield return s;
    }
}

public class InsertAfterTester : BaseTester
{
    public async IAsyncEnumerable<string> TestAsync()
    {
        await foreach (string s in RunTestAsync(
            new int[] { },
            (list) => RunOperationAsync(list, () => list.InsertAfter(null, 1), "InsertAfter(null, 1)", new int[] { 1 }),
            (list) => RunOperationAsync(list, () => list.InsertAfter(list.GetNodeAt(0), 3), "InsertAfter(GetNodeAt(0), 3)", new int[] { 1, 3 }),
            (list) => RunOperationAsync(list, () => list.InsertAfter(null, 0), "InsertAfter(null, 0)", new int[] { 0, 1, 3 }),
            (list) => RunOperationAsync(list, () => list.InsertAfter(list.GetNodeAt(1), 2), "InsertAfter(GetNodeAt(1), 2)", new int[] { 0, 1, 2, 3 }),
            (list) => RunOperationAsync(list, () => list.InsertAfter(list.GetNodeAt(3), 4), "InsertAfter(GetNodeAt(3), 4)", new int[] { 0, 1, 2, 3, 4 })))
            yield return s;
    }
}

public class InsertTester : BaseTester
{
    public async IAsyncEnumerable<string> TestAsync()
    {
        await foreach (string s in RunTestAsync(
            new int[] { },
            (list) => RunOperationAsync(list, () => list.Insert(1, 1), "Insert(1, 1)", new int[] { }, typeof(ArgumentOutOfRangeException)),
            (list) => RunOperationAsync(list, () => list.Insert(0, 2), "Insert(0, 2)", new int[] { 2 }),
            (list) => RunOperationAsync(list, () => list.Insert(0, 1), "Insert(0, 1)", new int[] { 1, 2 }),
            (list) => RunOperationAsync(list, () => list.Insert(2, 4), "Insert(2, 4)", new int[] { 1, 2, 4 }),
            (list) => RunOperationAsync(list, () => list.Insert(3, 5), "Insert(3, 5)", new int[] { 1, 2, 4, 5 }),
            (list) => RunOperationAsync(list, () => list.Insert(2, 3), "Insert(2, 3)", new int[] { 1, 2, 3, 4, 5 }),
            (list) => RunOperationAsync(list, () => list.Insert(10, 99), "Insert(10, 99)", new int[] { 1, 2, 3, 4, 5 }, typeof(ArgumentOutOfRangeException))))
            yield return s;
    }
}

public class RemoveTester : BaseTester
{
    public async IAsyncEnumerable<string> TestAsync()
    {
        await foreach (string s in RunTestAsync(
            new int[] { 1, 2, 3, 2, 3, 4 },
            (list) => RunOperationAsync(list, () => list.Remove(2), "Remove(2) => ", new int[] { 1, 3, 2, 3, 4 }, true),
            (list) => RunOperationAsync(list, () => list.Remove(2), "Remove(2) => ", new int[] { 1, 3, 3, 4 }, true),
            (list) => RunOperationAsync(list, () => list.Remove(4), "Remove(4) => ", new int[] { 1, 3, 3 }, true),
            (list) => RunOperationAsync(list, () => list.Remove(5), "Remove(5) => ", new int[] { 1, 3, 3 }, false),
            (list) => RunOperationAsync(list, () => list.Remove(1), "Remove(1) => ", new int[] { 3, 3 }, true),
            (list) => RunOperationAsync(list, () => list.Remove(3), "Remove(3) => ", new int[] { 3 }, true),
            (list) => RunOperationAsync(list, () => list.Remove(3), "Remove(3) => ", new int[] { }, true),
            (list) => RunOperationAsync(list, () => list.Remove(3), "Remove(3) => ", new int[] { }, false)))
            yield return s;
    }
}

public class RemoveAtTester : BaseTester
{
    public async IAsyncEnumerable<string> TestAsync()
    {
        await foreach (string s in RunTestAsync(
            new int[] { 1, 2, 3, 4 },
            (list) => RunOperationAsync(list, () => list.RemoveAt(4), "RemoveAt(4) => ", new int[] { 1, 2, 3, 4 }, typeof(ArgumentOutOfRangeException)),
            (list) => RunOperationAsync(list, () => list.RemoveAt(3), "RemoveAt(3) => ", new int[] { 1, 2, 3 }),
            (list) => RunOperationAsync(list, () => list.RemoveAt(1), "RemoveAt(1) => ", new int[] { 1, 3 }),
            (list) => RunOperationAsync(list, () => list.RemoveAt(0), "RemoveAt(0) => ", new int[] { 3 }),
            (list) => RunOperationAsync(list, () => list.RemoveAt(0), "RemoveAt(0) => ", new int[] { }),
            (list) => RunOperationAsync(list, () => list.RemoveAt(0), "RemoveAt(0) => ", new int[] { }, typeof(ArgumentOutOfRangeException))))
            yield return s;
    }
}

public abstract class BaseTester
{
    public static Action? TimeoutCheckAction { get; set; }

    protected async IAsyncEnumerable<string> RunTestAsync(int[] initialData, params Func<BrainCrushers.MyList, IAsyncEnumerable<string>>[] callbacks)
    {
        var list = TryCatch(() => new BrainCrushers.MyList());
        if ((initialData?.Length ?? 0) > 0)
        {
            yield return $"Using AddAsHead to initialize list to {PrintArray(initialData)}";
            foreach (int n in initialData!.Reverse())
            {
                await Task.Yield();
                TryCatch(() => list.AddAsHead(n));
            }
            yield return Environment.NewLine;
        }
        else
        {
            yield return $"Using a new MyList {Environment.NewLine}";
        }

        foreach (var callback in callbacks)
        {
            await foreach(string s in callback(list))
            {
                yield return s;
            }
        }

        yield return $"Final list: {PrintArray(list.ToArray())} ✓{Environment.NewLine}";
    }

    protected static string PrintArray(IEnumerable<int>? data)
        => data is null ? "null" : "[" + string.Join(", ", data) + "]";

    protected static T TryCatch<T>(Func<T> func)
    {
        try
        {
            return func();
        }
        catch (Exception e)
        {
            throw new ApplicationException("Error while running test", e);
        }
    }

    protected static void TryCatch(Action action)
    {
        try
        {
            action();
        }
        catch (Exception e)
        {
            throw new ApplicationException("Error while running test", e);
        }
    }

    protected static Exception? TryCatch<T>(Func<T> func, Type exceptionType, out T unexpectedResult)
    {
        unexpectedResult = default!;
        try
        {
            unexpectedResult = func();
            return null;
        }
        catch (Exception e)
        {
            if (e.GetType().IsAssignableTo(exceptionType))
            {
                return e;
            }
            throw new ApplicationException("Error while running test", e);
        }
    }

    protected IAsyncEnumerable<string> RunOperationAsync(BrainCrushers.MyList list, Action action, string message, int[] expectedList)
        => RunOperationAsync(list, () => { action(); return string.Empty; }, message, expectedList, string.Empty);

    protected IAsyncEnumerable<string> RunOperationAsync(BrainCrushers.MyList list, Action action, string message, int[] expectedList, Type expectedExceptionType)
        => RunOperationAsync(list, () => { action(); return string.Empty; }, message, expectedList, expectedExceptionType);

    protected async IAsyncEnumerable<string> RunOperationAsync<T>(BrainCrushers.MyList list, Func<object> action, string message, int[] expectedList, T expectedResult)
        where T : notnull
    {
        await Task.Yield();

        yield return message;

        string stringResult;
        bool success;
        if (expectedResult is Type expectedExceptionType)
        {
            var e = TryCatch(action, expectedExceptionType, out var result);
            if (e != null)
            {
                stringResult = ResultToString(e);
                success = true;
            }
            else
            {
                stringResult = ResultToString(result);
                success = false;
            }
        }
        else
        {
            var result = TryCatch(action);
            stringResult = ResultToString(result);
            success = Equals(result, expectedResult);
        }

        yield return stringResult;
        if (success is false)
        {
            yield return $" ✗{Environment.NewLine}";
            throw new ApplicationException("Invalid test result");
        }
        int actualCount = 0;
        foreach (int i in list)
        {
            actualCount++;
        }
        if (list.Count != actualCount)
        {
            yield return $", Count={list.Count} ✗{Environment.NewLine}";
            throw new ApplicationException("Invalid test result");
        }
        if (list.ToArray().SequenceEqual(expectedList) is false) // Using ToArray to avoid SequenceEqual using the MyList indexer
        {
            yield return $", {PrintArray(list)} ✗{Environment.NewLine}";
            throw new ApplicationException("Invalid test result");
        }
        yield return $" ✓{Environment.NewLine}";

        string ResultToString(object? r) => r switch
        {
            null => "null",
            BrainCrushers.MyList.INode node => $"{{ Value={node.Value} }}",
            Exception => r.GetType().Name,
            _ => r.ToString()!
        };
    }
}