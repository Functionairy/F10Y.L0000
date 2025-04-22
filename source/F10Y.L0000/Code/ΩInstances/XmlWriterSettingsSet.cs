using System;


namespace F10Y.L0000
{
    public class XmlWriterSettingsSet : IXmlWriterSettingsSet
    {
        #region Infrastructure

        public static IXmlWriterSettingsSet Instance { get; } = new XmlWriterSettingsSet();


        private XmlWriterSettingsSet()
        {
        }

        #endregion
    }
}


namespace F10Y.L0000.Raw
{
    public class XmlWriterSettingsSet : IXmlWriterSettingsSet
    {
        #region Infrastructure

        public static IXmlWriterSettingsSet Instance { get; } = new XmlWriterSettingsSet();


        private XmlWriterSettingsSet()
        {
        }

        #endregion
    }
}