namespace BrainCrushersTests;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class Tester1 : BaseTester
{
    protected override (int Result, bool Success) Run(BrainCrushers.Exercise.Node? root)
    {
        (List<int> expectedPreOrder, List<int> expectedInOrder, List<int> expectedPostOrder) = TreeToLists(root);

        int expectedResult = 0;
        Count(root);

        BrainCrushers.Exercise exercise = new();
        var result = exercise.Count(root);

        bool success = result == expectedResult;
        return (result, success);

        void Count(BrainCrushers.Exercise.Node? node)
        {
            if (node is null)
                return;

            expectedResult++;

            Count(node.Left);
            Count(node.Right);
        }
    }
}

public class Tester2 : BaseTester
{
    protected override (int Result, bool Success) Run(BrainCrushers.Exercise.Node? root)
    {
        var expectedResult = Depth(root);

        BrainCrushers.Exercise exercise = new();
        var result = exercise.Depth(root);

        bool success = result == expectedResult;
        return (result, success);
    }

}

public abstract class BaseTester
{
    public static Action? TimeoutCheckAction { get; set; }

    protected abstract (int Result, bool Success) Run(BrainCrushers.Exercise.Node? root);

    public async IAsyncEnumerable<string> TestAsync()
    {
        foreach (var root in new BrainCrushers.Exercise.Node?[]
            {
                null,
                new() {
                    Value = 7,
                    Left = new() {
                        Value = 5,
                        Left = new() { Value = 2 },
                        Right = new() { Value = 1 } },
                    Right = new() {
                        Value = 6,
                        Left = new() { Value = 4 },
                        Right = new() { Value = 3 } } },
                new() {
                    Value = 7,
                    Left = new() { Value = 5 },
                    Right = new() {
                        Value = 6,
                        Left = new() { Value = 4 },
                        Right = new() { Value = 3 } } },
                new() {
                    Value = 7,
                    Right = new() {
                        Value = 6,
                        Left = new() { Value = 4 },
                        Right = new() { Value = 3 } } },
                new() { Value = 7 },
                new() {
                    Value = 3,
                    Left = new() {
                        Value = 8,
                        Left = new() { Value = 2 },
                        Right = new() {
                            Value = 7,
                            Left = new() {
                                Value = 5,
                                Left = new() { Value = 2 },
                                Right = new() { Value = 4 } },
                            Right = new() {
                                Value = 5,
                                Left = new() { Value = 9 },
                                Right = new() { Value = 1 } } } },
                    Right = new() {
                        Value = 3,
                        Left = new() {
                            Value = 4,
                            Right = new() {
                                Value = 9,
                                Left = new() { Value = 5 },
                                Right = new() {
                                    Value = 1,
                                    Left = new() { Value = 7 } } } },
                        Right = new() { Value = 7 } } },

           })
        {
            yield return $"{PrintTree(root)}{Environment.NewLine}⇓{Environment.NewLine}";
            await Task.Yield();

            (int Result, bool Success) result;
            try
            {
                result = Run(root);
            }
            catch (Exception e)
            {
                throw new ApplicationException("Error while running test", e);
            }

            yield return $"{result.Result} {(result.Success ? '✓' : '✗')}{Environment.NewLine}{Environment.NewLine}";
            if (!result.Success)
            {
                throw new ApplicationException("Invalid test result");
            }
        }
    }

    protected static (List<int> PreOrder, List<int> InOrder, List<int> PostOrder) TreeToLists(BrainCrushers.Exercise.Node? root)
    {
        List<int> preOrder = new();
        List<int> inOrder = new();
        List<int> postOrder = new();
        Traverse(root);

        void Traverse(BrainCrushers.Exercise.Node? node)
        {
            if (node is null)
                return;

            preOrder.Add(node.Value);
            Traverse(node.Left);
            inOrder.Add(node.Value);
            Traverse(node.Right);
            postOrder.Add(node.Value);
        }

        return (preOrder, inOrder, postOrder);
    }

    protected static string PrintArray(List<int>? data)
        => data is null ? "null" : "[" + string.Join(", ", data) + "]";

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

    protected static int Depth(BrainCrushers.Exercise.Node? root, int depth = 0)
    {
        if (root is null)
            return depth;

        var leftDepth = Depth(root.Left, depth + 1);
        var rightDepth = Depth(root.Right, depth + 1);

        return Math.Max(leftDepth, rightDepth);
    }
}