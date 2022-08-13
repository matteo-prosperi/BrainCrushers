namespace BrainCrushers;

#region Using statements
using System;
using System.Collections.Generic;
#endregion

public class Exercise
{
#region Intro
    public class Node
    {
        public Node(char value, Node? left = null, Node? right = null)
        {
            Value = value;
            Left = left;
            Right = right;
        }

        public char Value;
        public Node? Left;
        public Node? Right;
    }

    public Node? ToBinarySearchTree(char[] values)
	{
#endregion
#region Solution
        return null; // Fix me
#endregion
#region Outro
    }
#endregion
}
