#region Using statements
using System;
using System.Collections.Generic;
using System.Linq;
#endregion

namespace BrainCrushers;

public class Exercise
{
#region Intro
    public Hanoi Solve(int count)
	{
        var hanoi = new Hanoi(count);
#endregion
#region Solution
        return hanoi; // Fix me
#endregion
#region Outro
    }

    public class Hanoi
    {
        private List<int>[] Towers = new List<int>[3] { new(), new(), new() };

        public Hanoi(int count)
        {
            for (int i = count; i > 0; i--)
            {
                Towers[0].Add(i);
            }    
        }

        public int? Peek(int tower) => Towers[tower].Count > 0 ? Towers[tower].Last() : null;

        public int Count(int tower) => Towers[tower].Count;

        public void Move(int originTower, int destinationTower)
        {
            if (originTower == destinationTower)
                throw new InvalidOperationException($"The origin and destination towers are the same");

            int diskSize = Peek(originTower) ?? throw new InvalidOperationException($"Tower {originTower} is empty");
            int? destinationTowerDiskSize = Peek(destinationTower);
            if (destinationTowerDiskSize is not null && destinationTowerDiskSize < diskSize)
                throw new InvalidOperationException($"Cannot move disk with size {diskSize} onto disk with size {destinationTowerDiskSize}");

            Towers[originTower].RemoveAt(Towers[originTower].Count - 1);
            Towers[destinationTower].Add(diskSize);
        }
    }
#endregion
}
