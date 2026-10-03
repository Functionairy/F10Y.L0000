using System;
using System.Text;

using F10Y.T0003;


namespace F10Y.L0000
{
    [ValuesMarker]
    public partial interface IEncodings
    {
        /// <inheritdoc cref="Encoding.ASCII"/>
        Encoding ASCII => Encoding.ASCII;

        /// <summary>
        /// The default UTF8 encoding includes a byte-order mark (BOM).
        /// </summary>
        Encoding UTF8 => Encoding.UTF8;

        // The default UTF8 encoding includes a BOM.
        Encoding UTF8_WithBOM => this.UTF8;

        Encoding UTF8_WithoutBOM => new UTF8Encoding(false);
    }
}
