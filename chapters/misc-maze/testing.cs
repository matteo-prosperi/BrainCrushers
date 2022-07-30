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
        foreach (var data in new string[][] {
            new string[] { "█████████████",
                           "██        ███",
                           "████ ██ █████",
                           "█  █S █ █E ██",
                           "██ █ ██ ██ ██",
                           "██    █     █",
                           "█████████████" },

            new string[] { "████████████████████",
                           "██ █        ██   ███",
                           "██ █ ██ ███ ██ █████",
                           "█  █  █ █        ███",
                           "██ █ ██ ██ ████ ████",
                           "██ S ████   █      █",
                           "███ ██ ████████ ████",
                           "██████ ███   ██   ██",
                           "████ █ █        █  █",
                           "████ █████ ████ █ ██",
                           "███   E    ██   ████",
                           "████████████████████" },

            new string[] { "███",
                           "█X█",
                           "███" },

            new string[] { "█████████████",
                           "█  S        █",
                           "█ ███   ███ █",
                           "█           █",
                           "█ ███   ███ █",
                           "█        E  █",
                           "█████████████" },

            new string[] { "███████████████",
                           "█ S           █",
                           "█████████████ █",
                           "█           █ █",
                           "█ █████████ █ █",
                           "█ █       █ █ █",
                           "█ █ █████ █ █ █",
                           "█ █   E █ █ █ █",
                           "█ ███████ █ █ █",
                           "█ █       █ █ █",
                           "█ █ ███████ █ █",
                           "█ █         █ █",
                           "█ ███████████ █",
                           "█             █",
                           "███████████████" } })
        {
            yield return $"{string.Join(Environment.NewLine, data)}{Environment.NewLine} ⇓⇓⇓{Environment.NewLine}";
            await Task.Yield();

            BrainCrushers.Direction[] result;
            BrainCrushers.Position from = default;
            BrainCrushers.Position to = default;
            try
            {
                var maze = new BrainCrushers.Tile[data.Length, data[0].Length];
                for (int y = 0; y < data.Length; y++)
                {
                    for (int x = 0; x < data[0].Length; x++)
                    {
                        maze[y, x] = new(isWall: data[y][x] == '█');
                        if (data[y][x] == 'S' || data[y][x] == 'X')
                            from = new(y, x);
                        if (data[y][x] == 'E' || data[y][x] == 'X')
                            to = new(y, x);
                    }
                }

                BrainCrushers.Exercise exercise = new();
                result = exercise.Traverse(maze, from, to);
            }
            catch (Exception e)
            {
                throw new ApplicationException("Error while running test", e);
            }

            var output = data.Select(s => s.ToArray()).ToArray();
            bool success = false;
            if (result is not null)
            {
                success = true;
                output[from.Y][from.X] = '·';
                foreach (var direction in result)
                {
                    switch (direction)
                    {
                        case BrainCrushers.Direction.Up:
                            from = new(from.Y - 1, from.X);
                            break;
                        case BrainCrushers.Direction.Down:
                            from = new(from.Y + 1, from.X);
                            break;
                        case BrainCrushers.Direction.Right:
                            from = new(from.Y, from.X + 1);
                            break;
                        case BrainCrushers.Direction.Left:
                            from = new(from.Y, from.X - 1);
                            break;
                        default:
                            from = new(-1, -1);
                            break;
                    }
                    if (from.Y < 0 || from.X < 0 || from.Y >= output.Length || from.X >= output[0].Length)
                    {
                        success = false;
                        break;
                    }
                    if (output[from.Y][from.X] == '█')
                    {
                        output[from.Y][from.X] = '!';
                        success = false;
                        break;
                    }
                    output[from.Y][from.X] = '·';
                }
                success &= from.Equals(to);
            }

            yield return $"{string.Join(Environment.NewLine, output.Select(s => new string(s)))} {(success ? '✓' : '✗')}{Environment.NewLine}{Environment.NewLine}";
            if (!success)
            {
                throw new ApplicationException("Invalid test result");
            }
        }
    }

    private static int CountFalse(bool[,] data, int y)
    {
        int count = 0;
        for (int x = data.GetLength(1) - 1; x >= 0; x--)
        {
            if (data[y, x])
                break;
            else
                count++;
        }

        return count;
    }

    private static IEnumerable<int> CountFalse(bool[,] data)
    {
        for (int y = 0; y < data.GetLength(0); y++)
        {
            yield return CountFalse(data, y);
        }
    }

    private static string Print(bool[,] data)
    {
        StringBuilder result = new();
        for (int y = 0; y < data.GetLength(0); y++)
        {
            result.Append("[");
            for (int x = 0; x < data.GetLength(1); x++)
            {
                if (x != 0)
                    result.Append(' ');
                result.Append(data[y, x] ? "true " : "false");
            }
            result.Append("]");
            if (y < data.GetLength(0) - 1)
                result.AppendLine();
        }

        return result.ToString();
    }
}