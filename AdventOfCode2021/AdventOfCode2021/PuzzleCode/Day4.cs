using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode2021.PuzzleCode
{
    class Day4
    {
        public static int BoardSetup(List<string> bingoSetup)
        {
            List<string> numbers = bingoSetup[0].Split(',').ToList();
            List<List<List<string>>> boards = new List<List<List<string>>>();
            List<List<string>> board = new List<List<string>>();
            int bingoMath = 0;

            for (int i = 2; i < bingoSetup.Count; i++)
            {
                if (bingoSetup[i] != string.Empty)
                {
                    board.Add(bingoSetup[i].Split(" ").AsEnumerable().Where(x => x != string.Empty).ToList());
                }
                else
                {
                    boards.Add(board);
                    board = new List<List<string>>();
                }
            }
            boards.Add(board);

            foreach (string number in numbers)
            {
                foreach (List<List<string>> currentBoard in boards)
                {
                    bingoMath = CheckForBingo(currentBoard, number);
                    if (bingoMath != 0)
                    {
                        return bingoMath;
                    }
                }
            }

            return 0;
        }

        public static int CheckForLastBoard(List<string> bingoSetup)
        {
            List<string> numbers = bingoSetup[0].Split(',').ToList();
            List<List<List<string>>> boards = new List<List<List<string>>>();
            List<List<string>> board = new List<List<string>>();
            int bingoMath = 0;

            for (int i = 2; i < bingoSetup.Count; i++)
            {
                if (bingoSetup[i] != string.Empty)
                {
                    board.Add(bingoSetup[i].Split(" ").AsEnumerable().Where(x => x != string.Empty).ToList());
                }
                else
                {
                    boards.Add(board);
                    board = new List<List<string>>();
                }
            }
            boards.Add(board);

            foreach (string number in numbers)
            {
                for (var index = 0; index < boards.Count; index++)
                {
                    if (RemoveForBingo(boards[index], number))
                    {
                        if (boards.Count == 1)
                        {
                            return CalculateBoard(boards[0], number);
                        }
                        boards.RemoveAt(index);
                        index--;
                    }
                }
            }

            return 0;
        }

        public static int CheckForBingo(List<List<string>> board, string number)
        {
            for (int row = 0; row < 5; row++)
            {
                for (int column = 0; column < 5; column++)
                {
                    if (board[row][column] == number)
                    {
                        board[row][column] += "x";
                    }

                    if (!board[0][column].EndsWith("x")) continue;
                    if (!board[1][column].EndsWith("x")) continue;
                    if (!board[2][column].EndsWith("x")) continue;
                    if (!board[3][column].EndsWith("x")) continue;
                    if (board[4][column].EndsWith("x"))
                    {
                        return CalculateBoard(board, number);
                    }
                }
                if (!board[row][0].EndsWith("x")) continue;
                if (!board[row][1].EndsWith("x")) continue;
                if (!board[row][2].EndsWith("x")) continue;
                if (!board[row][3].EndsWith("x")) continue;
                if (board[row][4].EndsWith("x"))
                {
                    return CalculateBoard(board, number);
                }
            }

            return 0;
        }

        public static bool RemoveForBingo(List<List<string>> board, string number)
        {
            for (int row = 0; row < 5; row++)
            {
                for (int column = 0; column < 5; column++)
                {
                    if (board[row][column] == number)
                    {
                        board[row][column] += "x";
                    }

                    if (!board[0][column].EndsWith("x")) continue;
                    if (!board[1][column].EndsWith("x")) continue;
                    if (!board[2][column].EndsWith("x")) continue;
                    if (!board[3][column].EndsWith("x")) continue;
                    if (board[4][column].EndsWith("x"))
                    {
                        return true;
                    }
                }
                if (!board[row][0].EndsWith("x")) continue;
                if (!board[row][1].EndsWith("x")) continue;
                if (!board[row][2].EndsWith("x")) continue;
                if (!board[row][3].EndsWith("x")) continue;
                if (board[row][4].EndsWith("x"))
                {
                    return true;
                }
            }

            return false;
        }

        private static int CalculateBoard(List<List<string>> board, string number)
        {
            int finalNumber = 0;

            for (int row = 0; row < 5; row++)
            {
                for (int column = 0; column < 5; column++)
                {
                    if (!board[row][column].EndsWith("x"))
                    {
                        finalNumber += int.Parse(board[row][column]);
                    }
                }
            }

            return finalNumber * int.Parse(number);
        }
    }
}
