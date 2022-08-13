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
                new('h',
                    new('d')),
                new('w',
                    new('s',
                        null,
                        new('u',
                            new('t'),
                            new('v'))),
                    new('y')));

        List<char> expectedValues = new();
        ToList(tree, expectedValues);

        await foreach (string s in RunAsync(tree, expectedValues, new() { 'a', 'o', 'z', 'a', 'z', 'f', 'g' }))
            yield return s;

        tree = null;
        expectedValues = new();

        await foreach (string s in RunAsync(tree, expectedValues, new() { 'b', 'c', 'a', 'd', 'z' }))
            yield return s;

        tree = null;
        expectedValues = new();

        await foreach (string s in RunAsync(tree, expectedValues, new() { 'a', 'b', 'c', 'd', 'e', 'f', 'g' }))
            yield return s;
    }

    private IAsyncEnumerable<string> RunAsync(BrainCrushers.Exercise.Node? tree, List<char> expectedValues, List<char> values)
    {
        return RunAsync(
            tree,
            values,
            (e, root, value) =>
            {
                e.Add(value, ref root);
                return root;
            },
            (root, value) =>
            {
                List<char> values = new();
                ToList(root, values);
                expectedValues.Add(value);
                expectedValues.Sort();
                return values.SequenceEqual(expectedValues);
            },
            value => $"Add({value})");
    }
}

public class Tester2 : BaseTester
{
    public async IAsyncEnumerable<string> TestAsync()
    {
        BrainCrushers.Exercise.Node? tree =
            new('o',
                new('h',
                    new('d')),
                new('w',
                    new('s',
                        null,
                        new('u',
                            new('t'),
                            new('v'))),
                    new('y')));

        List<char> expectedValues = new();
        ToList(tree, expectedValues);

        await foreach (string s in RunAsync(tree, expectedValues, new() { 's', 'u', 't', 'h', 'o', 'o', 'a' }))
            yield return s;

        tree =
            new('o',
                new('h'),
                new('w'));

        expectedValues = new();
        ToList(tree, expectedValues);

        await foreach (string s in RunAsync(tree, expectedValues, new() { 'o', 'w', 'w', 'h', 'h' }))
            yield return s;
    }

    private IAsyncEnumerable<string> RunAsync(BrainCrushers.Exercise.Node? tree, List<char> expectedValues, List<char> values)
    {
        return RunAsync(
            tree,
            values,
            (e, root, value) =>
            {
                e.Remove(value, ref root);
                return root;
            },
            (root, value) =>
            {
                List<char> values = new();
                ToList(root, values);
                expectedValues.Remove(value);
                return values.SequenceEqual(expectedValues);
            },
            value => $"Remove({value})");
    }
}

public abstract class BaseTester
{
    public static Action? TimeoutCheckAction { get; set; }

    protected async IAsyncEnumerable<string> RunAsync(BrainCrushers.Exercise.Node? root, List<char> values, Func<BrainCrushers.Exercise, BrainCrushers.Exercise.Node?, char, BrainCrushers.Exercise.Node?> test, Func<BrainCrushers.Exercise.Node?, char, bool> expectedTest, Func<char, string> print)
    {
        yield return $"{PrintTree(root)}{Environment.NewLine} ⇓⇓⇓{Environment.NewLine}";
        await Task.Yield();

        foreach (var value in values)
        {
            yield return $"{print(value)}";
            bool result;
            try
            {
                BrainCrushers.Exercise exercise = new();
                root = test(exercise, root, value);
                result = IsBst(root).IsBst && expectedTest(root, value);
            }
            catch (Exception e)
            {
                throw new ApplicationException("Error while running test", e);
            }

            if (result)
            {
                yield return $" ✓{Environment.NewLine}";
            }
            else
            {
                yield return $" ✗{Environment.NewLine}{PrintTree(root)}{Environment.NewLine}";
                throw new ApplicationException("Invalid test result");
            }
        }

        yield return $"{PrintTree(root)}{Environment.NewLine}{Environment.NewLine}";
    }

    protected void ToList(BrainCrushers.Exercise.Node? node, List<char> list)
    {
        if (node is not null)
        {
            ToList(node.Left, list);
            list.Add(node.Value);
            ToList(node.Right, list);
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

    private (char? Min, char? Max, bool IsBst) IsBst(BrainCrushers.Exercise.Node? root)
    {
        TimeoutCheckAction?.Invoke();

        if (root is null)
            return (null, null, true);

        var left = IsBst(root.Left);
        if (left.IsBst is false || (left.Max is not null && left.Max.Value > root.Value))
            return (null, null, false);

        var right = IsBst(root.Right);
        if (right.IsBst is false || (right.Min is not null && right.Min.Value <= root.Value))
            return (null, null, false);

        return (left.Min ?? root.Value, right.Max ?? root.Value, true);
    }
}