using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace AdventOfCode2021.PuzzleCode
{
    public class Day8
    {
        public static int FixSimpleClock(List<string> values)
        {
            int counter = 0;
            foreach (string line in values)
            {
                List<string> output = line.Split('|')[1].Split(' ').ToList();
                foreach (string str in output)
                {
                    if (str.Length is 2 or 3 or 4 or 7)
                    {
                        counter++;
                    }
                }
            }

            return counter;
        }

        public static int FixComplexClock(List<string> values)
        {
            List<string> findSegment;
            List<string> patterns;
            List<string> output;
            int counter = 0;
            foreach (string line in values)
            {
                patterns = line.Split('|')[0].Split(' ').ToList();
                findSegment = FindPattern(patterns);
                output = line.Split('|')[1].Split(' ').ToList();
                counter += DecodeOutput(output, findSegment);
            }

            return counter;
        }

        private static List<string> FindPattern(List<string> patterns)
        {
            List<string> findSegment = new List<string>();

            // Find singular a and combined c and f through comparing 7 and 1
            string one = patterns.Where(s => s.Length == 2).ToList()[0];
            string two = "";
            string three = "";
            string four = patterns.Where(s => s.Length == 4).ToList()[0];
            string five = "";
            string six = "";
            string seven = patterns.Where(s => s.Length == 3).ToList()[0];
            List<string> fiveDigits = patterns.Where(s => s.Length == 5).ToList();
            string a = RemoveLetters(seven, one);

            // Find combined b and d through comparing 4 and 1
            string bd = RemoveLetters(four, one);

            // Find singular segments g, c, and f through comparing segment a, 4, and 5
            five = fiveDigits.Where(digit => digit.Contains(bd[0]) && digit.Contains(bd[1])).ToList()[0];
            fiveDigits.Remove(five);
            three = fiveDigits.Where(digit => digit.Contains(one[0]) && digit.Contains(one[1])).ToList()[0];
            fiveDigits.Remove(three);
            two = fiveDigits[0];

            string g = RemoveLetters(five, four + a);
            string e = RemoveLetters(two, three);
            string c = RemoveLetters(two, five + bd + e);
            string f = RemoveLetters(one, c);
            string d = RemoveLetters(two, seven + e + g);
            string b = RemoveLetters(bd, d);

            findSegment.Add(a);
            findSegment.Add(b);
            findSegment.Add(c);
            findSegment.Add(d);
            findSegment.Add(e);
            findSegment.Add(f);
            findSegment.Add(g);

            return findSegment;
        }

        private static string RemoveLetters(string fullString, string removalString)
        {
            string str = fullString;
            foreach (char c in removalString)
            {
                str = str.Replace(c.ToString(), "");
            }

            return str;
        }

        private static int DecodeOutput(List<string> output, List<string> findSegment)
        {
            StringBuilder stringNum = new StringBuilder();
            foreach (string number in output)
            {
                if (number.Length == 2)
                {
                    stringNum.Append("1");
                }
                else if (number.Length == 3)
                {
                    stringNum.Append("7");
                }
                else if (number.Length == 4)
                {
                    stringNum.Append("4");
                }
                else if (number.Length == 5)
                {
                    if (number.Contains(findSegment[1]))
                    {
                        stringNum.Append("5");
                    }
                    else if (number.Contains(findSegment[4]))
                    {
                        stringNum.Append("2");
                    }
                    else
                    {
                        stringNum.Append("3");
                    }
                }
                else if (number.Length == 6)
                {
                    if (number.Contains(findSegment[2]))
                    {
                        if (number.Contains(findSegment[4]))
                        {
                            stringNum.Append("0");
                        }
                        else
                        {
                            stringNum.Append("9");
                        }
                    }
                    else
                    {
                        stringNum.Append("6");
                    }
                }
                else if (number.Length == 7)
                {
                    stringNum.Append("8");
                }
            }
            return int.Parse(stringNum.ToString());
        }
    }
}