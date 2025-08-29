using System;


namespace F10Y.L0000
{
    public class FlagsOperator : IFlagsOperator
    {
        #region Infrastructure

        public static IFlagsOperator Instance { get; } = new FlagsOperator();


        private FlagsOperator()
        {
        }

        #endregion
    }
}


namespace F10Y.L0000.Implementations
{
    public class FlagsOperator : IFlagsOperator
    {
        #region Infrastructure

        public static IFlagsOperator Instance { get; } = new FlagsOperator();


        private FlagsOperator()
        {
        }

        #endregion
    }
}