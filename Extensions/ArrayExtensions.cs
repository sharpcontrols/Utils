using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharpControls.Utils.Extensions
{
    public static class ArrayExtensions
    {
        /// <summary>
        /// Removes item inside array and returns a new array
        /// </summary>
        /// <typeparam name="T">Type of the items inside of the array</typeparam>
        /// <param name="array">The array which will be overwritten</param>
        /// <param name="item">The item to remove</param>
        public static T[] Remove<T>(this T[] array, T item)
        {
            List<T> lst = [];
            foreach (T arrayItem in array)
            {
                if (item!.Equals(arrayItem))
                {
                    lst.Add(arrayItem);
                }
            }
            return [.. lst];
        }

        /// <summary>
        /// Checks if the array has duplicate values inside it
        /// </summary>
        /// <typeparam name="T">The type of the items inside of the array</typeparam>
        /// <param name="array">The array itself</param>
        /// <returns></returns>
        public static bool HasDuplicates<T>(this T[] array)
        {
            return GetDuplicates(array, true).Length > 0;
        }

        /// <summary>
        /// Returns all duplicate values inside the array as new array
        /// </summary>
        /// <typeparam name="T">The type of the items inside of the array</typeparam>
        /// <param name="array">The array itself</param>
        /// <param name="escapeIfFound">Escape and return the list as soon as one item is found</param>
        /// <returns></returns>
        public static T[] GetDuplicates<T>(this T[] array, bool escapeIfFound = false)
        {
            List<T> vals = [];
            List<T> dupes = [];
            foreach (T item in array)
            {
                if (vals.Contains(item) && !dupes.Contains(item))
                {
                    dupes.Add(item);
                    if (escapeIfFound)
                    {
                        return [.. dupes];
                    }
                }
                vals.Add(item);
            }
            return [.. dupes];
        }
    }
}
