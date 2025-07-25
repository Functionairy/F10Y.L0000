using System;


namespace F10Y.L0000
{
    public class ComparisonOperator : IComparisonOperator
    {
        #region Infrastructure

        public static IComparisonOperator Instance { get; } = new ComparisonOperator();


        private ComparisonOperator()
        {
        }

        #endregion
    }
}
