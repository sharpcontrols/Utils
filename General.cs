using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

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

        public static string Number2Text(int numberInCents, string? locale = null)
        {
            throw new NotImplementedException();
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
