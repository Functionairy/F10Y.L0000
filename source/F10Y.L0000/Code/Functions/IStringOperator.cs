using System;

using F10Y.T0002;


namespace F10Y.L0000
{
    [FunctionsMarker]
    public partial interface IStringOperator
    {
        /// <summary>
        /// Ensure the first and last characters of a string are a <inheritdoc cref="ICharacters.QuotationMark" path="descendant::name"/> (<inheritdoc cref="ICharacters.QuotationMark" path="descendant::value"/>)
        /// by adding characters if necessary.
        /// </summary>
        public string Ensure_Enquoted(string @string)
        {
            var firstChar = this.Get_Character_First(@string);
            var lastChar = this.Get_Character_Last(@string);

            var firstQuotationMarkToken = firstChar == Instances.Characters.QuotationMark
                ? Instances.Strings.Empty
                : Instances.Strings.Quote
                ;

            var lastQuotationMarkToken = lastChar == Instances.Characters.QuotationMark
                ? Instances.Strings.Empty
                : Instances.Strings.Quote
                ;

            var output = $"{firstQuotationMarkToken}{@string}{lastQuotationMarkToken}";
            return output;
        }

        /// <summary>
        /// Returns the character at the provided index.
        /// </summary>
        public char Get_Character(
            string @string,
            int index)
        {
            var output = @string[index];
            return output;
        }

        public char Get_Character_First(string @string)
            => this.Get_Character(
                @string,
                Instances.Indices.Zero);

        public char Get_Character_Last(string @string)
        {
            var lastIndex = this.Get_IndexOf_Last(@string);

            var output = this.Get_Character(
                @string,
                lastIndex);

            return output;
        }

        public int Get_IndexOf_Last(string @string)
        {
            var length = this.Get_Length(@string);

            var lastIndex = Instances.IndexOperator.Get_LastIndex_FromLength(length);
            return lastIndex;
        }

        public int Get_Length(string @string)
            => @string.Length;
    }
}
