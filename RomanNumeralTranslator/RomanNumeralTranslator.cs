using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace RomanNumeralTranslator
{
    public static class RomanNumeralTranslator
    {
        public const int MAX_NUMERAL = 4999;
        private static Dictionary<string, int> numeralValues = new Dictionary<string, int>
        {
            { "M"   , 1000 },
            { "CM"  , 900 },
            { "D"   , 500 },
            { "CD"  , 400 },
            { "C"   , 100 },
            { "XC"  , 90 },
            { "L"   , 50 },
            { "XL"  , 40 },
            { "X"   , 10 },
            { "IX"  , 9 },
            { "V"   , 5 },
            { "IV"  , 4 },
            { "I"   , 1 }
        };

        public static int RomanNumeralToInt(string n)
        {
            Regex rgx = new Regex(@"^M{0,4}(CM|CD|D?C{0,3})(XC|XL|L?X{0,3})(IX|IV|V?I{0,3})$");
            if (!rgx.IsMatch(n))
                throw (new Exception());

            int result = 0;

            for (int i = 0; i <= n.Length - 1; ++i)
            {
                int last = i > 0 ? numeralValues[n[i - 1].ToString()] : 0;
                int current = numeralValues[n[i].ToString()];

                if (current > last)
                {
                    result -= last;
                    result += current - last;
                }
                else
                {
                    result += current;
                }
            }

            return result;
        }

        public static string IntToRomanNumeral(int n)
        {
            string result = "";

            // 4999 is the maximum convertable int
            if (n > MAX_NUMERAL)
                throw (new ArgumentOutOfRangeException());


            foreach (KeyValuePair<string, int> mapping in numeralValues)
            {
                while (mapping.Value <= n)
                {
                    result += mapping.Key;
                    n -= mapping.Value;
                }
            }

            return result;
        }
    }
}
