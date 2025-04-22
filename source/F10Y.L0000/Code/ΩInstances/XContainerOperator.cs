using System;


namespace F10Y.L0000
{
    public class XContainerOperator : IXContainerOperator
    {
        #region Infrastructure

        public static IXContainerOperator Instance { get; } = new XContainerOperator();


        private XContainerOperator()
        {
        }

        #endregion
    }
}
