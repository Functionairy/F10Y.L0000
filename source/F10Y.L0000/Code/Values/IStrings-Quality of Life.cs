using System;


namespace F10Y.L0000
{
    public partial interface IStrings
    {
        /// <inheritdoc cref="QuotationMark"/>
        public string Quote => this.QuotationMark;

        /// <inheritdoc cref="QuotationMark"/>
        public string QuotationMark_Double => this.QuotationMark;
    }
}
