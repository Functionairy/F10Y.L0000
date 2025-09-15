using System;

using F10Y.T0003;

using CharactersDocumentation = F10Y.Y0000.Documentation.For_Characters;


namespace F10Y.L0000
{
    [ValuesMarker]
    public partial interface ICharacters
    {
#pragma warning disable IDE1006 // Naming Styles

        #region Alphabet - Upper

        /// <inheritdoc cref="CharactersDocumentation.For_A" path="/summary"/>
        /// <remarks>
        /// <para>---</para>
        /// <para><self-reference><see cref="A_Constant"/></self-reference></para>
        /// <para>Documentation: <documentation-reference><inheritdoc cref="CharactersDocumentation.For_A" path="descendant::self-reference"/></documentation-reference></para>
        /// </remarks>
        public const char A_Constant = 'A';

        /// <inheritdoc cref="A_Constant" path="/summary"/>
        /// <remarks>
        /// <para>---</para>
        /// <para><self-reference><see cref="A"/></self-reference></para>
        /// <para>Documentation: <inheritdoc cref="A_Constant" path="descendant::documentation-reference"/></para>
        /// </remarks>
        public char A => ICharacters.A_Constant;

        #endregion

        #region Alphabet - Lower

        /// <inheritdoc cref="CharactersDocumentation.For_q" path="/summary"/>
        /// <remarks>
        /// <para>---</para>
        /// <para><self-reference><see cref="q_Constant"/></self-reference></para>
        /// <para>Documentation: <documentation-reference><inheritdoc cref="CharactersDocumentation.For_q" path="descendant::self-reference"/></documentation-reference></para>
        /// </remarks>
        public const char q_Constant = 'q';

        /// <inheritdoc cref="q_Constant" path="/summary"/>
        /// <remarks>
        /// <para>---</para>
        /// <para><self-reference><see cref="q"/></self-reference></para>
        /// <para>Documentation: <inheritdoc cref="q_Constant" path="descendant::documentation-reference"/></para>
        /// </remarks>
        public char q => ICharacters.q_Constant;

        /// <inheritdoc cref="CharactersDocumentation.For_v" path="/summary"/>
        /// <remarks>
        /// <para>---</para>
        /// <para><self-reference><see cref="v_Constant"/></self-reference></para>
        /// <para>Documentation: <documentation-reference><inheritdoc cref="CharactersDocumentation.For_v" path="descendant::self-reference"/></documentation-reference></para>
        /// </remarks>
        public const char v_Constant = 'v';

        /// <inheritdoc cref="v_Constant" path="/summary"/>
        /// <remarks>
        /// <para>---</para>
        /// <para><self-reference><see cref="v"/></self-reference></para>
        /// <para>Documentation: <inheritdoc cref="v_Constant" path="descendant::documentation-reference"/></para>
        /// </remarks>
        public char v => ICharacters.v_Constant;

        #endregion

        #region Control

        /// <inheritdoc cref="CharactersDocumentation.For_Escape" path="/summary"/>
        /// <remarks>
        /// <para>---</para>
        /// <para><self-reference><see cref="Escape_Constant"/></self-reference></para>
        /// <para>Documentation: <documentation-reference><inheritdoc cref="CharactersDocumentation.For_Escape" path="descendant::self-reference"/></documentation-reference></para>
        /// </remarks>
        public const char Escape_Constant = '\u001b'; // Hexadecimal for 27.

        /// <inheritdoc cref="Escape_Constant" path="/summary"/>
        /// <remarks>
        /// <para>---</para>
        /// <para><self-reference><see cref="Escape"/></self-reference></para>
        /// <para>Documentation: <inheritdoc cref="Escape_Constant" path="descendant::documentation-reference"/></para>
        /// </remarks>
        public char Escape => ICharacters.Escape_Constant;

        #endregion

        /// <inheritdoc cref="CharactersDocumentation.For_BackSlash" path="/summary"/>
        /// <remarks>
        /// <para>---</para>
        /// <para><self-reference><see cref="Backslash_Constant"/></self-reference></para>
        /// <para>Documentation: <documentation-reference><inheritdoc cref="CharactersDocumentation.For_BackSlash" path="descendant::self-reference"/></documentation-reference></para>
        /// </remarks>
        public const char Backslash_Constant = '\\';

        /// <inheritdoc cref="Backslash_Constant" path="/summary"/>
        /// <remarks>
        /// <para>---</para>
        /// <para><self-reference><see cref="Backslash"/></self-reference></para>
        /// <para>Documentation: <inheritdoc cref="Backslash_Constant" path="descendant::documentation-reference"/></para>
        /// </remarks>
        public char Backslash => ICharacters.Backslash_Constant;

        /// <inheritdoc cref="CharactersDocumentation.For_CarriageReturn" path="/summary"/>
        /// <remarks>
        /// <para>---</para>
        /// <para><self-reference><see cref="CarriageReturn_Constant"/></self-reference></para>
        /// <para>Documentation: <documentation-reference><inheritdoc cref="CharactersDocumentation.For_CarriageReturn" path="descendant::self-reference"/></documentation-reference></para>
        /// </remarks>
        public const char CarriageReturn_Constant = '\r';

        /// <inheritdoc cref="CarriageReturn_Constant" path="/summary"/>
        /// <remarks>
        /// <para>---</para>
        /// <para><self-reference><see cref="CarriageReturn"/></self-reference></para>
        /// <para>Documentation: <inheritdoc cref="CarriageReturn_Constant" path="descendant::documentation-reference"/></para>
        /// </remarks>
        public char CarriageReturn => ICharacters.CarriageReturn_Constant;

        /// <inheritdoc cref="CharactersDocumentation.For_Colon"/>
        public const char Colon_Constant = ':';

        /// <inheritdoc cref="Colon_Constant"/>
        public char Colon => ICharacters.Colon_Constant;

        /// <inheritdoc cref="CharactersDocumentation.For_Comma" path="/summary"/>
        /// <remarks>
        /// <para>---</para>
        /// <para><self-reference><see cref="Comma_Constant"/></self-reference></para>
        /// <para>Documentation: <documentation-reference><inheritdoc cref="CharactersDocumentation.For_Comma" path="descendant::self-reference"/></documentation-reference></para>
        /// </remarks>
        public const char Comma_Constant = ',';

        /// <inheritdoc cref="Comma_Constant" path="/summary"/>
        /// <remarks>
        /// <para>---</para>
        /// <para><self-reference><see cref="Comma"/></self-reference></para>
        /// <para>Documentation: <inheritdoc cref="Comma_Constant" path="descendant::documentation-reference"/></para>
        /// </remarks>
        public char Comma => ICharacters.Comma_Constant;

        /// <inheritdoc cref="CharactersDocumentation.For_Equals" path="/summary"/>
        /// <remarks>
        /// <para>---</para>
        /// <para><self-reference><see cref="Equals_Constant"/></self-reference></para>
        /// <para>Documentation: <documentation-reference><inheritdoc cref="CharactersDocumentation.For_Equals" path="descendant::self-reference"/></documentation-reference></para>
        /// </remarks>
        public const char Equals_Constant = '=';

        /// <inheritdoc cref="Equals_Constant" path="/summary"/>
        /// <remarks>
        /// <para>---</para>
        /// <para><self-reference><see cref="Equals"/></self-reference></para>
        /// <para>Documentation: <inheritdoc cref="Equals_Constant" path="descendant::documentation-reference"/></para>
        /// </remarks>
        public char Equals => ICharacters.Equals_Constant;

        /// <inheritdoc cref="CharactersDocumentation.For_NewLine"/>
        public const char NewLine_Constant = '\n';

        /// <inheritdoc cref="NewLine_Constant"/>
        public char NewLine => ICharacters.NewLine_Constant;

        /// <inheritdoc cref="CharactersDocumentation.For_Null"/>
        public const char Null_Constant = '\0';

        /// <inheritdoc cref="Null_Constant"/>
        public char Null => ICharacters.Null_Constant;

        /// <inheritdoc cref="CharactersDocumentation.For_Period" path="/summary"/>
        /// <remarks>
        /// <para>---</para>
        /// <para><self-reference><see cref="Period_Constant"/></self-reference></para>
        /// <para>Documentation: <documentation-reference><inheritdoc cref="CharactersDocumentation.For_Period" path="descendant::self-reference"/></documentation-reference></para>
        /// </remarks>
        public const char Period_Constant = '.';

        /// <inheritdoc cref="Period_Constant" path="/summary"/>
        /// <remarks>
        /// <para>---</para>
        /// <para><self-reference><see cref="Period"/></self-reference></para>
        /// <para>Documentation: <inheritdoc cref="Period_Constant" path="descendant::documentation-reference"/></para>
        /// </remarks>
        public char Period => ICharacters.Period_Constant;

        /// <inheritdoc cref="CharactersDocumentation.For_QuotationMark"/>
        public const char QuotationMark_Constant = '"';

        /// <inheritdoc cref="QuotationMark_Constant"/>
        public char QuotationMark => ICharacters.QuotationMark_Constant;

        /// <inheritdoc cref="CharactersDocumentation.For_Slash" path="/summary"/>
        /// <remarks>
        /// <para>---</para>
        /// <para><self-reference><see cref="Slash_Constant"/></self-reference></para>
        /// <para>Documentation: <documentation-reference><inheritdoc cref="CharactersDocumentation.For_Slash" path="descendant::self-reference"/></documentation-reference></para>
        /// </remarks>
        public const char Slash_Constant = '/';

        /// <inheritdoc cref="Slash_Constant" path="/summary"/>
        /// <remarks>
        /// <para>---</para>
        /// <para><self-reference><see cref="Slash"/></self-reference></para>
        /// <para>Documentation: <inheritdoc cref="Slash_Constant" path="descendant::documentation-reference"/></para>
        /// </remarks>
        public char Slash => ICharacters.Slash_Constant;

        /// <inheritdoc cref="CharactersDocumentation.For_Space" path="/summary"/>
        /// <remarks>
        /// <para>---</para>
        /// <para><self-reference><see cref="Space_Constant"/></self-reference></para>
        /// <para>Documentation: <documentation-reference><inheritdoc cref="CharactersDocumentation.For_Space" path="descendant::self-reference"/></documentation-reference></para>
        /// </remarks>
        public const char Space_Constant = ' ';

        /// <inheritdoc cref="Space_Constant" path="/summary"/>
        /// <remarks>
        /// <para>---</para>
        /// <para><self-reference><see cref="Space"/></self-reference></para>
        /// <para>Documentation: <inheritdoc cref="Space_Constant" path="descendant::documentation-reference"/></para>
        /// </remarks>
        public char Space => ICharacters.Space_Constant;

        /// <inheritdoc cref="CharactersDocumentation.For_Tab"/>
        public const char Tab_Constant = '\t';

        /// <inheritdoc cref="Tab_Constant"/>
        public char Tab => ICharacters.Tab_Constant;

#pragma warning restore IDE1006 // Naming Styles
    }
}
