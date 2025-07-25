using System;


namespace F10Y.L0000
{
    public class ComparisonResults : IComparisonResults
    {
        #region Infrastructure

        public static IComparisonResults Instance { get; } = new ComparisonResults();


        private ComparisonResults()
        {
        }

        #endregion
    }
}
