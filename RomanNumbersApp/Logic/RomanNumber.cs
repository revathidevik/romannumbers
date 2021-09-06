using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RomanNumbersApp.Logic
{
    public class RomanNumber : IRomanNumInterface
    {
        public Dictionary<char, int> CharValues = null;

        // Convert Roman numerals to an integer.
        public int RomanToInt(string roman)
        {
            try
            {
                // Initialize the letter map.
                if (CharValues == null)
                {
                    CharValues = new Dictionary<char, int>();
                    CharValues.Add('I', 1);
                    CharValues.Add('V', 5);
                    CharValues.Add('X', 10);
                    CharValues.Add('L', 50);
                    CharValues.Add('C', 100);
                    CharValues.Add('D', 500);
                    CharValues.Add('M', 1000);
                }

                if (roman.Length == 0) return 0;
                roman = roman.ToUpper();

                // See if the number begins with (.
                if (roman[0] == '(')
                {
                    // Find the closing parenthesis.
                    int pos = roman.LastIndexOf(')');

                    // Get the value inside the parentheses.
                    string part1 = roman.Substring(1, pos - 1);
                    string part2 = roman.Substring(pos + 1);
                    return 1000 * RomanToInt(part1) + RomanToInt(part2);
                }

                // The number doesn't begin with (.
                // Convert the letters' values.
                int total = 0;
                int last_value = 0;
                for (int i = roman.Length - 1; i >= 0; i--)
                {
                    int new_value = CharValues[roman[i]];

                    // See if we should add or subtract.
                    if (new_value < last_value)
                        total -= new_value;
                    else
                    {
                        total += new_value;
                        last_value = new_value;
                    }
                }
                return total;
            }
            catch(Exception ex)
            { throw ex; }

            // Return the result.
           
        }

        public string RomanNumeralFrom(int number)
        {
            return
                new string('I', number)
                    .Replace(new string('I', 1000), "M")
                    .Replace(new string('I', 900), "CM")
                    .Replace(new string('I', 500), "D")
                    .Replace(new string('I', 400), "CD")
                    .Replace(new string('I', 100), "C")
                    .Replace(new string('I', 90), "XC")
                    .Replace(new string('I', 50), "L")
                    .Replace(new string('I', 40), "XL")
                    .Replace(new string('I', 10), "X")
                    .Replace(new string('I', 9), "IX")
                    .Replace(new string('I', 5), "V")
                    .Replace(new string('I', 4), "IV");
        }
    }
}
