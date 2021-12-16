using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode2021.PuzzleCode
{
    public class Day11
    {
        public static int OctopusLights(List<string> levelsStr)
        {
            List<List<int>> levels = levelsStr.Select(line => line.ToCharArray().Select(c => (int)char.GetNumericValue(c)).ToList()).ToList();
            int flashes = 0;

            for (int time = 1; time <= 100; time++)
            {
                foreach (List<int> line in levels)
                {
                    for (int index = 0; index < line.Count; index++)
                    {
                        line[index]++;
                    }
                }

                for (var x = 0; x < levels.Count; x++)
                {
                    for (int y = 0; y < levels[x].Count; y++)
                    {
                        if (levels[x][y] > 9)
                        {
                            flashes += FlashCheck(x, y, levels, new List<Tuple<int, int>>()).Count;
                        }
                    }
                }
            }

            return flashes;
        }

        public static int OctopusLightsSync(List<string> levelsStr)
        {
            List<List<int>> levels = levelsStr.Select(line => line.ToCharArray().Select(c => (int)char.GetNumericValue(c)).ToList()).ToList();
            int step = 0;

            for (int time = 1; time <= 1000; time++)
            {
                step = 0;
                foreach (List<int> line in levels)
                {
                    for (int index = 0; index < line.Count; index++)
                    {
                        line[index]++;
                    }
                }

                for (var x = 0; x < levels.Count; x++)
                {
                    for (int y = 0; y < levels[x].Count; y++)
                    {
                        if (levels[x][y] > 9)
                        {
                            FlashCheck(x, y, levels, new List<Tuple<int, int>>());
                        }
                    }
                }

                foreach (List<int> level in levels)
                {
                    step += level.Sum();
                }

                if (step == 0)
                {
                    return time;
                }
            }

            return 0;
        }

        private static List<Tuple<int, int>> FlashCheck(int x, int y, List<List<int>> levels, List<Tuple<int, int>> history)
        {
            history.Add(new Tuple<int, int>(x, y));
            levels[x][y] = 0;

            if (x != 0)
            {
                if (y != 0)
                {
                    if (levels[x - 1][y - 1] > 0)
                    {
                        levels[x - 1][y - 1]++;
                    }

                    if (levels[x - 1][y - 1] > 9)
                    {
                        FlashCheck(x - 1, y - 1, levels, history);
                    }
                }
                if (y + 1 < levels[x].Count)
                {
                    if (levels[x - 1][y + 1] > 0)
                    {
                        levels[x - 1][y + 1]++;
                    }

                    if (levels[x - 1][y + 1] > 9)
                    {
                        FlashCheck(x - 1, y + 1, levels, history);
                    }
                }
                if (levels[x - 1][y] > 0)
                {
                    levels[x - 1][y]++;
                }

                if (levels[x - 1][y] > 9)
                {
                    FlashCheck(x - 1, y, levels, history);
                }
            }
            if (y != 0)
            {
                if (levels[x][y - 1] > 0)
                {
                    levels[x][y - 1]++;
                }
                if (levels[x][y - 1] > 9)
                {
                    FlashCheck(x, y - 1, levels, history);
                }
            }
            if (y + 1 < levels[x].Count)
            {
                if (levels[x][y + 1] > 0)
                {
                    levels[x][y + 1]++;
                }
                if (levels[x][y + 1] > 9)
                {
                    FlashCheck(x, y + 1, levels, history);
                }
            }
            if (x + 1 < levels.Count)
            {
                if (y != 0)
                {
                    if (levels[x + 1][y - 1] > 0)
                    {
                        levels[x + 1][y - 1]++;
                    }

                    if (levels[x + 1][y - 1] > 9)
                    {
                        FlashCheck(x + 1, y - 1, levels, history);
                    }
                }
                if (y + 1 < levels[x].Count)
                {
                    if (levels[x + 1][y + 1] > 0)
                    {
                        levels[x + 1][y + 1]++;
                    }

                    if (levels[x + 1][y + 1] > 9)
                    {
                        FlashCheck(x + 1, y + 1, levels, history);
                    }
                }
                if (levels[x + 1][y] > 0)
                {
                    levels[x + 1][y]++;
                }
                if (levels[x + 1][y] > 9)
                {
                    FlashCheck(x + 1, y, levels, history);
                }
            }

            return history;
        }
    }
}
