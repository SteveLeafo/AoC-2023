using System.Runtime.ConstrainedExecution;

namespace Advent_of__Code_1
{
    internal class AoC_1
    {
        static int asciiZero = 48;

        static string[] digits = new string[]
        {
            "zero",
            "one",
            "two",
            "three",
            "four",
            "five",
            "six",
            "seven",
            "eight",
            "nine",
            "0",
            "1",
            "2",
            "3",
            "4",
            "5",
            "6",
            "7",
            "8",
            "9"
        };

        static void Main(string[] args)
        {
            int sum = 0;
            foreach (string line in File.ReadAllLines(@"C:\Games\aoc1.txt"))
            {
                sum += FirstDigit(line) * 10 + LastDigit(line);
            }
            Console.WriteLine(sum);

            sum = 0;
            foreach (string line in File.ReadAllLines(@"C:\Games\aoc2.txt"))
            {
                sum += GetDigit(line, true) * 10 + GetDigit(line, false);
            }

            Console.WriteLine(sum);

            Console.ReadKey();
        }

        static int FirstDigit(string haystack)
        {
            return haystack.SkipWhile(c => !char.IsDigit(c)).Take(1).First() - asciiZero;
        }

        static int LastDigit(string haystack)
        {
            for (int i = haystack.Length - 1; i >= 0; i--)
            {
                if (char.IsDigit(haystack[i]))
                {
                    return haystack[i] - asciiZero;
                }
            }
            throw new Exception();
        }

        static int GetDigit(string haystack, bool forwards)
        {
            int pos = forwards ? int.MaxValue : int.MinValue;
            int digit = -1;

            for (int slot = 0; slot < digits.Length; ++slot)
            {
                int i = forwards ? haystack.IndexOf(digits[slot]) : haystack.LastIndexOf(digits[slot]);

                if (i >= 0)
                {
                    if (forwards)
                    {
                        if (i < pos)
                        {
                            digit = slot;
                            pos = i;
                        }
                    }
                    else
                    {
                        if (i > pos)
                        {
                            digit = slot;
                            pos = i;
                        }
                    }
                }
            }

            if (digit > 9)
            {
                return digit - 10;
            }

            return digit;
        }
    }
}