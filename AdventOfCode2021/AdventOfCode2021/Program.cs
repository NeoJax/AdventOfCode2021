using System;
using System.Collections.Generic;
using System.Linq;
using AdventOfCode2021.PuzzleCode;

namespace AdventOfCode2021
{
    internal static class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Day 1 \nPuzzle 1");
            List<int> day1Test1 = ChangeListToInt(ReadText("Day1Test1"));
            List<int> day1Puzzle1 = ChangeListToInt(ReadText("Day1Puzzle1"));
            Console.WriteLine(Day1.Puzzle1(day1Test1));
            Console.WriteLine(Day1.Puzzle1(day1Puzzle1));
            Console.WriteLine("\nPuzzle 2");
            Console.WriteLine(Day1.Puzzle2(day1Test1));
            Console.WriteLine(Day1.Puzzle2(day1Puzzle1));
            Console.WriteLine("\nDay 2 \nPuzzle 3");
            Console.WriteLine(Day2.CalculateFinalPosition(ReadText("Day2Test1")));
            Console.WriteLine(Day2.CalculateFinalPosition(ReadText("Day2Puzzle1")));
            Console.WriteLine("\nPuzzle 4");
            Console.WriteLine(Day2.CalculateActualFinalPosition(ReadText("Day2Test1")));
            Console.WriteLine(Day2.CalculateActualFinalPosition(ReadText("Day2Puzzle1")));
        }

        public static List<string> ReadText(string puzzlePath)
        {
            List<string> input = System.IO.File.ReadAllLines(@"..\\..\\..\\PuzzleInput\\" + puzzlePath + ".txt").ToList();

            return input;
        }

        public static List<int> ChangeListToInt(List<string> stringList)
        {
            List<int> parsedList = new List<int>();

            foreach (string s in stringList)
            {
                parsedList.Add(Int32.Parse(s));
            }

            return parsedList;
        }
    }
}
