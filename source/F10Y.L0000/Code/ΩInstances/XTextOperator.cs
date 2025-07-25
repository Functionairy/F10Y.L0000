using System;


namespace F10Y.L0000
{
    public class XTextOperator : IXTextOperator
    {
        #region Infrastructure

        public static IXTextOperator Instance { get; } = new XTextOperator();


        private XTextOperator()
        {
        }

        #endregion
    }
}
