using System;
using System.Linq;
using F10Y.T0002;


namespace F10Y.L0000
{
    [FunctionsMarker]
    public partial interface IHashCodeOperator
    {
        public int Combine<T1, T2>(
            T1 value1,
            T2 value2)
        {
            var output = HashCode.Combine(
                value1,
                value2);

            return output;
        }

        public int Combine<T1, T2, T3>(
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

        public int Default<T>(T obj)
            // Use the combine method to handle null.
            => HashCode.Combine(obj);

        public int Get_HashCode<T>(T value)
            // Use the combine method to handle null.
            => HashCode.Combine(value);

        public int Get_HashCode_OfArray<T>(T[] value)
        {
            var elementHashes = value
                .Select(this.Get_HashCode<T>)
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

        public int Get_HashCode<T1, T2>(
            T1 t1,
            T2 t2)
        {
            var output = this.Combine(
                t1,
                t2);

            return output;
        }

        public int Get_HashCode<T1, T2, T3>(
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
