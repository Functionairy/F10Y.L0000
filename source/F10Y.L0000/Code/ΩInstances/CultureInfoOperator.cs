using System;


namespace F10Y.L0000
{
    public class CultureInfoOperator : ICultureInfoOperator
    {
        #region Infrastructure

        public static ICultureInfoOperator Instance { get; } = new CultureInfoOperator();


        private CultureInfoOperator()
        {
        }

        #endregion
    }
}
