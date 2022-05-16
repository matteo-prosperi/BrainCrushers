#region Prefix
namespace BrainCrushers;

using System;

public partial class SortAlgorithms
{
    public void Sort(int[] data)
	{
#endregion
#region Problem
        Span<int> unsorted = data;
        while (unsorted.Length > 1)
        {
            int minPos = 0;
            for (int i = 1; i < unsorted.Length; i++)
            {
                if (unsorted[minPos] > unsorted[i])
                {
                    minPos = i;
                }
            }

            int tmp = unsorted[0];
            unsorted[0] = unsorted[minPos];
            unsorted[minPos] = tmp;
            unsorted = unsorted.Slice(1);
        }
#endregion
#region Suffix
    }
}
#endregion