using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

using F10Y.L0000.Extensions;
using F10Y.T0002;
using F10Y.T0011;


namespace F10Y.L0000
{
    [FunctionsMarker]
    public partial interface IArrayOperator
    {
#pragma warning disable IDE1006 // Naming Styles

        [Ignore]
        Unchecked.IArrayOperator _Unchecked => Unchecked.ArrayOperator.Instance;

#pragma warning restore IDE1006 // Naming Styles


        /// <summary>
        /// Tests if two arrays are equal handling checks for:
        /// <list type="bullet">
        /// <item>Does a simple null-check determine equality?</item>
        /// <item>Are the arrays equal in length?</item>
        /// <item>Are the elements of each array equal, given the input equality provider.</item>
        /// </list>
        /// </summary>
        /// <remarks>
        /// <inheritdoc cref="Documentation.Inputs_NullChecked" path="/summary"/>
        /// </remarks>
        public bool Are_Equal<T>(
            T[] a,
            T[] b,
            Func<T, T, bool> equality)
        {
            var output = Instances.NullOperator.NullCheckDeterminesEquality_Else(a, b,
                (a, b) => _Unchecked.Are_Equal(a, b, equality));

            return output;
        }

        public bool Are_Equal<T>(
            T[] a,
            T[] b,
            IEqualityComparer<T> equalityComparer)
        {
            var output = Instances.NullOperator.NullCheckDeterminesEquality_Else(a, b,
                (a, b) => _Unchecked.Are_Equal(a, b, equalityComparer));

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

        public bool Are_Equal_Equatable<T>(
            T[] a,
            T[] b)
            where T : IEquatable<T>
        {
            var output = Instances.NullOperator.NullCheckDeterminesEquality_Else(a, b,
                (a, b) => _Unchecked.Are_Equal_Equatable(a, b));

            return output;
        }

        /// <inheritdoc cref="Are_Equal_OrderDependent{T}(T[], T[], Func{T, T, bool})"/>
        public bool Are_Equal_ForeachElement<T>(
            T[] a,
            T[] b,
            Func<T, T, bool> equality)
            => this.Are_Equal_OrderDependent(a, b, equality);

        /// <summary>
        /// Determines if arrays have equal lengths.
        /// </summary>
        /// <remarks>
        /// <inheritdoc cref="Documentation.Inputs_NullChecked" path="/summary"/>
        /// </remarks>
        public bool Are_Equal_Lengths<T>(
            T[] a,
            T[] b)
        {
            var output = Instances.NullOperator.NullCheckDeterminesEquality_Else(a, b,
                _Unchecked.Are_Equal_Lengths);

            return output;
        }

        /// <summary>
        /// Determines if arrays have equal elements in each position.
        /// </summary>
        /// <remarks>
        /// <inheritdoc cref="Documentation.Inputs_NullChecked" path="/summary"/>
        /// </remarks>
        public bool Are_Equal_OrderDependent<T>(
            T[] a,
            T[] b,
            Func<T, T, bool> equality)
        {
            var output = Instances.NullOperator.NullCheckDeterminesEquality_Else(a, b,
                (a, b) => _Unchecked.Are_Equal_OrderDependent(a, b, equality));

            return output;
        }

        public bool Are_Equal_OrderDependent<T>(
            T[] a,
            T[] b)
            where T : IEquatable<T>
        {
            var equality = Instances.EqualityOperator.Get_Equality<T>();

            var output = Instances.NullOperator.NullCheckDeterminesEquality_Else(a, b,
                (a, b) => _Unchecked.Are_Equal_OrderDependent(a, b, equality));

            return output;
        }

        /// <summary>
        /// Considers: counts. AAB is equal to BAA and ABA.
        /// </summary>
        /// <remarks>
        /// <inheritdoc cref="Documentation.Inputs_NullChecked" path="/summary"/>
        /// </remarks>
        public bool Are_Equal_OrderIndependent<T>(
            T[] a,
            T[] b,
            IEqualityComparer<T> equalityComparer)
        {
            var output = Instances.NullOperator.NullCheckDeterminesEquality_Else(a, b,
                (a, b) => _Unchecked.Are_Equal_OrderIndependent(a, b, equalityComparer));

            return output;
        }

        /// <inheritdoc cref="Are_Equal_OrderIndependent{T}(T[], T[], IEqualityComparer{T})"/>
        public bool Are_Equal_OrderIndependent<T>(
            T[] a,
            T[] b)
        {
            var equalityComparer = Instances.EqualityComparerOperator.Get_Default<T>();

            var output = this.Are_Equal_OrderIndependent(a, b, equalityComparer);
            return output;
        }

        public bool Contains<T>(
            T[] array,
            T value,
            IEqualityComparer<T> equalityComparer)
        {
            var output = array.Contains(
                value,
                equalityComparer);

            return output;
        }

        public bool Contains<T>(
            T[] array,
            T value)
        {
            var equalityComparer = Instances.EqualityComparerOperator.Get_Default<T>();

            var output = this.Contains(
                array,
                value,
                equalityComparer);

            return output;
        }

        /// <summary>
        /// Does A contain B?
        /// </summary>
        public bool Contains<T>(
            T[] a,
            T[] b,
            Func<T, T, bool> equality)
        {
            var length_A = this.Get_Length(a);
            var length_B = this.Get_Length(b);

            var first_B = this.Get_First(b);

            for (int i = 0; i < length_A; i++)
            {
                var element_A = a[i];

                var equals_FirstB = equality(element_A, first_B);
                if(equals_FirstB)
                {
                    // Are there enough elements left?
                    var remainingElementCount_A = length_A - i;
                    if(remainingElementCount_A < length_B)
                    {
                        return false;
                    }

                    for (int j = 0; j < length_B; j++)
                    {
                        var element_Aj = a[i + j];
                        var element_B = b[j];

                        var areEqual = equality(element_Aj, element_B);
                        if(!areEqual)
                        {
                            return false;
                        }
                    }

                    // Break.
                    return true;
                }
            }

            return false;
        }

        /// <inheritdoc cref="Contains{T}(T[], T[], Func{T, T, bool})"/>
        public bool Contains<T>(
            T[] a,
            T[] b)
            where T : IEquatable<T>
        {
            var equality = Instances.EqualityOperator.Get_Equality<T>();

            var output = this.Contains(
                a,
                b,
                equality);

            return output;
        }

        public void Copy<T>(
            T[] source,
            T[] destination,
            int startIndex_Source)
        {
            var destination_Length = this.Get_Length(destination);

            for (int i = 0; i < destination_Length; i++)
            {
                destination[i] = source[startIndex_Source + i];
            }
        }

        /// <summary>
        /// Produces an empty array of the specified type.
        /// </summary>
        public T[] Empty<T>()
            => Array.Empty<T>();

        public T[] Empty_IfNull<T>(T[] array)
        {
            var isNull = Instances.NullOperator.Is_Null(array);

            var output = isNull
                ? this.Empty<T>()
                : array
                ;

            return output;
        }

        public T[] From<T>(params T[] values)
            => values;

        public T[] From<T>(
            T[] values,
            params T[] appendix_Values)
        {
            var output = values
                .Append_Many(appendix_Values)
                .ToArray();

            return output;
        }

        public T[] From<T>(
            T[] values,
            params T[][] appendix_Arrays)
        {
            var output = values
                .Append_Many(appendix_Arrays
                    .SelectMany(Instances.Functions.Return)
                )
                .ToArray();

            return output;
        }

        public int Get_Count<T>(T[] array)
            => array.Length;

        public int Get_Length(Array array)
            => array.Length;

        public int Get_Length<T>(T[] array)
            => array.Length;

        public T Get<T>(
            T[] array,
            int index)
            => array[index];

        public T Get_First<T>(T[] array)
        {
            // Could be either a zero- (C# standard) or one-based (some MS Office interop scenarios) array.
            var index_First = this.Get_Index_First(array);

            var output = array[index_First];
            return output;
        }

        public T Get_Second<T>(T[] array)
        {
            // Could be either a zero- (C# standard) or one-based (some MS Office interop scenarios) array.
            var index_First = this.Get_Index_First(array);

            var index = index_First + 1;

            var output = this.Get(
                array,
                index);

            return output;
        }

        public int Get_Index_First<T>(T[] array)
            // Even if the array is one-based, its dimensions are zero-based.
            => array.GetLowerBound(Instances.Indices.Zero);

        public int Get_IndexOfLast(Array array)
        {
            var output = array.Length - 1;
            return output;
        }

        public T Get_Last<T>(T[] arrary)
        {
            var output = arrary[^1];
            return output;
        }

        public bool Is_Empty(Array array)
        {
            var output = array.Length == 0;
            return output;
        }

        public bool Is_NotEmpty(Array array)
        {
            var output = array.Length > 0;
            return output;
        }

        public bool Is_NullOrEmpty(Array array)
        {
            var isNull = Instances.NullOperator.Is_Null(array);
            if (isNull)
            {
                return true;
            }

            var isEmpty = this.Is_Empty(array);
            if (isEmpty)
            {
                return true;
            }

            return false;
        }

        public bool Is_NotNullOrEmpty(Array array)
        {
            var is_NullOrEmpty = this.Is_NullOrEmpty(array);

            var output = !is_NullOrEmpty;
            return output;
        }

        public T[] New<T>(int length)
            => new T[length];

        public T[] Null_IfEmpty<T>(T[] array)
        {
            var isEmpty = this.Is_Empty(array);

            var output = isEmpty
                ? null
                : array
                ;

            return output;
        }

        public T[] To_Array<T>(IEnumerable<T> enumerable)
            => enumerable.ToArray();
    }
}
