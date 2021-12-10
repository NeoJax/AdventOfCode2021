using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode2021.PuzzleCode
{
    public class Day9
    {
        public static int SumLowPoints(List<string> heightmapString)
        {
            List<List<int>> heightmap = new List<List<int>>();
            List<int> lowestPoints = new List<int>();

            foreach (string line in heightmapString)
            {
                heightmap.Add(line.ToCharArray().Select(c => (int)char.GetNumericValue(c)).ToList());
            }

            for (int i = 0; i < heightmap.Count; i++)
            {
                for (int j = 0; j < heightmap[i].Count; j++)
                {
                    bool checkTop = true;
                    bool checkLeft = true;
                    bool checkRight = true;
                    bool checkBottom = true;
                    int current = heightmap[i][j];
                    if (i != 0)
                    {
                        checkTop = current < heightmap[i-1][j];
                    } 
                    if (i + 1 < heightmap.Count)
                    {
                        checkBottom = current < heightmap[i+1][j];
                    }
                    if (j != 0)
                    {
                        checkLeft = current < heightmap[i][j-1];
                    }
                    if (j + 1 < heightmap[i].Count)
                    {
                        checkRight = current < heightmap[i][j+1];
                    }

                    if (checkTop && checkLeft && checkRight && checkBottom)
                    {
                        lowestPoints.Add(current);
                    }
                }
            }


            return lowestPoints.Sum() + lowestPoints.Count;
        }

        public static int FindBasins(List<string> heightmapString)
        {
            List<List<int>> heightmap = new List<List<int>>();
            List<Tuple<int, int>> lowestPoints = new List<Tuple<int, int>>();

            foreach (string line in heightmapString)
            {
                heightmap.Add(line.ToCharArray().Select(c => (int)char.GetNumericValue(c)).ToList());
            }

            for (int i = 0; i < heightmap.Count; i++)
            {
                for (int j = 0; j < heightmap[i].Count; j++)
                {
                    bool checkTop = true;
                    bool checkLeft = true;
                    bool checkRight = true;
                    bool checkBottom = true;
                    int current = heightmap[i][j];
                    if (i != 0)
                    {
                        checkTop = current < heightmap[i - 1][j];
                    }
                    if (i + 1 < heightmap.Count)
                    {
                        checkBottom = current < heightmap[i + 1][j];
                    }
                    if (j != 0)
                    {
                        checkLeft = current < heightmap[i][j - 1];
                    }
                    if (j + 1 < heightmap[i].Count)
                    {
                        checkRight = current < heightmap[i][j + 1];
                    }

                    if (checkTop && checkLeft && checkRight && checkBottom)
                    {
                        lowestPoints.Add(new Tuple<int, int>(i, j));
                    }
                }
            }

            return FindBasinSize(lowestPoints, heightmap);
        }

        private static int FindBasinSize(List<Tuple<int, int>> lowestPoints, List<List<int>> heightmap)
        {
            List<int> basinSizes = new List<int>();
            foreach (Tuple<int, int> point in lowestPoints)
            {
                List<Tuple<int, int>> history = new List<Tuple<int, int>>();
                basinSizes.Add(BasinCheck(point, heightmap, history).Count);
            }
            basinSizes = basinSizes.OrderByDescending(point => point).ToList();

            return basinSizes[0] * basinSizes[1] * basinSizes[2];
        }

        private static List<Tuple<int, int>> BasinCheck(Tuple<int, int> coords, List<List<int>> heightmap, List<Tuple<int, int>> history)
        {
            Tuple<int, int> left = new Tuple<int, int>(coords.Item1 - 1, coords.Item2);
            Tuple<int, int> right = new Tuple<int, int>(coords.Item1 + 1, coords.Item2);
            Tuple<int, int> up = new Tuple<int, int>(coords.Item1, coords.Item2 - 1);
            Tuple<int, int> down = new Tuple<int, int>(coords.Item1, coords.Item2 + 1);
            history.Add(coords);

            if (coords.Item1 != 0 && heightmap[coords.Item1 - 1][coords.Item2] != 9 && !history.Contains(left))
            {
                history = BasinCheck(left, heightmap, history);
            }
            if (coords.Item1 + 1 < heightmap.Count && heightmap[coords.Item1 + 1][coords.Item2] != 9 && !history.Contains(right))
            {
                history = BasinCheck(right, heightmap, history);
            }
            if (coords.Item2 != 0 && heightmap[coords.Item1][coords.Item2 - 1] != 9 && !history.Contains(up))
            {
                history = BasinCheck(up, heightmap, history);
            }
            if (coords.Item2 + 1 < heightmap[coords.Item1].Count && heightmap[coords.Item1][coords.Item2 + 1] != 9 && !history.Contains(down))
            {
                history = BasinCheck(down, heightmap, history);
            }
            return history;
        }
    }
}
