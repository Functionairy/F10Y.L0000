using System;


namespace F10Y.L0000
{
    public class SearchPatternOperator : ISearchPatternOperator
    {
        #region Infrastructure

        public static ISearchPatternOperator Instance { get; } = new SearchPatternOperator();


        private SearchPatternOperator()
        {
        }

        #endregion
    }
}
