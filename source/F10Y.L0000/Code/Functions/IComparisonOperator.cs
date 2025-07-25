using System;

using F10Y.T0002;


namespace F10Y.L0000
{
    [FunctionsMarker]
    public partial interface IComparisonOperator
    {
        /// <summary>
        /// Is the comparison result the <see cref="IComparisonResults.EqualTo"/> value?
        /// </summary>
        public bool Is_EqualResult(int comparisonResult)
        {
            var output = Instances.IntegerOperator.Is_Equal(
                comparisonResult,
                Instances.ComparisonResults.EqualTo);

            return output;
        }

        /// <summary>
        /// Is the comparison result <em>not</em> the <see cref="IComparisonResults.EqualTo"/> value?
        /// </summary>
        public bool Is_NotEqualResult(int comparisonResult)
        {
            var output = Instances.IntegerOperator.Is_NotEqual(
                comparisonResult,
                Instances.ComparisonResults.EqualTo);

            return output;
        }
    }
}
