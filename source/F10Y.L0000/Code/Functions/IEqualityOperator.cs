using System;
using System.Collections.Generic;

using F10Y.T0002;


namespace F10Y.L0000
{
    [FunctionsMarker]
    public partial interface IEqualityOperator
    {
        /// <summary>
        /// Useful as the implementation of the overridden equality operator.
        /// </summary>
        public bool Equals<T>(
            object other,
            T value,
            Func<T, T, bool> equality)
        {
            if(other is T other_AsT)
            {
                var output = equality(
                    other_AsT,
                    value);

                return output;
            }
            else
            {
                return false;
            }
        }

        public Func<T, T, bool> Get_Equality<T>()
            where T : IEquatable<T>
            => (a, b) => a.Equals(b);

        public EqualityComparer<T> Get_EqualityComparer_Default<T>()
        {
            var output = Instances.EqualityComparerOperator.Get_Default<T>();
            return output;
        }
    }
}
