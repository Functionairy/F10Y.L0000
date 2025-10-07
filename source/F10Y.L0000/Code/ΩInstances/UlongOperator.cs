using System;


namespace F10Y.L0000
{
    public class UlongOperator : IUlongOperator
    {
        #region Infrastructure

        public static IUlongOperator Instance { get; } = new UlongOperator();


        private UlongOperator()
        {
        }

        #endregion
    }
}
