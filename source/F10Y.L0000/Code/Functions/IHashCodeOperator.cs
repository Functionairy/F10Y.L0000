using System;
using System.Linq;

using F10Y.T0002;
using F10Y.T0011;


namespace F10Y.L0000
{
    [FunctionsMarker]
    public partial interface IHashCodeOperator
    {
#pragma warning disable IDE1006 // Naming Styles

        [Ignore]
        Implementations.IHashCodeOperator _Implementations => Implementations.HashCodeOperator.Instance;

#pragma warning restore IDE1006 // Naming Styles


        int Combine<T>(params T[] values)
            => this.Get_HashCode_OfArray(values);

        int Combine<T1, T2>(
            T1 value1,
            T2 value2)
        {
            var output = HashCode.Combine(
                value1,
                value2);

            return output;
        }

        int Combine<T1, T2, T3>(
            T1 value1,
            T2 value2,
            T3 value3)
        {
            var output = HashCode.Combine(
                value1,
                value2,
                value3);

            return output;
        }

        int Combine<T1, T2, T3, T4>(
            T1 value1,
            T2 value2,
            T3 value3,
            T4 value4)
        {
            var output = HashCode.Combine(
                value1,
                value2,
                value3,
                value4);

            return output;
        }

        int Combine<T1, T2, T3, T4, T5>(
            T1 value1,
            T2 value2,
            T3 value3,
            T4 value4,
            T5 value5)
        {
            var output = HashCode.Combine(
                value1,
                value2,
                value3,
                value4,
                value5);

            return output;
        }

        int Default<T>(T obj)
            // Use the combine method to handle null.
            => HashCode.Combine(obj);

        int Get_HashCode<T>(T value)
            // Use the combine method to handle null.
            => HashCode.Combine(value);

        int Get_HashCode<T>(params T[] values)
            // Use the combine method to handle null.
            => Get_HashCode_OfArray(values);

        /// <inheritdoc cref="Get_HashCode_OfArray{T}(T[], Func{T, int})"/>
        int Get_HashCode_OfArray<T>(T[] value)
            => this.Get_HashCode_OfArray(
                value,
                this.Get_HashCode<T>);

        /// <summary>
        /// For an array of elements, get the hash code of each element and then combine them all.
        /// </summary>
        /// <remarks>
        /// For null arrays, the hash code for null is returned (<see cref="IHashCodes.For_Null"/>).
        /// </remarks>
        int Get_HashCode_OfArray<T>(
            T[] value,
            Func<T, int> element_HashCode_Provider)
        {
            var is_Null = Instances.NullOperator.Is_Null(value);
            if (is_Null)
            {
                return Instances.HashCodes.For_Null;
            }

            var elementHashes = value
                .Select(element_HashCode_Provider)
                .ToArray();

            // Dummy value to start.
            var output = 0;

            foreach (var elementHash in elementHashes)
            {
                output = HashCode.Combine(
                    output,
                    elementHash);
            }

            return output;
        }

        int Get_HashCode<T1, T2>(
            T1 t1,
            T2 t2)
        {
            var output = this.Combine(
                t1,
                t2);

            return output;
        }

        int Get_HashCode<T1, T2, T3>(
            T1 t1,
            T2 t2,
            T3 t3)
        {
            var output = this.Combine(
                t1,
                t2,
                t3);

            return output;
        }
    }
}
