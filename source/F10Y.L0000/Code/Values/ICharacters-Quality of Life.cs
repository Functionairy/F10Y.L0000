using System;


namespace F10Y.L0000
{
    public partial interface ICharacters
    {
        /// <inheritdoc cref="CloseBrace"/>
        char Brace_Close => this.CloseBrace;

        /// <inheritdoc cref="OpenBrace"/>
        char Brace_Open => this.OpenBrace;

        /// <inheritdoc cref="CloseBracket"/>
        char Bracket_Close => this.CloseBracket;

        /// <inheritdoc cref="OpenBracket"/>
        char Bracket_Open => this.OpenBracket;

        /// <inheritdoc cref="QuotationMark"/>
        char Quote => this.QuotationMark;

        /// <inheritdoc cref="QuotationMark"/>
        char QuotationMark_Double => this.QuotationMark;
    }
}
