using System;

using F10Y.T0003;

using CharacterDocumentation = F10Y.Y0000.Documentation.For_Characters;


namespace F10Y.L0000
{
    [ValuesMarker]
    public partial interface ICharacters
    {
        /// <inheritdoc cref="CharacterDocumentation.For_QuotationMark"/>
        public const char QuotationMark_Constant = '"';

        /// <inheritdoc cref="QuotationMark_Constant"/>
        public char QuotationMark => ICharacters.QuotationMark_Constant;
    }
}
