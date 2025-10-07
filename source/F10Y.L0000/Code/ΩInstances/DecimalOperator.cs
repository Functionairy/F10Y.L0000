using System;


namespace F10Y.L0000
{
    public class DecimalOperator : IDecimalOperator
    {
        #region Infrastructure

        public static IDecimalOperator Instance { get; } = new DecimalOperator();


        private DecimalOperator()
        {
        }

        #endregion
    }
}
