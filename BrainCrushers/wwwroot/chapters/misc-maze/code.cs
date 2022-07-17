#region Using statements
using System;
#endregion

namespace BrainCrushers;

#region Intro

public class Exercise
{
    public Direction[] Traverse(Tile[,] maze, Position start, Position end)
	{
#endregion
#region Solution
        return null; // Fix me
#endregion
#region Outro
    }
}
#endregion
#region Tile
public class Tile
{
    public Tile(bool isWall)
    {
        IsWall = isWall;
    }

    public bool IsWall { get; }
#endregion
#region More Tile Code

#endregion
#region Tile Outro
}
#endregion
#region Direction
public enum Direction
{
    Up,
    Down,
    Left,
    Right
}
#endregion
#region Position
public struct Position
{
    public int Y;
    public int X;

    public Position(int y, int x)
    {
        Y = y;
        X = x;
    }
}
#endregion
