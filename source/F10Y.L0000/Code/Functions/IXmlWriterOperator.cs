using System;
using System.IO;
using System.Xml;

using F10Y.T0002;


namespace F10Y.L0000
{
    [FunctionsMarker]
    public partial interface IXmlWriterOperator
    {
        XmlWriter Create(
            Stream stream,
            XmlWriterSettings xmlWriterSettings)
            => XmlWriter.Create(
                stream,
                xmlWriterSettings);

        XmlWriter Create(
            string xmlFilePath,
            XmlWriterSettings xmlWriterSettings)
            => XmlWriter.Create(
                xmlFilePath,
                xmlWriterSettings);
    }
}
