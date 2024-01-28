using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharpControls.Utils
{
    public static class Blogging
    {
        /// <summary>
        /// Calculates the estimated reading time of a text in minutes, based on the words per minute
        /// </summary>
        /// <param name="text">The text to read</param>
        /// <param name="wordsPerMinute">The estimated times of word read per minute</param>
        /// <returns>Estimated reading time in rounded minutes</returns>
        public static int EstimatedReadingTime(string text, int wordsPerMinute = 250)
        {
            int wordsCount = text.Length;
            return (int)MathF.Round(wordsCount / wordsPerMinute);
        }
    }
}
