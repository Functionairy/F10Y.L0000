using System;


namespace F10Y.L0000
{
    public class ListOperator : IListOperator
    {
        #region Infrastructure

        public static IListOperator Instance { get; } = new ListOperator();


        private ListOperator()
        {
        }

        #endregion
    }
}


namespace F10Y.L0000.Implementations
{
    public class ListOperator : IListOperator
    {
        #region Infrastructure

        public static IListOperator Instance { get; } = new ListOperator();


        private ListOperator()
        {
        }

        #endregion
    }
}
