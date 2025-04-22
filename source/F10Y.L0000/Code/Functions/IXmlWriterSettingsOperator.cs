using System;
using System.Xml;

using F10Y.T0002;


namespace F10Y.L0000
{
    [FunctionsMarker]
    public partial interface IXmlWriterSettingsOperator
    {
        public void Set_WithByteOrderMark(XmlWriterSettings xmlWriterSettings)
        {
            xmlWriterSettings.Encoding = Instances.Encodings.UTF8_WithBOM;
        }

        public void Set_WithoutByteOrderMark(XmlWriterSettings xmlWriterSettings)
        {
            xmlWriterSettings.Encoding = Instances.Encodings.UTF8_WithoutBOM;
        }
    }
}
