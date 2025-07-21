using System;

namespace Sorter
{
    public interface IReadOnlyReactiveProperty<T>
    {
        T Value { get; }
        event Action<T> OnChanged;
    }
}