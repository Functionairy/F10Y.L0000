using System;


namespace F10Y.L0000
{
    public partial interface IStrings
    {
        /// <inheritdoc cref="Hyphen_Constant"/>
        public const string Dash_Constant = IStrings.Hyphen_Constant;

        /// <inheritdoc cref="Dash_Constant"/>
        public string Dash => IStrings.Dash_Constant;

        /// <inheritdoc cref="QuotationMark_Constant"/>
        public const string Quote_Constant = IStrings.QuotationMark_Constant;

        /// <inheritdoc cref="QuotationMark"/>
        public string Quote => this.QuotationMark;

        /// <inheritdoc cref="QuotationMark"/>
        public string QuotationMark_Double => this.QuotationMark;
    }
}
