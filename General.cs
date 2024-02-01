using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace SharpControls.Utils
{
    public static class General
    {
        /// <summary>
        /// Counts the amount of numbers inside a number
        /// </summary>
        /// <param name="number">The number</param>
        /// <returns>The amount of numbers inside the number</returns>
        public static int CountNumbers(int number)
        {
            var numStr = number.ToString();
            return numStr.Length;
        }

        public static int CalculateDaysInMonth(int fromDay, int toDay, int month, int year)
        {
            throw new NotImplementedException();
        }

        public static string NumberToWords(int number, string locale = "en")
        {
            if(locale != "en")
            {
                throw new Exception("Locale " + locale + " is not supported.");
            }
            if (number == 0)
                return "zero";

            if (number < 0)
                return "minus " + NumberToWords(Math.Abs(number));
            string words = "";

            if ((number / 1000000) > 0)
            {
                words += NumberToWords(number / 1000000) + " million ";
                number %= 1000000;
            }

            if ((number / 1000) > 0)
            {
                words += NumberToWords(number / 1000) + " thousand ";
                number %= 1000;
            }

            if ((number / 100) > 0)
            {
                words += NumberToWords(number / 100) + " hundred ";
                number %= 100;
            }

            if (number > 0)
            {
                if (words != "")
                    words += "and ";

                var unitsMap = new[] { "zero", "one", "two", "three", "four", "five", "six", "seven", "eight", "nine", "ten", "eleven", "twelve", "thirteen", "fourteen", "fifteen", "sixteen", "seventeen", "eighteen", "nineteen" };
                var tensMap = new[] { "zero", "ten", "twenty", "thirty", "forty", "fifty", "sixty", "seventy", "eighty", "ninety" };

                if (number < 20)
                    words += unitsMap[number];
                else
                {
                    words += tensMap[number / 10];
                    if ((number % 10) > 0)
                        words += "-" + unitsMap[number % 10];
                }
            }

            return words;
        }

        /// <summary>
        /// Adds leading zeros to a integer value like ID etc.
        /// </summary>
        /// <param name="value">The value to add the leading zeros</param>
        /// <param name="length">The maximum lenght of the value</param>
        /// <param name="isMax">If set to true an exception will be thrown if lenght of return string is bigger than lenght param</param>
        /// <returns></returns>
        public static string LeadingZeros(int value, int length, bool isMax = false)
        {
            string valueString = value.ToString();
            int valueLength = valueString.Length;
            if(valueLength > length && isMax)
            {
                throw new ArgumentOutOfRangeException("Value has more numbers than max length permits!");
            }
            if (valueLength >= length)
            {
                return valueString;
            }

            char[] valueArr = valueString.ToCharArray();

            var diff = length - valueLength;
            string newValue = "";
            for(int i = 0; i < length; i++)
            {
                if(i < diff)
                {
                    newValue += "0";
                }
                else
                {
                    newValue += valueArr[i - diff];
                }
            }
            return newValue;
        }
    }
}
