using System;


namespace F10Y.L0000
{
    public class SearchPatterns : ISearchPatterns
    {
        #region Infrastructure

        public static ISearchPatterns Instance { get; } = new SearchPatterns();


        private SearchPatterns()
        {
        }

        #endregion
    }
}
