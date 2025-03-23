using System;


namespace F10Y.L0000
{
    public partial interface ICharacters
    {
        /// <inheritdoc cref="QuotationMark"/>
        public char Quote => this.QuotationMark;

        /// <inheritdoc cref="QuotationMark"/>
        public char QuotationMark_Double => this.QuotationMark;
    }
}
