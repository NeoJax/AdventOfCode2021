using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode2021.PuzzleCode
{
    public static class Day1
    {
        public static int Puzzle1(List<int> depths)
        {
            int prevDepth = Int32.MaxValue;
            int increaseCount = 0;
            for (int i = 0; i < depths.Count; i++)
            {
                int currentDepth = depths[i];
                if (currentDepth > prevDepth)
                {
                    increaseCount++;
                }

                prevDepth = currentDepth;
            }
            return increaseCount;
        }

        public static int Puzzle2(List<int> depths)
        {
            int prevThreeDepths = Int32.MaxValue;
            int increaseCount = 0;

            for (int i = 0; i < depths.Count-2; i++)
            {
                int currentThreeDepths = depths[i] + depths[i + 1] + depths[i + 2];
                if (currentThreeDepths > prevThreeDepths)
                {
                    increaseCount++;
                }

                prevThreeDepths = currentThreeDepths;
            }

            return increaseCount;
        }
    }
}
