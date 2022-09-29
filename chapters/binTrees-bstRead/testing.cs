namespace BrainCrushersTests;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class Tester1 : BaseTester
{
    public async IAsyncEnumerable<string> TestAsync()
    {
        BrainCrushers.Exercise.Node? tree =
            new('o',
                new('w',
                    new('y',
                        null,
                        new('x')),
                    new('s',
                        new('u',
                            new('v'),
                            new('t')),
                        new('q',
                            new('r'),
                            new('p')))),
                new('h',
                    new('l',
                        new('n',
                            null,
                            new('m')),
                        new('j',
                            null,
                            new('i'))),
                    new('d',
                        new('f',
                            new('g'),
                            new('e')),
                        new('b',
                            new('c')))));

        BrainCrushers.Exercise.Node? singleElementTree = new('o');

        yield return "'o', " + Environment.NewLine;
        await foreach (string s in RunAsync(tree, 'o'))
            yield return s;

        yield return "'x', " + Environment.NewLine;
        await foreach (string s in RunAsync(tree, 'x'))
            yield return s;

        yield return "'y', " + Environment.NewLine;
        await foreach (string s in RunAsync(tree, 'y'))
            yield return s;

        yield return "'n', " + Environment.NewLine;
        await foreach (string s in RunAsync(tree, 'n'))
            yield return s;

        yield return "'a', " + Environment.NewLine;
        await foreach (string s in RunAsync(tree, 'a'))
            yield return s;

        yield return "'b', " + Environment.NewLine;
        await foreach (string s in RunAsync(tree, 'b'))
            yield return s;

        yield return "'c', " + Environment.NewLine;
        await foreach (string s in RunAsync(tree, 'c'))
            yield return s;

        yield return "'k', " + Environment.NewLine;
        await foreach (string s in RunAsync(tree, 'k'))
            yield return s;

        yield return "'k', ";
        await foreach (string s in RunAsync(null, 'k'))
            yield return s;

        yield return "'k', ";
        await foreach (string s in RunAsync(singleElementTree, 'k'))
            yield return s;

        yield return "'o', ";
        await foreach (string s in RunAsync(singleElementTree, 'o'))
            yield return s;
    }

    private IAsyncEnumerable<string> RunAsync(BrainCrushers.Exercise.Node? root, char value)
        => RunAsync(
            root,
            (e, n) => e.Find(value, n),
            n => ReferenceEquals(Enumerate(value, root).SingleOrDefault(), n),
            n => n is null ? "null" : $"({n.Value})");
}

public class Tester2 : BaseTester
{
    public async IAsyncEnumerable<string> TestAsync()
    {
        BrainCrushers.Exercise.Node? tree =
            new('o',
                new('s',
                    new('y',
                        null,
                        new('x')),
                    new('s',
                        null,
                        new('q',
                            new('s'),
                            new('p')))),
                new('h',
                    new('l',
                        new('n',
                            null,
                            new('m')),
                        new('j',
                            null,
                            new('i'))),
                    new('c',
                        new('f',
                            new('g'),
                            new('e')),
                        new('c',
                            null,
                            new('c')))));

        BrainCrushers.Exercise.Node? singleElementTree = new('o');

        yield return "'o', " + Environment.NewLine;
        await foreach (string s in RunAsync(tree, 'o'))
            yield return s;

        yield return "'x', " + Environment.NewLine;
        await foreach (string s in RunAsync(tree, 'x'))
            yield return s;

        yield return "'c', " + Environment.NewLine;
        await foreach (string s in RunAsync(tree, 'c'))
            yield return s;

        yield return "'s', " + Environment.NewLine;
        await foreach (string s in RunAsync(tree, 's'))
            yield return s;

        yield return "'n', " + Environment.NewLine;
        await foreach (string s in RunAsync(tree, 'n'))
            yield return s;

        yield return "'a', " + Environment.NewLine;
        await foreach (string s in RunAsync(tree, 'a'))
            yield return s;

        yield return "'b', " + Environment.NewLine;
        await foreach (string s in RunAsync(tree, 'b'))
            yield return s;

        yield return "'k', " + Environment.NewLine;
        await foreach (string s in RunAsync(tree, 'k'))
            yield return s;

        yield return "'k', ";
        await foreach (string s in RunAsync(null, 'k'))
            yield return s;

        yield return "'k', ";
        await foreach (string s in RunAsync(singleElementTree, 'k'))
            yield return s;

        yield return "'o', ";
        await foreach (string s in RunAsync(singleElementTree, 'o'))
            yield return s;
    }

    private IAsyncEnumerable<string> RunAsync(BrainCrushers.Exercise.Node? root, char value)
    => RunAsync(
        root,
        (e, n) => e.FindAll(value, n),
        enumerable => EnumerableEquals(Enumerate(value, root), enumerable),
        enumerable => enumerable is null ? "null" : "[" + string.Join(", ", enumerable.Select(n => $"({n.Value})")) + "]");

    private bool EnumerableEquals<T>(IEnumerable<T> e1, IEnumerable<T>? e2)
    {
        if (e2 is null)
            return false;

        var a1 = e1.ToArray();
        var a2 = e2.ToArray();

        if (a1.Length != a2.Length)
            return false;

        foreach (T n in a1)
        {
            if (a2.Where(n2 => ReferenceEquals(n, n2)).Count() != 1)
                return false;
        }

        return true;
    }
}

public class Tester3 : BaseTester
{
    public async IAsyncEnumerable<string> TestAsync()
    {
        foreach (var tree in new BrainCrushers.Exercise.Node?[] {
                new('o',
                    new('w',
                        new('y',
                            null,
                            new('x')),
                        new('s',
                            new('u',
                                new('v'),
                                new('t')),
                            new('q',
                                new('r'),
                                new('p')))),
                    new('h',
                        new('l',
                            new('n',
                                null,
                                new('m')),
                            new('j',
                                null,
                                new('i'))),
                        new('d',
                            new('f',
                                new('g'),
                                new('e')),
                            new('b',
                                new('c'))))),
                new('o',
                    new('w',
                        new('y',
                            null,
                            new('x')),
                        new('s',
                            new('u',
                                new('v'),
                                new('t')),
                            new('q',
                                new('r'),
                                new('p'))))),
                new('o',
                    null,
                    new('h',
                        new('l',
                            new('n',
                                null,
                                new('m'))),
                        new('d',
                            new('f',
                                new('g'),
                                new('e')),
                            new('c',
                                null,
                                new('b'))))),
                new('o'),
                null,
            })
        {
            await foreach (string s in RunAsync(
                    tree,
                    (e, n) => e.FindMin(n),
                    c => c == FindMin(tree),
                    c => c is null ? "null" : $"'{c}'"))
                yield return s;
        }
    }

    private char? FindMin(BrainCrushers.Exercise.Node? node)
    {
        char? minvalue = node?.Value;
        while (node != null)
        {
            minvalue = node.Value;
            node = node.Left;
        }
        return minvalue;
    }
}

public abstract class BaseTester
{
    public static Action? TimeoutCheckAction { get; set; }

    protected async IAsyncEnumerable<string> RunAsync<T>(BrainCrushers.Exercise.Node? root, Func<BrainCrushers.Exercise, BrainCrushers.Exercise.Node?, T> test, Func<T, bool> expectedTest, Func<T, string> print)
    {
        yield return $"{PrintTree(root)}{Environment.NewLine} ⇓⇓⇓{Environment.NewLine}";
        await Task.Yield();

        T result;
        try
        {
            BrainCrushers.Exercise exercise = new();
            result = test(exercise, root);
        }
        catch (Exception e)
        {
            throw new ApplicationException("Error while running test", e);
        }

        bool success = expectedTest(result);
        yield return $"{print(result)} {(success ? '✓' : '✗')}{Environment.NewLine}{Environment.NewLine}";
        if (!success)
        {
            throw new ApplicationException("Invalid test result");
        }
    }

    protected IEnumerable<BrainCrushers.Exercise.Node?> Enumerate(char value, BrainCrushers.Exercise.Node? node)
    {
        while (node is not null)
        {
            if (value == node.Value)
            {
                yield return node;
            }
            
            node = value <= node.Value ? node.Left : node.Right;
        }
    }

    private static string PrintTree(BrainCrushers.Exercise.Node? root)
    {
        if (root is null)
            return "null";

        var depth = Depth(root);
        List<BrainCrushers.Exercise.Node?> currentLevel = new() { root };
        List<string> levels = new();

        for (int i = 0; i < depth; i++)
        {
            StringBuilder builder = new();
            List<BrainCrushers.Exercise.Node?> nextLevel = new();
            builder.Append(' ', (int)Math.Pow(2, depth - i) - 2);
            foreach (var node in currentLevel)
            {
                nextLevel.Add(node?.Left);
                nextLevel.Add(node?.Right);
                builder.Append(node is null ? "   " : $"[{node.Value}]");
                builder.Append(' ', (int)Math.Pow(2, depth - i + 1) - 3);
            }
            levels.Add(builder.ToString());

            builder = new();
            builder.Append(' ', (int)Math.Pow(2, depth - i) - 2);
            foreach (var node in currentLevel)
            {
                builder.Append(node?.Left is null ? ' ' : '/');
                builder.Append(' ');
                builder.Append(node?.Right is null ? ' ' : '\\');
                builder.Append(' ', (int)Math.Pow(2, depth - i + 1) - 3);
            }
            levels.Add(builder.ToString());

            currentLevel = nextLevel;
        }

        int toTrim = levels.Select(s => s.TakeWhile(c => c == ' ').Count()).Min();
        return string.Join(Environment.NewLine, levels.Select(s => s.Substring(toTrim).TrimEnd()).Where(s => s.Length > 0));
    }

    private static int Depth(BrainCrushers.Exercise.Node? root, int depth = 0)
    {
        if (root is null)
            return depth;

        var leftDepth = Depth(root.Left, depth + 1);
        var rightDepth = Depth(root.Right, depth + 1);

        return Math.Max(leftDepth, rightDepth);
    }
}