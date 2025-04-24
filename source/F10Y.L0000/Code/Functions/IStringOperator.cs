using System;
using System.Collections.Generic;
using System.Globalization;

using F10Y.T0002;


namespace F10Y.L0000
{
    [FunctionsMarker]
    public partial interface IStringOperator
    {
        /// <summary>
        /// Uses the provided <paramref name="caseStandardization_Function"/> to standardized case before comparing.
        /// </summary>
        public bool Are_Equal_CaseInsensitive(
            string a,
            string b,
            Func<string, string> caseStandardization_Function)
        {
            var a_Invariant = caseStandardization_Function(a);
            var b_Invariant = caseStandardization_Function(b);

            var output = this.Are_Equal_CaseSensitive(a_Invariant, b_Invariant);
            return output;
        }

        /// <summary>
        /// Uses <see cref="To_Lower_Invariant(string)"/> as the case standardization function.
        /// </summary>
        public bool Are_Equal_CaseInsensitive(
            string a,
            string b)
            => this.Are_Equal_CaseInsensitive(
                a,
                b,
                this.To_Lower_Invariant);


        public bool Are_Equal_CaseSensitive(
            string a,
            string b)
        {
            var output = a == b;
            return output;
        }

        /// <summary>
        /// A quality-of-life over for <see cref="Are_Equal_CaseSensitive(string, string)"/>.
        /// </summary>
        public bool Are_Equal_Exact(
            string a,
            string b)
            => this.Are_Equal_CaseSensitive(
                a,
                b);

        /// <summary>
        /// Chooses <see cref="Are_Equal_CaseSensitive(string, string)"/> as the default.
        /// </summary>
        public bool Are_Equal(
            string a,
            string b)
            => this.Are_Equal_CaseSensitive(
                a,
                b);

        public string Concatenate(params string[] strings)
            => String.Concat(strings);

        public string Concatenate(IEnumerable<string> strings)
            => String.Concat(strings);

        /// <summary>
        /// Ensure the first and last characters of a string are a <inheritdoc cref="ICharacters.QuotationMark" path="descendant::name"/> (<inheritdoc cref="ICharacters.QuotationMark" path="descendant::value"/>)
        /// by adding characters if necessary.
        /// </summary>
        public string Ensure_Enquoted(string @string)
        {
            var firstChar = this.Get_Character_First(@string);
            var lastChar = this.Get_Character_Last(@string);

            var firstChar_IsQuotationMark = firstChar == Instances.Characters.QuotationMark;
            var lastChar_IsQuotationMark = lastChar == Instances.Characters.QuotationMark;

            var firstQuotationMarkToken = firstChar_IsQuotationMark
                ? Instances.Strings.Empty
                : Instances.Strings.Quote
                ;

            var lastQuotationMarkToken = lastChar_IsQuotationMark
                ? Instances.Strings.Empty
                : Instances.Strings.Quote
                ;

            var output = $"{firstQuotationMarkToken}{@string}{lastQuotationMarkToken}";
            return output;
        }

        public string Format_WithTemplate(
            string template,
            params object[] objects)
        {
            var output = String.Format(
                template,
                objects);

            return output;
        }

        /// <summary>
        /// Chooses <see cref="Format_WithTemplate(string, object[])"/> as the default.
        /// </summary>
        public string Format(
            string template,
            params object[] objects)
            => this.Format_WithTemplate(
                template,
                objects);

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

        /// <summary>
        /// The default <see cref="String.GetHashCode()"/> is non-deterministic.
        /// This method provides a deterministic implementation.
        /// </summary>
        /// <remarks>
        /// Source: https://andrewlock.net/why-is-string-gethashcode-different-each-time-i-run-my-program-in-net-core/#a-deterministic-gethashcode-implementation
        /// </remarks>
        public int Get_HashCode_Deterministic(string @string)
        {
            unchecked
            {
                int hash1 = (5381 << 16) + 5381;
                int hash2 = hash1;

                for (int i = 0; i < @string.Length; i += 2)
                {
                    hash1 = ((hash1 << 5) + hash1) ^ @string[i];

                    if (i == @string.Length - 1)
                        break;

                    hash2 = ((hash2 << 5) + hash2) ^ @string[i + 1];
                }

                return hash1 + (hash2 * 1566083941);
            }
        }

        public int Get_IndexOf_Last(string @string)
        {
            var length = this.Get_Length(@string);

            var lastIndex = Instances.IndexOperator.Get_LastIndex_FromLength(length);
            return lastIndex;
        }

        public int Get_Length(string @string)
            => @string.Length;

        /// <summary>
        /// Determines if the input is specifically the <see cref="IStrings.Empty"/> string.
        /// </summary>
        public bool Is_Empty(string value)
        {
            var isEmpty = value == Instances.Strings.Empty;
            return isEmpty;
        }

        public bool Is_NotNull(string @string)
            => Instances.NullOperator.Is_NotNull(@string);

        public bool Is_Null(string @string)
            => Instances.NullOperator.Is_Null(@string);

        public bool Is_NullOrEmpty(string @string)
            => String.IsNullOrEmpty(@string);

        public string Join(
            char separator,
            IEnumerable<string> strings)
            => String.Join(separator, strings);

        public string Join(
            string separator,
            IEnumerable<string> strings)
            => String.Join(separator, strings);

        /// <summary>
        /// Returns the lowered version of a string.
        /// </summary>
        /// <remarks>
        /// Returns the result of <see cref="String.ToLowerInvariant"/>.
        /// </remarks>
        public string To_Lower_Invariant(string @string)
            => @string.ToLowerInvariant();

        /// <summary>
        /// Chooses <see cref="To_Lower_Invariant(string)"/> as the default.
        /// </summary>
        public string To_Lower(string @string)
            => this.To_Lower_Invariant(@string);

        public string To_Lower(
            string @string,
            CultureInfo cultureInfo)
        {
            var output = @string.ToLower(cultureInfo);
            return output;
        }

        /// <summary>
        /// Returns the uppered version of a string.
        /// </summary>
        /// <remarks>
        /// Returns the result of <see cref="String.ToUpperInvariant"/>.
        /// </remarks>
        public string To_Upper_Invariant(string @string)
            => @string.ToUpperInvariant();

        /// <summary>
        /// Chooses <see cref="To_Upper_Invariant(string)"/> as the default.
        /// </summary>
        public string To_Upper(string @string)
            => this.To_Upper_Invariant(@string);

        public string To_Upper(
            string @string,
            CultureInfo cultureInfo)
        {
            var output = @string.ToUpper(cultureInfo);
            return output;
        }
    }
}
