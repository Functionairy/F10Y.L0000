using System;
using System.Xml;

using F10Y.T0003;
using F10Y.T0011;


namespace F10Y.L0000
{
    [ValuesMarker]
    public partial interface IXmlWriterSettingsSet
    {
#pragma warning disable IDE1006 // Naming Styles

        [Ignore]
        public Raw.IXmlWriterSettingsSet _Raw => Raw.XmlWriterSettingsSet.Instance;

#pragma warning restore IDE1006 // Naming Styles


        /// <summary>
        /// Omit the XML declaration for synchronous operations.
        /// Sets:
        /// <list type="bullet">
        /// <item><see cref="XmlWriterSettings.OmitXmlDeclaration"/></item>
        /// </list>
        /// </summary>
        /// <remarks>
        /// Does not set <see cref="XmlWriterSettings.Async"/>.
        /// </remarks>
        public XmlWriterSettings OmitXmlDeclaration_Synchronous => new XmlWriterSettings
        {
            OmitXmlDeclaration = true,
        };

        /// <summary>
        /// Omit the XML declaration for asynchronous operations.
        /// Sets:
        /// <list type="bullet">
        /// <item><see cref="XmlWriterSettings.OmitXmlDeclaration"/></item>
        /// <item><see cref="XmlWriterSettings.Async"/></item>
        /// </list>
        /// </summary>
        public XmlWriterSettings OmitXmlDeclaration_Asynchronous => new XmlWriterSettings
        {
            Async = true,
            OmitXmlDeclaration = true,
        };

        /// <summary>
        /// Omit the XML declaration for asynchronous operations.
        /// Sets:
        /// <list type="bullet">
        /// <item><see cref="XmlWriterSettings.Async"/></item>
        /// <item><see cref="XmlWriterSettings.ConformanceLevel"/></item>
        /// <item><see cref="XmlWriterSettings.OmitXmlDeclaration"/></item>
        /// </list>
        /// </summary>
        public XmlWriterSettings OmitXmlDeclaration_Fragment_Asynchronous => new XmlWriterSettings
        {
            Async = true,
            ConformanceLevel = ConformanceLevel.Fragment,
            OmitXmlDeclaration = true,
        };

        /// <summary>
        /// Chooses <see cref="OmitXmlDeclaration_Asynchronous"/> as the default,
        /// because synchronous operations do no care about the <see cref="XmlWriterSettings.Async"/> setting.
        /// </summary>
        public XmlWriterSettings OmitXmlDeclaration => this.OmitXmlDeclaration_Asynchronous;

        /// <inheritdoc cref="Raw.IXmlWriterSettingsSet.N_001"/>
        public XmlWriterSettings Indent_AndOmitXmlDeclaration => _Raw.N_001;
    }
}
