using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode2021.PuzzleCode
{
    public class Day7
    {
        public static int CalculateCrabSubs(List<string> positions)
        {
            List<int> crabPositions = positions[0].Split(",").Select(int.Parse).ToList();
            int average = crabPositions.Sum() / crabPositions.Count;
            int minAvg = average - crabPositions.Count / 2;
            if (minAvg < 0)
            {
                minAvg = 0;
            }
            int maxAvg = average + crabPositions.Count / 2;
            int minFuel = Int32.MaxValue;
            int currentFuel = 0;
            for (int i = minAvg; i <= maxAvg; i++)
            {
                foreach (int crab in crabPositions)
                {
                    currentFuel += Math.Abs(crab - i);
                }

                if (currentFuel < minFuel)
                {
                    minFuel = currentFuel;
                }

                currentFuel = 0;
            }

            return minFuel;
        }

        public static int CalculateCrabSubsCorrectly(List<string> positions)
        {
            List<int> crabPositions = positions[0].Split(",").Select(int.Parse).ToList();
            int average = crabPositions.Sum() / crabPositions.Count;
            int minAvg = average - 100;
            if (minAvg < 0)
            {
                minAvg = 0;
            }
            int maxAvg = average + 100;
            int minFuel = Int32.MaxValue;
            int currentFuel = 0;
            for (int i = minAvg; i <= maxAvg; i++)
            {
                foreach (int crab in crabPositions)
                {
                    for (int j = 0; j <= Math.Abs(crab - i); j++)
                    {
                        currentFuel += j;
                    }
                }

                if (currentFuel < minFuel)
                {
                    minFuel = currentFuel;
                }

                currentFuel = 0;
            }

            return minFuel;
        }
    }
}
