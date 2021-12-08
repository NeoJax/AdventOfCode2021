using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode2021.PuzzleCode
{
    public class Day6
    {
        public static int CountLanternsSimple(List<string> feesh)
        {
            List<int> fishClocks = feesh[0].Split(',').Select(fsh => int.Parse(fsh)).ToList();

            for (int days = 0; days < 80; days++)
            {
                for (int fish = 0; fish < fishClocks.Count; fish++)
                {
                    if (fishClocks[fish] == 0)
                    {
                        fishClocks.Add(9);
                        fishClocks[fish] = 7;
                    }
                }

                for (int fish = 0; fish < fishClocks.Count; fish++)
                {
                    fishClocks[fish]--;
                }
            }

            return fishClocks.Count;
        }

        public static long CountLanternsEfficient(List<string> feesh)
        {
            List<int> fishClocks = feesh[0].Split(',').Select(fsh => int.Parse(fsh)).ToList();
            List<long> fishClockSimple = new List<long>(new long[9]);
            long fishClockInterimOne = 0;
            long fishClockInterimTwo = 0;

            foreach (int fish in fishClocks)
            {
                fishClockSimple[fish]++;
            }

            for (int days = 1; days <= 256; days++)
            {
                fishClockInterimOne = fishClockSimple[7];
                fishClockSimple[7] = fishClockSimple[8];
                fishClockSimple[8] -= fishClockSimple[8];
                fishClockSimple[8] += fishClockSimple[0];
                fishClockInterimTwo = fishClockSimple[6];
                fishClockSimple[6] = fishClockInterimOne;
                fishClockInterimOne = fishClockSimple[5];
                fishClockSimple[5] = fishClockInterimTwo;
                fishClockInterimTwo = fishClockSimple[4];
                fishClockSimple[4] = fishClockInterimOne;
                fishClockInterimOne = fishClockSimple[3];
                fishClockSimple[3] = fishClockInterimTwo;
                fishClockInterimTwo = fishClockSimple[2];
                fishClockSimple[2] = fishClockInterimOne;
                fishClockInterimOne = fishClockSimple[1];
                fishClockSimple[1] = fishClockInterimTwo;
                fishClockInterimTwo = fishClockSimple[0];
                fishClockSimple[0] = fishClockInterimOne;
                fishClockSimple[6] += fishClockInterimTwo;
            }



            return fishClockSimple.Sum();
        }
    }
}
