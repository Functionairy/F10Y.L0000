using System;


namespace F10Y.L0000
{
    public class XAttributeOperator : IXAttributeOperator
    {
        #region Infrastructure

        public static IXAttributeOperator Instance { get; } = new XAttributeOperator();


        private XAttributeOperator()
        {
        }

        #endregion
    }
}
