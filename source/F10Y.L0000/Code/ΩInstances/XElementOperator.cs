using System;


namespace F10Y.L0000
{
    public class XElementOperator : IXElementOperator
    {
        #region Infrastructure

        public static IXElementOperator Instance { get; } = new XElementOperator();


        private XElementOperator()
        {
        }

        #endregion
    }
}
