using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode2021.PuzzleCode
{
    public class Day2
    {
        public static int CalculateFinalPosition(List<string> directions)
        {
            int position = 0;
            int depth = 0;

            foreach (string line in directions)
            {
                string direction = line.Split(" ")[0];
                int distance = Int32.Parse(line.Split(" ")[1]);
                switch (direction)
                { 
                    case "forward":
                        position += distance;
                        break;
                    case "up":
                        depth -= distance;
                        break;
                    case "down":
                        depth += distance;
                        break;
                }
            }

            return position * depth;
        }

        public static int CalculateActualFinalPosition(List<string> directions)
        {
            int position = 0;
            int depth = 0;
            int aim = 0;

            foreach (string line in directions)
            {
                string direction = line.Split(" ")[0];
                int distance = Int32.Parse(line.Split(" ")[1]);
                switch (direction)
                {
                    case "forward":
                        position += distance;
                        depth += aim * distance;
                        break;
                    case "up":
                        aim -= distance;
                        break;
                    case "down":
                        aim += distance;
                        break;
                }
            }

            return position * depth;
        }
    }
}
