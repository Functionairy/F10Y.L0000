using System;


namespace F10Y.L0000
{
    public class NullOperator : INullOperator
    {
        #region Infrastructure

        public static INullOperator Instance { get; } = new NullOperator();


        private NullOperator()
        {
        }

        #endregion
    }
}
