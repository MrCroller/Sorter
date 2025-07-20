using System;
using UnityEngine;

namespace Sorter.Types
{
    [Serializable]
    public struct Range<T> where T : IComparable<T>
    {
        [Min(0)]
        public T min;
        [Min(0)]
        public T max;

        public void Validate()
        {
            if (min.CompareTo(max) > 0)
                min = max;
        }
    }
}