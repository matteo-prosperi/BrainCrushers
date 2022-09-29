namespace BrainCrushers;

#region Using statements
using System;
using System.Collections.Generic;
#endregion

#region Intro
public class MyList : IList<int>
{
    public interface INode
    {
        int Value { get; }
        INode? Next { get; }
    }

    private class Node : INode
    {
        public int Value { get; set; }
        public Node? Next { get; set; }

        // This is needed because Next and INode.Next have different types.
        INode? INode.Next => Next;
    }

    private Node? Head = null;

    public int Count { get; private set; } = 0;
#endregion
#region AddAsHead Intro
    public void AddAsHead(int item)
    {
#endregion
#region AddAsHead

#endregion
#region AddAsHead Outro
    }
#endregion
#region RemoveHead Intro
    public int RemoveHead()
    {
#endregion
#region RemoveHead
        return 0; // Fix me
#endregion
#region RemoveHead Outro
    }
#endregion
#region AddAsTail Intro
    public void AddAsTail(int item)
    {
#endregion
#region AddAsTail

#endregion
#region AddAsTail Outro
    }
#endregion
#region RemoveTail Intro
    public int RemoveTail()
    {
#endregion
#region RemoveTail
        return 0; // Fix me
#endregion
#region RemoveTail Outro
    }
#endregion
#region Clear Intro
    public void Clear() // From ICollection<T>
    {
#endregion
#region Clear

#endregion
#region Clear Outro
    }
#endregion
#region Find Intro
    public INode? Find(int item)
    {
#endregion
#region Find
        return null; // Fix me
#endregion
#region Find Outro
    }

    // From ICollection<T>
    public bool Contains(int item) => Find(item) is not null;
#endregion
#region GetNodeAt Intro
    public INode? GetNodeAt(int index)
    {
#endregion
#region GetNodeAt
        return null; // Fix me
#endregion
#region GetNodeAt Outro
    }

    public int this[int index] // From IList<T>
    {
        get => GetNodeAt(index)?.Value ?? throw new ArgumentOutOfRangeException();
        set => (GetNodeAt(index) as Node ?? throw new ArgumentOutOfRangeException()).Value = value;
    }
#endregion
#region IndexOf Intro
    public int IndexOf(int item) // From IList<T>
    {
#endregion
#region IndexOf
        return 0; // Fix me
#endregion
#region IndexOf Outro
    }
#endregion
#region InsertAfter Intro
    public void InsertAfter(INode? node, int item)
    {
#endregion
#region InsertAfter

#endregion
#region InsertAfter Outro
    }
#endregion
#region Insert Intro
    public void Insert(int index, int item) // From IList<T>
    {
#endregion
#region Insert

#endregion
#region Insert Outro
    }
#endregion
#region Remove Intro
    public bool Remove(int item) // From ICollection<T>
    {
#endregion
#region Remove
        return false; // Fix me
#endregion
#region Remove Outro
    }
#endregion
#region RemoveAt Intro
    public void RemoveAt(int index) // From IList<T>
    {
#endregion
#region RemoveAt

#endregion
#region RemoveAt Outro
    }
#endregion
#region GetEnumerator
    public IEnumerator<int> GetEnumerator() // From IEnumerable<T>
    {
        return Enumerate().GetEnumerator();

        IEnumerable<int> Enumerate()
        {
            INode? iterator = Head;
            while (iterator is not null)
            {
                yield return iterator.Value;
                iterator = iterator.Next;
            }
        }
    }
#endregion
#region CopyTo
    public void CopyTo(int[] array, int arrayIndex) // From ICollection<T>
    {
        if (array is null)
            throw new ArgumentNullException(nameof(array));
        if (arrayIndex < 0)
            throw new ArgumentOutOfRangeException(nameof(arrayIndex));
        if (array.Length - arrayIndex < Count)
            throw new ArgumentException(nameof(arrayIndex));

        int i = arrayIndex;
        foreach (int n in this)
        {
            array[i++] = n;
        }
    }
#endregion
#region Explicit implementations
    void ICollection<int>.Add(int item) => AddAsHead(item);

    System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() => GetEnumerator();

    bool ICollection<int>.IsReadOnly => false;
}
#endregion