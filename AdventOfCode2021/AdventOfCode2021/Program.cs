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
            Console.WriteLine("\nDay 4 \nPuzzle 7");
            Console.WriteLine(Day4.BoardSetup(ReadText("Day4Test")));
            Console.WriteLine(Day4.BoardSetup(ReadText("Day4Puzzle")));
            Console.WriteLine("\nPuzzle 8");
            Console.WriteLine(Day4.CheckForLastBoard(ReadText("Day4Test")));
            Console.WriteLine(Day4.CheckForLastBoard(ReadText("Day4Puzzle")));
            Console.WriteLine("\nDay 5 \nPuzzle 9");
            Console.WriteLine(Day5.CalculateVentOverlap(ReadText("Day5Test")));
            Console.WriteLine(Day5.CalculateVentOverlap(ReadText("Day5Puzzle")));
            Console.WriteLine("\nPuzzle 10");
            Console.WriteLine(Day5.CalculateVentOverlapFull(ReadText("Day5Test")));
            Console.WriteLine(Day5.CalculateVentOverlapFull(ReadText("Day5Puzzle")));
            Console.WriteLine("\nDay 6 \nPuzzle 11");
            Console.WriteLine(Day6.CountLanternsSimple(ReadText("Day6Test")));
            Console.WriteLine(Day6.CountLanternsSimple(ReadText("Day6Puzzle")));
            Console.WriteLine("\nPuzzle 12");
            Console.WriteLine(Day6.CountLanternsEfficient(ReadText("Day6Test")));
            Console.WriteLine(Day6.CountLanternsEfficient(ReadText("Day6Puzzle")));
            Console.WriteLine("\nDay 7 \nPuzzle 13");
            Console.WriteLine(Day7.CalculateCrabSubs(ReadText("Day7Test")));
            Console.WriteLine(Day7.CalculateCrabSubs(ReadText("Day7Puzzle")));
            Console.WriteLine("\nPuzzle 14");
            Console.WriteLine(Day7.CalculateCrabSubsCorrectly(ReadText("Day7Test")));
            Console.WriteLine(Day7.CalculateCrabSubsCorrectly(ReadText("Day7Puzzle")));
            Console.WriteLine("\nDay 8 \nPuzzle 15");
            Console.WriteLine(Day8.FixSimpleClock(ReadText("Day8Test")));
            Console.WriteLine(Day8.FixSimpleClock(ReadText("Day8Puzzle")));
            Console.WriteLine("\nPuzzle 16");
            Console.WriteLine(Day8.FixComplexClock(ReadText("Day8Test")));
            Console.WriteLine(Day8.FixComplexClock(ReadText("Day8Puzzle")));
            Console.WriteLine("\nDay 9 \nPuzzle 17");
            Console.WriteLine(Day9.SumLowPoints(ReadText("Day9Test")));
            Console.WriteLine(Day9.SumLowPoints(ReadText("Day9Puzzle")));
            Console.WriteLine("\nPuzzle 18");
            Console.WriteLine(Day9.FindBasins(ReadText("Day9Test")));
            Console.WriteLine(Day9.FindBasins(ReadText("Day9Puzzle")));
            Console.WriteLine("\nDay 10 \nPuzzle 19");
            Console.WriteLine(Day10.BracketsUponBrackets(ReadText("Day10Test")));
            Console.WriteLine(Day10.BracketsUponBrackets(ReadText("Day10Puzzle")));
            Console.WriteLine("\nPuzzle 20");
            Console.WriteLine(Day10.IncompleteBrackets(ReadText("Day10Test")));
            Console.WriteLine(Day10.IncompleteBrackets(ReadText("Day10Puzzle")));
            Console.WriteLine("\nDay 11 \nPuzzle 21");
            Console.WriteLine(Day11.OctopusLights(ReadText("Day11Test")));
            Console.WriteLine(Day11.OctopusLights(ReadText("Day11Puzzle")));
            Console.WriteLine("\nPuzzle 22");
            Console.WriteLine(Day11.OctopusLightsSync(ReadText("Day11Test")));
            Console.WriteLine(Day11.OctopusLightsSync(ReadText("Day11Puzzle")));
            //Console.WriteLine("\nDay 12 \nPuzzle 23");
            //Console.WriteLine(Day11.OctopusLights(ReadText("Day12Test")));
            //Console.WriteLine(Day11.OctopusLights(ReadText("Day12Puzzle")));
            //Console.WriteLine("\nPuzzle 24");
            //Console.WriteLine(Day11.OctopusLightsSync(ReadText("Day11Test")));
            //Console.WriteLine(Day11.OctopusLightsSync(ReadText("Day11Puzzle")));
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
