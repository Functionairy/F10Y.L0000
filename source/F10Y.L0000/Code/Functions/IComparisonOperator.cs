using System;

using F10Y.T0002;


namespace F10Y.L0000
{
    [FunctionsMarker]
    public partial interface IComparisonOperator
    {
        int Compare<T, TKey>(
            T a,
            T b,
            Func<T, TKey> keySelector,
            Func<TKey, TKey, int> keyComparer)
        {
            var keyA = keySelector(a);
            var keyB = keySelector(b);

            var output = keyComparer(
                keyA,
                keyB);

            return output;
        }

        int Invert(int comparison)
        {
            if(comparison == Instances.ComparisonResults.LessThan)
            {
                return Instances.ComparisonResults.GreaterThan;
            }

            if (comparison == Instances.ComparisonResults.GreaterThan)
            {
                return Instances.ComparisonResults.LessThan;
            }

            // Else, equal.
            return comparison;
        }

        bool Is_ComparisonDefinitive<T, TKey>(
            T a,
            T b,
            Func<T, TKey> keySelector,
            Func<TKey, TKey, int> keyComparer,
            out int comparison)
        {
            comparison = this.Compare(
                a,
                b,
                keySelector,
                keyComparer);

            var output = this.Is_NotEqualResult(comparison);
            return output;
        }

        /// <summary>
        /// Is the comparison result the <see cref="IComparisonResults.EqualTo"/> value?
        /// </summary>
        bool Is_EqualResult(int comparisonResult)
        {
            var output = Instances.IntegerOperator.Is_Equal(
                comparisonResult,
                Instances.ComparisonResults.EqualTo);

            return output;
        }

        /// <summary>
        /// Is the comparison result <em>not</em> the <see cref="IComparisonResults.EqualTo"/> value?
        /// </summary>
        bool Is_NotEqualResult(int comparisonResult)
        {
            var output = Instances.IntegerOperator.Is_NotEqual(
                comparisonResult,
                Instances.ComparisonResults.EqualTo);

            return output;
        }
    }
}
