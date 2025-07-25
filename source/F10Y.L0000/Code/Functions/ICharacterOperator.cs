using System;
using System.Collections.Generic;
using System.Linq;

using F10Y.T0002;

using Glossary = F10Y.Y0000.Glossary;


namespace F10Y.L0000
{
    [FunctionsMarker]
    public partial interface ICharacterOperator
    {
        public bool Are_Equal(
            char a,
            char b)
        {
            var output = a.Equals(b);
            return output;
        }

        /// <summary>
        /// <inheritdoc cref="Glossary.For_CharacterClasses.Digit" path="/definition"/>
        /// </summary>
        public bool Is_Digit(char character)
        {
            // Use is-digit instead of is-number since is-number checks for fractions and Roman numerals as well.
            var output = Char.IsDigit(character);
            return output;
        }

        /// <summary>
        /// <inheritdoc cref="Glossary.For_CharacterClasses.Whitespace" path="/definition"/>
        /// </summary>
        public bool Is_Whitespace(char character)
        {
            var output = Char.IsWhiteSpace(character);
            return output;
        }

        /// <inheritdoc cref="Is_Whitespace(char)"/>
        public bool Is_NotWhitespace(char character)
        {
            var isWhitespace = this.Is_Whitespace(character);

            var output = !isWhitespace;
            return output;
        }

        public string Join_ToString(IEnumerable<char> characters)
             => this.Join_ToString(characters.ToArray());

        public string Join_ToString(params char[] characters)
        {
            var output = new string(characters);
            return output;
        }

        /// <summary>
        /// Chooses the invariant uppering operation as default.
        /// </summary>
        public char To_Upper(char character)
        {
            var output = Char.ToUpperInvariant(character);
            return output;
        }
    }
}
