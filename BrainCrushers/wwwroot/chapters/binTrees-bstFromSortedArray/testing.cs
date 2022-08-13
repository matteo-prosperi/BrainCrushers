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
        for (int i = 0; i < 18; i++)
        {
            var data = Enumerable.Range(0, i).Select(n => (char)('a' + n)).ToArray();
            var expected = (char[])data.Clone();

            yield return $"[{string.Join(", ", data.Select(c => $"'{c}'"))}]{Environment.NewLine}⇓⇓⇓{Environment.NewLine}";
            await Task.Yield();

            BrainCrushers.Exercise.Node? result;
            try
            {
                BrainCrushers.Exercise exercise = new();
                result = exercise.ToBinarySearchTree(data);
            }
            catch (Exception e)
            {
                throw new ApplicationException("Error while running test", e);
            }

            List<char> resultList = new();
            ToList(result, resultList);
            bool success = IsBst(result).IsBst && expected.SequenceEqual(resultList);

            yield return $"{(success ? '✓' : '✗')}{Environment.NewLine}";
            if (!success)
            {
                throw new ApplicationException("Invalid test result");
            }

            yield return $"{PrintTree(result)}{Environment.NewLine}{Environment.NewLine}";
        }
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