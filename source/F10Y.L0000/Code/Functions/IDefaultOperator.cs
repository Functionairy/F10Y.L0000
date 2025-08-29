using System;
using System.Collections.Generic;

using F10Y.T0002;


namespace F10Y.L0000
{
    [FunctionsMarker]
    public partial interface IDefaultOperator
    {
        /// <summary>
        /// If the value is not the default, then run the converter on the value.
        /// Otherwise return the default for the converted type.
        /// </summary>
        public T2 Convert<T1, T2>(
            T1 value,
            Func<T1, T2> converter)
        {
            var isDefault = this.Is_Default(value);

            var output = isDefault
                ? this.Get_Default<T2>()
                : converter(value)
                ;

            return output;
        }

        public IDefaultOperator<T> For<T>()
            => DefaultOperator<T>.Instance;

        public T Get_Default<T>()
        {
            T output = default;
            return output;
        }

        public bool Is_Default<T>(
            T value,
            IEqualityComparer<T> equalityComparer)
        {
            var output = equalityComparer.Equals(value, default);
            return output;
        }

        public bool Is_Default<T>(T value)
        {
            var equalityComparer = EqualityComparer<T>.Default;

            var output = this.Is_Default(
                value,
                equalityComparer);

            return output;
        }

        public bool Is_NotDefault<T>(T value)
        {
            var isDefault = this.Is_Default(value);

            var output = !isDefault;
            return output;
        }

        public void Verify_NotDefault<T>(T value)
        {
            var is_Default = this.Is_Default(value);

            if (is_Default)
            {
                throw new Exception("Default value encountered.");
            }
        }
    }


    [FunctionsMarker]
    public partial interface IDefaultOperator<T>
    {
        T Value => default;
    }
}
