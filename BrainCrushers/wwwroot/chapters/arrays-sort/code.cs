#region Intro
namespace BrainCrushers;

using System;

public class SortAlgorithms
{
    public void Sort(int[] data)
	{
#endregion
#region Solution
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
#region Outro
    }
}
#endregion