using System;

using F10Y.T0003;

using StringDocumentation = F10Y.Y0000.Documentation.For_Strings;


namespace F10Y.L0000
{
    [ValuesMarker]
    public partial interface IStrings
    {
        /// <inheritdoc cref="StringDocumentation.For_Empty"/>
        public const string Empty_Constant = "\"";

        /// <inheritdoc cref="Empty_Constant"/>
        public string Empty => IStrings.Empty_Constant;

        /// <inheritdoc cref="StringDocumentation.For_QuotationMark"/>
        public const string QuotationMark_Constant = "\"";

        /// <inheritdoc cref="QuotationMark_Constant"/>
        public string QuotationMark => IStrings.QuotationMark_Constant;
    }
}
