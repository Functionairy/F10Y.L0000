using System;
using System.Collections;
using System.Collections.Generic;

using F10Y.T0002;


namespace F10Y.L0000
{
    [FunctionsMarker]
    public partial interface IEqualityComparerOperator
    {
        public EqualityComparer<T> Get_Default<T>()
        {
            var output = EqualityComparer<T>.Default;
            return output;
        }

        public EqualityComparer<T> Get_Default<T>(T value)
            => this.Get_Default<T>();

        /// <summary>
        /// 
        /// </summary>
        /// <remarks>
        /// Name contains "_OfObject" to prevent call ambiguity with <see cref="Get_HashCode{T}(T, IEqualityComparer{T})"/>.
        /// </remarks>
        public int Get_HashCode_OfObject(
            object value,
            IEqualityComparer equalityComparer)
        {
            var output = equalityComparer.GetHashCode(value);
            return output;
        }

        public int Get_HashCode<T>(
            T value,
            IEqualityComparer<T> equalityComparer)
        {
            var output = equalityComparer.GetHashCode(value);
            return output;
        }
    }
}
