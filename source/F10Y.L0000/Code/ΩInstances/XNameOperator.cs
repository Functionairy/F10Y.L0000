using System;


namespace F10Y.L0000
{
    public class XNameOperator : IXNameOperator
    {
        #region Infrastructure

        public static IXNameOperator Instance { get; } = new XNameOperator();


        private XNameOperator()
        {
        }

        #endregion
    }
}
