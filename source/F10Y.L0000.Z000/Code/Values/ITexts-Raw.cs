using System;

using F10Y.T0003;


namespace F10Y.L0000.Z000.Raw
{
    [ValuesMarker]
    public partial interface ITexts
    {
        /// <summary>
        /// <para><value>Example Text</value></para>
        /// No quotes.
        /// </summary>
        public string N_001 => "Example Text";

        /// <summary>
        /// <para><value>"Example Text"</value></para>
        /// Enquoted.
        /// </summary>
        public string N_002 => "\"Example Text\"";

        /// <summary>
        /// <para><value>"Example Text</value></para>
        /// Beginning quote, but not ending quote.
        /// </summary>
        public string N_003 => "\"Example Text";

        /// <summary>
        /// <para><value>Example Text"</value></para>
        /// Ending quote, but not beginning quote.
        /// </summary>
        public string N_004 => "Example Text\"";
    }
}
