using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode2021.PuzzleCode
{
    public class Day5
    {
        public static int CalculateVentOverlap(List<string> coordinatesList)
        {
            List<List<Tuple<int, int>>> coordinatesTuples = coordinatesList.Select(str => str.Split(" -> ")
                                    .Select(coords => new Tuple<int,int> (int.Parse(coords.Split(",")[0]), int.Parse(coords.Split(",")[1]))).ToList()).ToList();
            List<List<int>> oceanFloor = DetermineFloorSize(coordinatesTuples);
            int overlap = 0;

            for (int index = 0; index < coordinatesTuples.Count; index++)
            {
                var vectorOne = coordinatesTuples[index][0];
                var vectorTwo = coordinatesTuples[index][1];
                if (vectorOne.Item1 != vectorTwo.Item1 && vectorOne.Item2 == vectorTwo.Item2)
                {
                    if (vectorTwo.Item1 > vectorOne.Item1)
                    {
                        oceanFloor = CalculateXChange(vectorTwo, vectorOne, oceanFloor);
                    }
                    else
                    {
                        oceanFloor = CalculateXChange(vectorOne, vectorTwo, oceanFloor);
                    }
                }
                else if (vectorOne.Item2 != vectorTwo.Item2 && vectorOne.Item1 == vectorTwo.Item1)
                {
                    if (vectorTwo.Item2 > vectorOne.Item2)
                    {
                        oceanFloor = CalculateYChange(vectorTwo, vectorOne, oceanFloor);
                    }
                    else
                    {
                        oceanFloor = CalculateYChange(vectorOne, vectorTwo, oceanFloor);
                    }
                }
            }

            foreach (List<int> row in oceanFloor)
            {
                foreach (int column in row)
                {
                    if (column > 1)
                    {
                        overlap++;
                    }
                }
            }

            return overlap;
        }

        public static int CalculateVentOverlapFull(List<string> coordinatesList)
        {
            List<List<Tuple<int, int>>> coordinatesTuples = coordinatesList.Select(str => str.Split(" -> ")
                                    .Select(coords => new Tuple<int, int>(int.Parse(coords.Split(",")[0]), int.Parse(coords.Split(",")[1]))).ToList()).ToList();
            List<List<int>> oceanFloor = DetermineFloorSize(coordinatesTuples);
            int overlap = 0;

            for (int index = 0; index < coordinatesTuples.Count; index++)
            {
                var vectorOne = coordinatesTuples[index][0];
                var vectorTwo = coordinatesTuples[index][1];
                oceanFloor = DetermineChange(vectorOne, vectorTwo, oceanFloor);
            }

            foreach (List<int> row in oceanFloor)
            {
                foreach (int column in row)
                {
                    if (column > 1)
                    {
                        overlap++;
                    }
                }
            }

            return overlap;
        }

        private static List<List<int>> DetermineFloorSize(List<List<Tuple<int, int>>> coordinatesList)
        {
            List<List<int>> floorSize = new List<List<int>>();
            int maxX = 0;
            int maxY = 0;

            for (int index = 0; index < coordinatesList.Count; index++)
            {
                for (int vector = 0; vector < 2; vector++)
                {
                    if (coordinatesList[index][vector].Item1 > maxX)
                    {
                        maxX = coordinatesList[index][vector].Item1;
                    }

                    if (coordinatesList[index][vector].Item2 > maxY)
                    {
                        maxY = coordinatesList[index][vector].Item2;
                    }
                }
            }

            for (int i = 0; i < maxY+1; i++)
            {
                floorSize.Add(new List<int>(new int[maxX+1]) );
            }

            return floorSize;
        }

        private static List<List<int>> CalculateXChange(Tuple<int, int> firstVector, Tuple<int, int> secondVector, List<List<int>> oceanFloor)
        {
            for (int column = secondVector.Item1; column <= firstVector.Item1; column++)
            {
                oceanFloor[firstVector.Item2][column]++;
            }

            return oceanFloor;
        }

        private static List<List<int>> CalculateYChange(Tuple<int, int> firstVector, Tuple<int, int> secondVector, List<List<int>> oceanFloor)
        {
            for (int row = secondVector.Item2; row <= firstVector.Item2; row++)
            {
                oceanFloor[row][firstVector.Item1]++;
            }

            return oceanFloor;
        }

        private static List<List<int>> DetermineChange(Tuple<int, int> vectorOne, Tuple<int, int> vectorTwo, List<List<int>> oceanFloor)
        {
            if (vectorOne.Item1 > vectorTwo.Item1)
            {
                if (vectorOne.Item2 < vectorTwo.Item2)
                {
                   oceanFloor = InputNegativeRow(vectorOne, vectorTwo, oceanFloor);
                }
                else if (vectorOne.Item2 > vectorTwo.Item2)
                {
                   oceanFloor = InputPositiveBoth(vectorOne, vectorTwo, oceanFloor);
                }
                else
                {
                    oceanFloor = CalculateXChange(vectorOne, vectorTwo, oceanFloor);
                }
            } 
            else if (vectorOne.Item1 < vectorTwo.Item1)
            {
                if (vectorOne.Item2 < vectorTwo.Item2)
                {
                   oceanFloor = InputNegativeBoth(vectorOne, vectorTwo, oceanFloor);
                }
                else if (vectorOne.Item2 > vectorTwo.Item2)
                {
                   oceanFloor = InputNegativeColumn(vectorOne, vectorTwo, oceanFloor);
                }
                else
                {
                    oceanFloor = CalculateXChange(vectorTwo, vectorOne, oceanFloor);
                }
            }
            else
            {
                if (vectorOne.Item2 > vectorTwo.Item2)
                {
                    oceanFloor = CalculateYChange(vectorOne, vectorTwo, oceanFloor);
                }
                else
                {
                    oceanFloor = CalculateYChange(vectorTwo, vectorOne, oceanFloor);
                }
            }

            return oceanFloor;
        }

        private static List<List<int>> InputNegativeRow(Tuple<int, int> firstVector, Tuple<int, int> secondVector, List<List<int>> oceanFloor)
        {
            for (int column = secondVector.Item1; column <= firstVector.Item1; column++)
            {
                for (int row = secondVector.Item2; row >= firstVector.Item2; row--)
                {
                    oceanFloor[row][column]++;
                    column++;
                }
            }

            return oceanFloor;
        }

        private static List<List<int>> InputNegativeBoth(Tuple<int, int> firstVector, Tuple<int, int> secondVector, List<List<int>> oceanFloor)
        {
            for (int column = secondVector.Item1; column >= firstVector.Item1; column--)
            {
                for (int row = secondVector.Item2; row >= firstVector.Item2; row--)
                {
                    oceanFloor[row][column]++;
                    column--;
                }
            }

            return oceanFloor;
        }

        private static List<List<int>> InputPositiveBoth(Tuple<int, int> firstVector, Tuple<int, int> secondVector, List<List<int>> oceanFloor)
        {
            for (int column = secondVector.Item1; column <= firstVector.Item1; column++)
            {
                for (int row = secondVector.Item2; row <= firstVector.Item2; row++)
                {
                    oceanFloor[row][column]++;
                    column++;
                }
            }

            return oceanFloor;
        }

        private static List<List<int>> InputNegativeColumn(Tuple<int, int> firstVector, Tuple<int, int> secondVector, List<List<int>> oceanFloor)
        {
            for (int column = secondVector.Item1; column >= firstVector.Item1; column--)
            {
                for (int row = secondVector.Item2; row <= firstVector.Item2; row++)
                {
                    oceanFloor[row][column]++;
                    column--;
                }
            }

            return oceanFloor;
        }
    }
}
