using System;


namespace F10Y.L0000
{
    public class XDocumentOperator : IXDocumentOperator
    {
        #region Infrastructure

        public static IXDocumentOperator Instance { get; } = new XDocumentOperator();


        private XDocumentOperator()
        {
        }

        #endregion
    }
}
