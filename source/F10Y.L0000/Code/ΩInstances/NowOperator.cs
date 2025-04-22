using System;


namespace F10Y.L0000
{
    public class NowOperator : INowOperator
    {
        #region Infrastructure

        public static INowOperator Instance { get; } = new NowOperator();


        private NowOperator()
        {
        }

        #endregion
    }
}
