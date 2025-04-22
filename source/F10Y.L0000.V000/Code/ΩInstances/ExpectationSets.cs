using System;


namespace F10Y.L0000.V000
{
    public class ExpectationSets : IExpectationSets
    {
        #region Infrastructure

        public static IExpectationSets Instance { get; } = new ExpectationSets();


        private ExpectationSets()
        {
        }

        #endregion
    }
}


namespace F10Y.L0000.V000.Raw
{
    public class ExpectationSets : IExpectationSets
    {
        #region Infrastructure

        public static IExpectationSets Instance { get; } = new ExpectationSets();


        private ExpectationSets()
        {
        }

        #endregion
    }
}