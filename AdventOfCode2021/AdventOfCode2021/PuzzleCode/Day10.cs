using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode2021.PuzzleCode
{
    public class Day10
    {
        public static int BracketsUponBrackets(List<string> lines)
        {
            Dictionary<char, int> scoring = new Dictionary<char, int>()
            {
                {')', 3},
                {']', 57},
                {'}', 1197},
                {'>', 25137},
            };
            Stack<char> leftChunks = new Stack<char>();
            int score = 0;
            foreach (string line in lines)
            {
                foreach (char c in line)
                {
                    if (c is '[' or '{' or '<' or '(')
                    {
                        leftChunks.Push(c);
                    }
                    else if (c is ']' or '}' or '>' or ')')
                    {
                        if (leftChunks.Peek() is '[')
                        {
                            if (c == ']')
                            {
                                leftChunks.Pop();
                                continue;
                            }
                            score += scoring[c];
                            break;
                        }
                        if (leftChunks.Peek() is '{')
                        {
                            if (c == '}')
                            {
                                leftChunks.Pop();
                                continue;
                            }
                            score += scoring[c];
                            break;
                        }
                        if (leftChunks.Peek() is '<')
                        {
                            if (c == '>')
                            {
                                leftChunks.Pop();
                                continue;
                            }
                            score += scoring[c];
                            break;
                        }
                        if (leftChunks.Peek() is '(')
                        {
                            if (c == ')')
                            {
                                leftChunks.Pop();
                                continue;
                            }
                            score += scoring[c];
                            break;
                        }
                    }
                }
            }

            return score;
        }

        public static long IncompleteBrackets(List<string> lines)
        {
            Dictionary<char, int> scoring = new Dictionary<char, int>()
            {
                {'(', 1},
                {'[', 2},
                {'{', 3},
                {'<', 4},
            };
            List<long> scores = new List<long>();
            Stack<char> leftChunks = new Stack<char>();
            foreach (string line in lines)
            {
                leftChunks.Clear();
                long score = 0;
                bool brokenLine = false;
                foreach (var c in line)
                {
                    if (c is '[' or '{' or '<' or '(')
                    {
                        leftChunks.Push(c);
                    }
                    else if (c is ']' or '}' or '>' or ')')
                    {
                        if (leftChunks.Peek() is '[')
                        {
                            if (c == ']')
                            {
                                leftChunks.Pop();
                                continue;
                            }
                            brokenLine = true;
                            break;
                        }

                        if (leftChunks.Peek() is '{')
                        {
                            if (c == '}')
                            {
                                leftChunks.Pop();
                                continue;
                            }
                            brokenLine = true;
                            break;
                        }

                        if (leftChunks.Peek() is '<')
                        {
                            if (c == '>')
                            {
                                leftChunks.Pop();
                                continue;
                            }
                            brokenLine = true;
                            break;
                        }
                        if (leftChunks.Peek() is '(')
                        {
                            if (c == ')')
                            {
                                leftChunks.Pop();
                                continue;
                            }
                            brokenLine = true;
                            break;
                        }
                    }
                }

                while (leftChunks.Count != 0 && !brokenLine)
                {
                    score *= 5;
                    score += scoring[leftChunks.Pop()];
                }

                if (leftChunks.Count == 0)
                {
                    scores.Add(score);
                }
            }

            scores.Sort();

            return scores[scores.Count/2];
        }
    }
}
