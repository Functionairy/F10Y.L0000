using System;
using System.Linq;

using F10Y.T0002;


namespace F10Y.L0000
{
    [FunctionsMarker]
    public partial interface IArrayOperator
    {
        /// <summary>
        /// Tests if two arrays are equal handling checks for:
        /// <list type="bullet">
        /// <item>Does a simple null-check determine equality?</item>
        /// <item>Are the arrays equal in length?</item>
        /// <item>Are the elements of each array equal, given the input equality provider.</item>
        /// </list>
        /// </summary>
        public bool Are_Equal<T>(
            T[] a,
            T[] b,
            Func<T, T, bool> equalityProvider)
        {
            var output = Instances.NullOperator.NullCheckDeterminesEquality_Else(a, b,
                (a, b) =>
                {
                    var output = true;

                    output &= this.Are_Equal_ArrayLength(a, b);
                    output &= this.Are_Equal_ForeachElement(a, b, equalityProvider);

                    return output;
                });

            return output;
        }

        public bool Are_Equal_ArrayLength<T>(
            T[] a,
            T[] b)
        {
            var output = this.LengthsAreEqual(a, b);
            return output;
        }

        public bool Are_Equal_ForeachElement<T>(
            T[] a,
            T[] b,
            Func<T, T, bool> equality)
        {
            var output = Instances.NullOperator.NullCheckDeterminesEquality_Else(a, b,
                (a, b) =>
                {
                    var pairs = a.Zip(b);

                    foreach (var pair in pairs)
                    {
                        var isEqual = equality(pair.Item1, pair.Item2);
                        if (!isEqual)
                        {
                            return false;
                        }
                    }

                    return true;
                });

            return output;
        }

        /// <summary>
        /// Handles null check.
        /// </summary>
        public bool LengthsAreEqual(Array a, Array b)
        {
            var output = Instances.NullOperator.NullCheckDeterminesEquality_Else(a, b,
                (a, b) =>
                {
                    var lengthA = a.Length;
                    var lengthB = b.Length;

                    var output = lengthA == lengthB;
                    return output;
                });

            return output;
        }
    }
}
