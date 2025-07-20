using System;
using System.Collections.Generic;
using Random = UnityEngine.Random;

namespace Sorter
{
    public static class RandomExtensions
    {
        public static TEnum GetRandomValue<TEnum>() where TEnum : Enum
        {
            var values = (TEnum[])Enum.GetValues(typeof(TEnum));
            int index = Random.Range(0, values.Length);
            return values[index];
        }

        public static T GetRandom<T>(this IList<T> list)
        {
            if (list == null || list.Count == 0)
                throw new InvalidOperationException("Cannot get random element from null or empty list.");

            int index = UnityEngine.Random.Range(0, list.Count);
            return list[index];
        }

        public static T GetRandom<T>(this T[] array)
        {
            if (array == null || array.Length == 0)
                throw new InvalidOperationException("Cannot get random element from null or empty array.");

            int index = UnityEngine.Random.Range(0, array.Length);
            return array[index];
        }
    }
}

