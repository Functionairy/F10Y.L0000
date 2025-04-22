using System;

using F10Y.T0003;
using F10Y.T0011;


namespace F10Y.L0000.Z000
{
    [ValuesMarker]
    public partial interface ITexts
    {
#pragma warning disable IDE1006 // Naming Styles

        [Ignore]
        public Raw.ITexts _Raw => Raw.Texts.Instance;

#pragma warning restore IDE1006 // Naming Styles


        /// <inheritdoc cref="Raw.ITexts.N_001"/>
        public string Example_Text => _Raw.N_001;

        /// <inheritdoc cref="Raw.ITexts.N_002"/>
        public string Example_Text_Enquoted => _Raw.N_002;
    }
}
