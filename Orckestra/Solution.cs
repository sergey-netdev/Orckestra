using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace Orckestra
{
    public class Solution
    {
        public static IEnumerable<string> ChangeDateFormat(IEnumerable<string> input)
        {
            if (input is null)
            {
                throw new ArgumentNullException(nameof(input));
            }

            return ChangeDateFormatInternal(input);
        }

        private static IEnumerable<string> ChangeDateFormatInternal(IEnumerable<string> input)
        {
            const string Pattern1 = @"\d{4}/\d{2}/\d{2}"; // YYYY/MM/DD
            const string Pattern2 = @"\d{2}/\d{2}/\d{4}"; // DD/MM/YYYY
            const string Pattern3 = @"\d{2}-\d{2}-\d{4}"; // MM-DD-YYYY

            foreach (string x in input)
            {
                if (Regex.IsMatch(x, $"{Pattern1}|{Pattern2}|{Pattern3}"))
                {
                    yield return x;
                }
            }
        }

        public static string SymbolicToOctal(string input)
        {
            if (input is null)
            {
                throw new ArgumentNullException(nameof(input));
            }

            if (input.Length != 9)
            {
                throw new ArgumentOutOfRangeException(nameof(input), input.Length, "The input length must be 9.");
            }

            char[] chars = input.ToCharArray();

            int b1 = BlockToOctal(chars, 0);
            int b2 = BlockToOctal(chars, 3);
            int b3 = BlockToOctal(chars, 6);

            return $"{b1}{b2}{b3}";

            int BlockToOctal(IReadOnlyList<char> block, int position)
            {
                int r1 = SymbolToOctal(block[position + 0]);
                int r2 = SymbolToOctal(block[position + 1]);
                int r3 = SymbolToOctal(block[position + 2]);

                return r1 + r2 + r3;
            }

            int SymbolToOctal(char symbol) =>
                symbol switch
                {
                    'r' => 4,
                    'w' => 2,
                    'x' => 1,
                    '-' => 0,
                    _ => throw new ArgumentException(message: "Invalid symbol.", paramName: nameof(symbol)),
                };
        }
    }
}
