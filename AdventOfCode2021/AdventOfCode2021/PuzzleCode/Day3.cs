using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode2021.PuzzleCode
{
    public class Day3
    {
        public static double DiagnosticReport(List<string> report)
        {
            List<int> commonBitsZero = new List<int>();
            List<int> commonBitsOne = new List<int>();
            int lineLength = report[0].Length;
            StringBuilder gammaBinary = new StringBuilder();
            StringBuilder epsilonBinary = new StringBuilder();
            double gammaRate = 0;
            double epsilonRate = 0;

            for (int i = 0; i < lineLength; i++)
            {
                commonBitsZero.Add(0);
                commonBitsOne.Add(0);
            }

            foreach (string line in report)
            {
                for (int i = 0; i < lineLength; i++)
                {
                    switch (line[i])
                    {
                        case '0':
                            commonBitsZero[i]++;
                            break;
                        case '1':
                            commonBitsOne[i]++;
                            break;
                    }
                }
            }

            for (int i = 0; i < lineLength; i++)
            {
                if (commonBitsZero[i] > commonBitsOne[i])
                {
                    gammaBinary.Append("0");
                    epsilonBinary.Append("1");
                }
                else
                {
                    gammaBinary.Append("1");
                    epsilonBinary.Append("0");
                }
            }

            gammaRate = ConvertToDouble(gammaBinary.ToString());
            epsilonRate = ConvertToDouble(epsilonBinary.ToString());

            return gammaRate * epsilonRate;
        }

        public static double TrueDiagnosticReport(List<string> report)
        {
            List<string> oxygenList = report;
            List<string> scrubberList = report;
            double oxygenRating = 0;
            double scrubberRating = 0;
            int lineLength = report[0].Length;

            for (int i = 0; i < lineLength; i++)
            {
                if (oxygenList.Count == 2)
                {
                    oxygenList = oxygenList.Where(str => str[lineLength - 1] == '1').ToList();
                    break;
                }
                if (oxygenList.Count == 1)
                {
                    break;
                }

                oxygenList = oxygenList.Where(str => str[i] == MostCommonBit(oxygenList, i, true)).ToList();
            }

            for (int i = 0; i < lineLength; i++)
            {
                if (scrubberList.Count == 2)
                {
                    scrubberList = scrubberList.Where(str => str[lineLength - 1] == '0').ToList();
                    break;
                }
                if (scrubberList.Count == 1)
                {
                    break;
                }

                scrubberList = scrubberList.Where(str => str[i] == MostCommonBit(scrubberList, i, false)).ToList();
            }

            oxygenRating = ConvertToDouble(oxygenList[0]);
            scrubberRating = ConvertToDouble(scrubberList[0]);

            return oxygenRating * scrubberRating;
        }


        private static double ConvertToDouble(string binary)
        {
            double doubleBinary = 0;
            char[] reverseString = binary.ToCharArray();
            Array.Reverse(reverseString);
            string reverseBinary = new string(reverseString);

            for (int i = 0; i < reverseBinary.Length; i++)
            {
                if (reverseBinary[i] == '1')
                {
                    doubleBinary += Math.Pow(2, i);
                }
            }

            return doubleBinary;
        }

        private static char MostCommonBit(List<string> binaryLines, int index, bool oxygen)
        {
            char bestBit;
            int commonBitsZero = 0;
            int commonBitsOne = 0;

            foreach (string line in binaryLines)
            {
                switch (line[index])
                {
                    case '0':
                        commonBitsZero++;
                        break;
                    case '1':
                        commonBitsOne++;
                        break;
                }
            }

            if (commonBitsOne == commonBitsZero)
            {
                return oxygen ? '1' : '0';
            }

            bestBit = commonBitsOne > commonBitsZero ? '1' : '0';

            if (!oxygen)
            {
                return bestBit == '0' ? '1' : '0';
            }

            return bestBit;
        }
    }
}
