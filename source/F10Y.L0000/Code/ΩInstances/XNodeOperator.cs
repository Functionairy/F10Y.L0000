using System;


namespace F10Y.L0000
{
    public class XNodeOperator : IXNodeOperator
    {
        #region Infrastructure

        public static IXNodeOperator Instance { get; } = new XNodeOperator();


        private XNodeOperator()
        {
        }

        #endregion
    }
}
