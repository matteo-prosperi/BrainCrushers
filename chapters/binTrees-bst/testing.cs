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
        foreach (var root in new BrainCrushers.Exercise.Node?[]
            {
                new('o',
                    new('w'),
                    new('h')),
                new('o',
                    new('w',
                        new('y',
                            new('z'),
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
                                new('k'),
                                new('i'))),
                        new('d',
                            new('f',
                                new('g'),
                                new('e')),
                            new('b',
                                new('c'),
                                new('a'))))),
                new('o',
                    null,
                    new('h',
                        null,
                        new('d',
                            null,
                            new('b',
                                null,
                                new('a'))))),
                new('o',
                    new('w',
                        new('y',
                            new('z')))),
                new('o',
                    new('w',
                        new('y',
                            new('z')),
                        new('s',
                            new('u',
                                new('v'),
                                new('t')),
                            new('q',
                                null,
                                new('p')))),
                    new('h',
                        new('l',
                            new('n',
                                null,
                                new('m'))),
                        new('d',
                            null,
                            new('b',
                                new('c'),
                                new('a'))))),
                null,
                new('o'),
                new('o',
                   new('f'),
                   new('a',
                        new('b',
                            new('z')))),
                new('o',
                    new('w',
                        new('y'),
                        new('a')),
                    new('h',
                        new('n'),
                        new('d'))),
           })
        {
            await foreach (string s in RunAsync(root, (e, n) => e.IsBst(n), n => IsBst(n).IsBst))
                yield return s;
        }
    }
}

public class Tester2 : BaseTester
{
    public async IAsyncEnumerable<string> TestAsync()
    {
        foreach (var root in new BrainCrushers.Exercise.Node?[]
            {
                new('o',
                    new('w'),
                    new('o')),
                new('o',
                    new('w',
                        new('y',
                            new('z'),
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
                                new('k'),
                                new('i'))),
                        new('d',
                            new('f',
                                new('g'),
                                new('e')),
                            new('b',
                                new('c'),
                                new('a'))))),
                new('o',
                    null,
                    new('h',
                        null,
                        new('d',
                            null,
                            new('b',
                                null,
                                new('a'))))),
                new('o',
                    new('w',
                        new('y',
                            new('z')))),
                new('o',
                    new('w',
                        new('y',
                            new('z')),
                        new('s',
                            new('u',
                                new('v'),
                                new('t')),
                            new('q',
                                null,
                                new('q')))),
                    new('h',
                        new('l',
                            new('n',
                                null,
                                new('m'))),
                        new('d',
                            null,
                            new('c',
                                new('d'),
                                new('a'))))),
                null,
                new('o'),
                new('o',
                   new('f'),
                   new('a',
                        new('b',
                            new('z')))),
                new('o',
                    new('w',
                        new('y'),
                        new('a')),
                    new('h',
                        new('z'),
                        new('d'))),
                new('o',
                    new('w',
                        new('w')),
                    new('h',
                        new('l'),
                        new('d'))),
           })
        {
            await foreach (string s in RunAsync(root, (e, n) => e.IsBst(n), n => IsBst(n).IsBst))
                yield return s;
        }
    }
}

public class Tester3 : BaseTester
{
    public async IAsyncEnumerable<string> TestAsync()
    {
        foreach (var root in new BrainCrushers.Exercise.Node?[]
            {
                new('o',
                    new('3'),
                    new('h')),
                new('o',
                    new('3',
                        new('y',
                            new('1'),
                            new('x')),
                        new('s',
                            new('u',
                                new('v'),
                                new('t')),
                            new('q',
                                new('7'),
                                new('p')))),
                    new('h',
                        new('L',
                            new('n',
                                new('Z'),
                                new('m')),
                            new('j',
                                new('k'),
                                new('i'))),
                        new('9',
                            new('f',
                                new('g'),
                                new('F')),
                            new('b',
                                new('c'),
                                new('a'))))),
                null,
                new('o'),
                new('o',
                    new('3',
                        new('y',
                            new('1'),
                            new('x')),
                        new('s')),
                    new('h',
                        new('L',
                            new('n',
                                new('Z'),
                                new('m')),
                            new('j',
                                new('k'),
                                new('i'))),
                        new('9',
                            new('f',
                                new('g'),
                                new('F')),
                            new('b',
                                new('c'),
                                new('a'))))),
           })
        {
            await foreach (string s in RunAsync(root, (e, n) => e.IsBalanced(n), IsBalanced))
                yield return s;
        }
    }
}

public abstract class BaseTester
{
    public static Action? TimeoutCheckAction { get; set; }

    protected async IAsyncEnumerable<string> RunAsync(BrainCrushers.Exercise.Node? root, Func<BrainCrushers.Exercise, BrainCrushers.Exercise.Node?, bool> test, Func<BrainCrushers.Exercise.Node?, bool> expectedTest)
    {
        yield return $"{PrintTree(root)}{Environment.NewLine} ⇓⇓⇓{Environment.NewLine}";
        await Task.Yield();

        bool expectedResult = expectedTest(root);
        bool result;
        try
        {
            BrainCrushers.Exercise exercise = new();
            result = test(exercise, root);
        }
        catch (Exception e)
        {
            throw new ApplicationException("Error while running test", e);
        }

        bool success = result == expectedResult;
        yield return $"{result} {(success ? '✓' : '✗')}{Environment.NewLine}{Environment.NewLine}";
        if (!success)
        {
            throw new ApplicationException("Invalid test result");
        }
    }

    protected (char? Min, char? Max, bool IsBst) IsBst(BrainCrushers.Exercise.Node? root)
    {
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

    protected bool IsBalanced(BrainCrushers.Exercise.Node? root)
    {
        var (min, max) = Evaluate(root);
        return max - min <= 1;

        (int MinDepth, int MaxDepth) Evaluate(BrainCrushers.Exercise.Node? root)
        {
            if (root is null)
                return (0, 0);

            var left = Evaluate(root.Left);
            var right = Evaluate(root.Right);

            return (Math.Min(left.MinDepth, right.MinDepth) + 1, Math.Max(left.MaxDepth, right.MaxDepth) + 1);
        }
    }

    protected static string PrintTree(BrainCrushers.Exercise.Node? root)
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