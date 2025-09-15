using System;


namespace F10Y.L0000
{
    public class DoubleOperator : IDoubleOperator
    {
        #region Infrastructure

        public static IDoubleOperator Instance { get; } = new DoubleOperator();


        private DoubleOperator()
        {
        }

        #endregion
    }
}
