using System;


namespace F10Y.L0000
{
    public class DefaultOperator : IDefaultOperator
    {
        #region Infrastructure

        public static IDefaultOperator Instance { get; } = new DefaultOperator();


        private DefaultOperator()
        {
        }

        #endregion
    }
}
