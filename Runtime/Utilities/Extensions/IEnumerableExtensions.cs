using System.Collections.Generic;
using UnityEngine;

namespace Dwarf.Utilities.Extensions
{
    public static class IEnumerableExtensions
    {
        /// <summary>
        /// Shuffle an array in place using the Fisher-Yates algorithm
        /// </summary>
        /// <param name="array"></param>
        /// <typeparam name="T"></typeparam>
        public static void Shuffle<T>(this IList<T> array)
        {
            // Loop through the array from the end to the beginning
            for (int i = array.Count - 1; i > 0; i--)
            {
                // Generate a random index between 0 and i (inclusive)
                int j = Random.Range(0, i + 1);

                // Swap the values at indices i and j
                (array[j], array[i]) = (array[i], array[j]);
            }
        }
    }
}
