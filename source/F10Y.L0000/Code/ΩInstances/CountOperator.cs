using System;


namespace F10Y.L0000
{
    public class CountOperator : ICountOperator
    {
        #region Infrastructure

        public static ICountOperator Instance { get; } = new CountOperator();


        private CountOperator()
        {
        }

        #endregion
    }
}
