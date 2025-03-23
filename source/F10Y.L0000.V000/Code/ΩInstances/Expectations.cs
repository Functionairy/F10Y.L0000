using System;


namespace F10Y.L0000.V000
{
    public class Expectations : IExpectations
    {
        #region Infrastructure

        public static IExpectations Instance { get; } = new Expectations();


        private Expectations()
        {
        }

        #endregion
    }
}


namespace F10Y.L0000.V000.Raw
{
    public class Expectations : IExpectations
    {
        #region Infrastructure

        public static IExpectations Instance { get; } = new Expectations();


        private Expectations()
        {
        }

        #endregion
    }
}