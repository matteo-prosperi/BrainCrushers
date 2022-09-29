namespace BrainCrushers;

#region Using statements
using System;
using System.Collections.Generic;
#endregion

public class Exercise
{
#region Intro 1
    public record Node(char Value, Node? Right = null, Node? Left = null);

    public Node? Find(char value, Node? root)
	{
#endregion
#region Solution 1
        return null; // Fix me
#endregion
#region Outro 1
    }
#endregion
#region Intro 2
    public IEnumerable<Node> FindAll(char value, Node? root)
	{
#endregion
#region Solution 2
        return Array.Empty<Node>(); // Fix me
#endregion
#region Outro 2
    }
#endregion
#region Intro 3
    public char? FindMin(Node? root)
	{
#endregion
#region Solution 3
        return null; // Fix me
#endregion
#region Outro 3
    }
#endregion
}
