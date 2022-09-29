namespace BrainCrushers;

#region Using statements
using System;
#endregion

public class Exercise
{
#region Intro
    public class Node<T>
        where T : IComparable<T>
    {
        public T Value;
        public Node<T>? Next;
    }

    public void Sort<T>(ref Node<T>? head)
        where T : IComparable<T>
	{
#endregion
#region Solution

#endregion
#region Outro
    }
#endregion
}
