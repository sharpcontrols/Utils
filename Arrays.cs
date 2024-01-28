namespace SharpControls.Utils
{
    public static class Arrays
    {
        /// <summary>
        /// Removes item inside array and overwrites the array
        /// </summary>
        /// <typeparam name="T">Type of the items inside of the array</typeparam>
        /// <param name="array">The array which will be overwritten</param>
        /// <param name="item">The item to remove</param>
        public static void Remove<T>(ref T[] array, T item)
        {
            List<T> lst = [];
            foreach(T arrayItem in array)
            {
                if(item!.Equals(arrayItem)) {
                    lst.Add(arrayItem);
                }
            }
            array = [.. lst];
        }

        /// <summary>
        /// Checks if the array has duplicate values inside it
        /// </summary>
        /// <typeparam name="T">The type of the items inside of the array</typeparam>
        /// <param name="array">The array itself</param>
        /// <returns></returns>
        public static bool HasDuplicates<T>(T[] array)
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
        public static T[] GetDuplicates<T>(T[] array, bool escapeIfFound = false)
        {
            List<T> vals = [];
            List<T> dupes = [];
            foreach(T item in array)
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
