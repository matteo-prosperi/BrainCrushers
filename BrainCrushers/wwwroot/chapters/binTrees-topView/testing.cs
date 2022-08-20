namespace BrainCrushersTests;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class Tester
{
    public static Action? TimeoutCheckAction { get; set; }

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
                new() {
                    Value = 3,
                    Left = new() {
                        Value = 8,
                        Right = new() {
                            Value = 7,
                            Right = new() {
                                Value = 5,
                                Right = new() { Value = 1 } } } },
                    Right = new() { Value = 3 } },
           })
        {
            yield return $"{PrintTree(root)}{Environment.NewLine} ⇓⇓⇓{Environment.NewLine}";
            await Task.Yield();


            int[] expectedResult = TopView(root);
            int[]? result;
            try
            {
                BrainCrushers.Exercise exercise = new();
                result = exercise.TopView(root);
            }
            catch (Exception e)
            {
                throw new ApplicationException("Error while running test", e);
            }

            bool success = result?.SequenceEqual(expectedResult) ?? false;
            yield return $"{PrintArray(result)} {(success ? '✓' : '✗')}{Environment.NewLine}{Environment.NewLine}";
            if (!success)
            {
                throw new ApplicationException("Invalid test result");
            }
        }
    }

    protected static int[] TopView(BrainCrushers.Exercise.Node? root)
    {
        List<(int Level, int Position, int Value)> allNodes = new();
        Traverse(root, 0, 0);

        void Traverse(BrainCrushers.Exercise.Node? node, int position, int level)
        {
            if (node is null)
                return;

            allNodes.Add((level, position, node.Value));
            Traverse(node.Left, position - 1, level + 1);
            Traverse(node.Right, position + 1, level + 1);
        }

        return allNodes
            .GroupBy(node => node.Position)
            .OrderBy(slice => slice.Key)
            .Select(slice => slice
                .MinBy(node => node.Level).Value)
            .ToArray();
    }

    protected static string PrintArray(int[]? data)
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

    private static int Depth(BrainCrushers.Exercise.Node? root, int depth = 0)
    {
        if (root is null)
            return depth;

        var leftDepth = Depth(root.Left, depth + 1);
        var rightDepth = Depth(root.Right, depth + 1);

        return Math.Max(leftDepth, rightDepth);
    }
}