using System;
using UnityEngine;

namespace Sorter.Types
{
    public static class RangeUtils
    {
        public static T GetRandom<T>(this Range<T> range) where T : IComparable<T>
        {
            dynamic min = range.min;
            dynamic max = range.max;

            if (typeof(T) == typeof(int))
                return (T)(object)UnityEngine.Random.Range((int)min, (int)max + 1);
            else if (typeof(T) == typeof(float))
                return (T)(object)UnityEngine.Random.Range((float)min, (float)max);
            else if (typeof(T) == typeof(double))
                return (T)(object)(UnityEngine.Random.Range((float)min, (float)max));
            else if (typeof(T) == typeof(long))
                return (T)(object)(long)UnityEngine.Random.Range((int)min, (int)Mathf.Min(int.MaxValue, (int)max + 1));
            else if (typeof(T) == typeof(ushort))
                return (T)(object)(ushort)UnityEngine.Random.Range((int)min, (int)max + 1);
            else
                throw new NotSupportedException($"Random for type {typeof(T)} is not supported.");
        }
    }
}
