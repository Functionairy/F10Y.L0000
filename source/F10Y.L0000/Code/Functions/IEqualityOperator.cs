using System;
using System.Collections.Generic;

using F10Y.T0002;


namespace F10Y.L0000
{
    [FunctionsMarker]
    public partial interface IEqualityOperator
    {
        bool Are_Equal<T>(T a, T b)
            where T : IEquatable<T>
            => a.Equals(b);

        bool Are_Equal<T>(T a, T b, IEqualityComparer<T> equalityComparer)
            => equalityComparer.Equals(a, b);

        bool Are_Equal_AsObjects<T>(
            T a,
            T b)
        {
            var output = Object.Equals(
                a,
                b);

            return output;
        }

        bool Are_Equal_ByReference<T>(
            T a,
            T b)
        {
            var output = Object.ReferenceEquals(
                a,
                b);

            return output;
        }

        /// <summary>
        /// Useful as the implementation of the overridden equality operator.
        /// </summary>
        bool Equals<T>(
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

        Func<T, T, bool> Get_Equality<T>()
            where T : IEquatable<T>
            => (a, b) => a.Equals(b);

        EqualityComparer<T> Get_EqualityComparer_Default<T>()
        {
            var output = Instances.EqualityComparerOperator.Get_Default<T>();
            return output;
        }
    }
}
