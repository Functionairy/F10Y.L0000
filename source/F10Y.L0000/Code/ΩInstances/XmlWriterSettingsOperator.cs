using System;


namespace F10Y.L0000
{
    public class XmlWriterSettingsOperator : IXmlWriterSettingsOperator
    {
        #region Infrastructure

        public static IXmlWriterSettingsOperator Instance { get; } = new XmlWriterSettingsOperator();


        private XmlWriterSettingsOperator()
        {
        }

        #endregion
    }
}
