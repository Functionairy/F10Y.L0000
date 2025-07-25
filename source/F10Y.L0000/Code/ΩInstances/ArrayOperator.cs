using System;


namespace F10Y.L0000
{
    public class ArrayOperator : IArrayOperator
    {
        #region Infrastructure

        public static IArrayOperator Instance { get; } = new ArrayOperator();


        private ArrayOperator()
        {
        }

        #endregion
    }
}


namespace F10Y.L0000.Unchecked
{
    public class ArrayOperator : IArrayOperator
    {
        #region Infrastructure

        public static IArrayOperator Instance { get; } = new ArrayOperator();


        private ArrayOperator()
        {
        }

        #endregion
    }
}