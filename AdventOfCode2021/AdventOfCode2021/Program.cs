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
            List<int> day1Test = ChangeListToInt(ReadText("Day1Test"));
            List<int> day1Puzzle = ChangeListToInt(ReadText("Day1Puzzle"));
            Console.WriteLine(Day1.Puzzle1(day1Test));
            Console.WriteLine(Day1.Puzzle1(day1Puzzle));
            Console.WriteLine("\nPuzzle 2");
            Console.WriteLine(Day1.Puzzle2(day1Test));
            Console.WriteLine(Day1.Puzzle2(day1Puzzle));
            Console.WriteLine("\nDay 2 \nPuzzle 3");
            Console.WriteLine(Day2.CalculateFinalPosition(ReadText("Day2Test")));
            Console.WriteLine(Day2.CalculateFinalPosition(ReadText("Day2Puzzle")));
            Console.WriteLine("\nPuzzle 4");
            Console.WriteLine(Day2.CalculateActualFinalPosition(ReadText("Day2Test")));
            Console.WriteLine(Day2.CalculateActualFinalPosition(ReadText("Day2Puzzle")));
            Console.WriteLine("\nDay 3 \nPuzzle 5");
            Console.WriteLine(Day3.DiagnosticReport(ReadText("Day3Test")));
            Console.WriteLine(Day3.DiagnosticReport(ReadText("Day3Puzzle")));
            Console.WriteLine("\nPuzzle 6");
            Console.WriteLine(Day3.TrueDiagnosticReport(ReadText("Day3Test")));
            Console.WriteLine(Day3.TrueDiagnosticReport(ReadText("Day3Puzzle")));
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
