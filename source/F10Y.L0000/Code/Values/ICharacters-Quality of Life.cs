using System;


namespace F10Y.L0000
{
    public partial interface ICharacters
    {
        /// <inheritdoc cref="CloseBracket"/>
        public char Bracket_Close => this.CloseBracket;

        /// <inheritdoc cref="OpenBracket"/>
        public char Bracket_Open => this.OpenBracket;

        /// <inheritdoc cref="QuotationMark"/>
        public char Quote => this.QuotationMark;

        /// <inheritdoc cref="QuotationMark"/>
        public char QuotationMark_Double => this.QuotationMark;
    }
}
