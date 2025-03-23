using System;

using F10Y.T0003;


namespace F10Y.L0000.Z000
{
    [ValuesMarker]
    public partial interface ITexts
    {
        /// <summary>
        /// <para><value>Example Text</value></para>
        /// </summary>
        public string Example_Text => "Example Text";

        /// <summary>
        /// <para><value>"Example Text"</value></para>
        /// </summary>
        public string Example_Text_Enquoted => "\"Example Text\"";
    }
}
