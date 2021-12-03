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
            List<int> day1Test1 = ChangeListToInt(ReadText("Day1Test1"));
            List<int> day1Puzzle1 = ChangeListToInt(ReadText("Day1Puzzle1"));
            Console.WriteLine(Day1.Puzzle1(day1Test1));
            Console.WriteLine(Day1.Puzzle1(day1Puzzle1));
            Console.WriteLine(Day1.Puzzle2(day1Test1));
            Console.WriteLine(Day1.Puzzle2(day1Puzzle1));
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
