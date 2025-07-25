using System;
using System.Collections.Generic;
using System.Linq;

using F10Y.T0002;


namespace F10Y.L0000.Unchecked
{
    [FunctionsMarker]
    public partial interface IArrayOperator
    {
#pragma warning disable IDE1006 // Naming Styles

        private static L0000.IArrayOperator _ArrayOperator => L0000.ArrayOperator.Instance;

#pragma warning restore IDE1006 // Naming Styles


        /// <inheritdoc cref="L0000.IArrayOperator.Are_Equal{T}(T[], T[], Func{T, T, bool})" path="/summary"/>
        /// <remarks>
        /// <inheritdoc cref="Documentation.Inputs_NullChecked" path="/summary"/>
        /// </remarks>
        public bool Are_Equal<T>(
            T[] a,
            T[] b,
            Func<T, T, bool> equality)
        {
            var output = true;

            output &= this.Are_Equal_Lengths(a, b);
            output &= this.Are_Equal_OrderDependent(a, b, equality);

            return output;
        }

        public bool Are_Equal_Equatable<T>(
            T[] a,
            T[] b)
            where T : IEquatable<T>
        {
            var output = true;

            output &= this.Are_Equal_Lengths(a, b);
            output &= this.Are_Equal_OrderDependent(a, b);

            return output;
        }

        public bool Are_Equal<T>(
            T[] a,
            T[] b,
            IEqualityComparer<T> equalityComparer)
        {
            var output = true;

            output &= this.Are_Equal_Lengths(a, b);
            output &= this.Are_Equal_OrderDependent(a, b, equalityComparer);

            return output;
        }

        public bool Are_Equal<T>(
            T[] a,
            T[] b)
        {
            var equalityComparer = Instances.EqualityComparerOperator.Get_Default<T>();

            var output = this.Are_Equal(a, b, equalityComparer);
            return output;
        }

        /// <inheritdoc cref="L0000.IArrayOperator.Are_Equal_ForeachElement{T}(T[], T[], Func{T, T, bool})" path="/summary"/>
        /// <remarks>
        /// <inheritdoc cref="Documentation.Inputs_NullChecked_Not" path="/summary"/>
        /// </remarks>
        public bool Are_Equal_OrderDependent<T>(
            T[] a,
            T[] b,
            Func<T, T, bool> equality)
        {
            var pairs = Instances.EnumerableOperator.Zip(a, b);

            foreach (var pair in pairs)
            {
                var isEqual = equality(pair.Item1, pair.Item2);
                if (!isEqual)
                {
                    return false;
                }
            }

            return true;
        }

        public bool Are_Equal_OrderDependent_Equatable<T>(
            T[] a,
            T[] b)
            where T : IEquatable<T>
        {
            var pairs = Instances.EnumerableOperator.Zip(a, b);

            foreach (var pair in pairs)
            {
                var isEqual = pair.Item1.Equals(pair.Item2);
                if (!isEqual)
                {
                    return false;
                }
            }

            return true;
        }

        public bool Are_Equal_OrderDependent<T>(
            T[] a,
            T[] b,
            IEqualityComparer<T> equalityComparer)
        {
            var pairs = Instances.EnumerableOperator.Zip(a, b);

            foreach (var pair in pairs)
            {
                var isEqual = equalityComparer.Equals(pair.Item1, pair.Item2);
                if (!isEqual)
                {
                    return false;
                }
            }

            return true;
        }

        public bool Are_Equal_OrderDependent<T>(
            T[] a,
            T[] b)
        {
            var equalityComparer = Instances.EqualityComparerOperator.Get_Default<T>();

            var output = this.Are_Equal_OrderDependent(
                a, b, equalityComparer);

            return output;
        }

        /// <inheritdoc cref="L0000.IArrayOperator.Are_Equal_OrderIndependent{T}(T[], T[], IEqualityComparer{T})" path="/summary"/>
        /// <remarks>
        /// <inheritdoc cref="Documentation.Inputs_NullChecked_Not" path="/summary"/>
        /// </remarks>
        public bool Are_Equal_OrderIndependent<T>(
            T[] a,
            T[] b,
            IEqualityComparer<T> equalityComparer)
        {
            var areEqual_Lengths = this.Are_Equal_Lengths(a, b);
            if (!areEqual_Lengths)
            {
                return false;
            }

            var groupCounts_A = a.GroupBy(
                x => x,
                equalityComparer)
                .ToDictionary(
                    group => group.Key,
                    group => group.Count());

            var groupCounts_B = a.GroupBy(
                x => x,
                equalityComparer)
                .ToDictionary(
                    group => group.Key,
                    group => group.Count());

            var groupCount_A = groupCounts_A.Count;
            var groupCount_B = groupCounts_B.Count;

            var areEqual_GroupCounts = groupCount_A == groupCount_B;
            if(!areEqual_GroupCounts)
            {
                return false;
            }

            var intersection = groupCounts_A.Keys.Intersect(groupCounts_B.Keys);
            var intersection_Count = intersection.Count();

            // If the element count between two sets is the same, and the intersection is the same length as one of the sets, then the sets contain the same elements.
            var sameElements = intersection_Count == groupCount_A;
            if(!sameElements)
            {
                return false;
            }

            // Now, do we have the same counts of each element?
            foreach (var pair_A in groupCounts_A)
            {
                var elementCount_A = pair_A.Value;

                var elementCount_B = groupCounts_B[pair_A.Key];

                var areEqual_ElementCounts = elementCount_A == elementCount_B;
                if(!areEqual_ElementCounts)
                {
                    return false;
                }
            }

            // Finally.
            return true;
        }

        /// <inheritdoc cref="L0000.IArrayOperator.Are_Equal_Lengths{T}(T[], T[])" path="/summary"/>
        /// <remarks>
        /// <inheritdoc cref="Documentation.Inputs_NullChecked_Not"/>
        /// </remarks>
        public bool Are_Equal_Lengths<T>(
            T[] a,
            T[] b)
        {
            var lengthA = a.Length;
            var lengthB = b.Length;

            var output = lengthA == lengthB;
            return output;
        }
    }
}
