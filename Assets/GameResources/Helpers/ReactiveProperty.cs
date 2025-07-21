using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sorter
{
    public class ReactiveProperty<T> : IReadOnlyReactiveProperty<T>
    {
        public T Value => _value;

        private T _value;
        public event Action<T> OnChanged;

        public ReactiveProperty(T initialValue = default)
        {
            _value = initialValue;
        }

        public void SetValue(T newValue)
        {
            _value = newValue;
            OnChanged?.Invoke(_value);
        }

        public static implicit operator T(ReactiveProperty<T> observable)
        {
            return observable._value;
        }

        public override string ToString()
        {
            return Value.ToString();
        }
    }
}
