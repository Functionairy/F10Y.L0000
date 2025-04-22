using System;


namespace F10Y.L0000
{
    public class XmlWriterOperator : IXmlWriterOperator
    {
        #region Infrastructure

        public static IXmlWriterOperator Instance { get; } = new XmlWriterOperator();


        private XmlWriterOperator()
        {
        }

        #endregion
    }
}
