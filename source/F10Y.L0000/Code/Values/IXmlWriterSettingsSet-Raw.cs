using System;
using System.Xml;

using F10Y.T0003;


namespace F10Y.L0000.Raw
{
    [ValuesMarker]
    public partial interface IXmlWriterSettingsSet
    {
        /// <summary>
        /// Omit the XML declaration and indent for asynchronous operations.
        /// Sets:
        /// <list type="bullet">
        /// <item><see cref="XmlWriterSettings.Async"/></item>
        /// <item><see cref="XmlWriterSettings.OmitXmlDeclaration"/></item>
        /// <item><see cref="XmlWriterSettings.OmitXmlDeclaration"/></item>
        /// </list>
        /// </summary>
        public XmlWriterSettings N_001 => new XmlWriterSettings
        {
            Async = true,
            Indent = true,
            OmitXmlDeclaration = true,
        };
    }
}
