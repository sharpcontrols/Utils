using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace SharpControls.Utils.Extensions
{
    public static partial class StringExtensions
    {
        public static string ReplaceFirst(this string input, string oldValue, string newValue)
        {
            int position = input.IndexOf(oldValue);
            if (position < 0)
            {
                return input;
            }
            input = string.Concat(input.AsSpan(0, position), newValue, input.AsSpan(position + oldValue.Length));
            return new string(input);
        }

        public static bool Like(this string input, string other)
        {
            return new Regex(@"\A" + LikeRegex().Replace(other, ch => @"\" + ch).Replace('_', '.').Replace("%", ".*") + @"\z", RegexOptions.Singleline).IsMatch(input);
        }

        [GeneratedRegex(@"\.|\$|\^|\{|\[|\(|\||\)|\*|\+|\?|\\")]
        private static partial Regex LikeRegex();
    }
}
