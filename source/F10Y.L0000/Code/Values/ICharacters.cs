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
        const char A_Constant = 'A';

        /// <inheritdoc cref="A_Constant" path="/summary"/>
        /// <remarks>
        /// <para>---</para>
        /// <para><self-reference><see cref="A"/></self-reference></para>
        /// <para>Documentation: <inheritdoc cref="A_Constant" path="descendant::documentation-reference"/></para>
        /// </remarks>
        char A => ICharacters.A_Constant;

        #endregion

        #region Alphabet - Lower

        /// <inheritdoc cref="CharactersDocumentation.For_q" path="/summary"/>
        /// <remarks>
        /// <para>---</para>
        /// <para><self-reference><see cref="q_Constant"/></self-reference></para>
        /// <para>Documentation: <documentation-reference><inheritdoc cref="CharactersDocumentation.For_q" path="descendant::self-reference"/></documentation-reference></para>
        /// </remarks>
        const char q_Constant = 'q';

        /// <inheritdoc cref="q_Constant" path="/summary"/>
        /// <remarks>
        /// <para>---</para>
        /// <para><self-reference><see cref="q"/></self-reference></para>
        /// <para>Documentation: <inheritdoc cref="q_Constant" path="descendant::documentation-reference"/></para>
        /// </remarks>
        char q => ICharacters.q_Constant;

        /// <inheritdoc cref="CharactersDocumentation.For_v" path="/summary"/>
        /// <remarks>
        /// <para>---</para>
        /// <para><self-reference><see cref="v_Constant"/></self-reference></para>
        /// <para>Documentation: <documentation-reference><inheritdoc cref="CharactersDocumentation.For_v" path="descendant::self-reference"/></documentation-reference></para>
        /// </remarks>
        const char v_Constant = 'v';

        /// <inheritdoc cref="v_Constant" path="/summary"/>
        /// <remarks>
        /// <para>---</para>
        /// <para><self-reference><see cref="v"/></self-reference></para>
        /// <para>Documentation: <inheritdoc cref="v_Constant" path="descendant::documentation-reference"/></para>
        /// </remarks>
        char v => ICharacters.v_Constant;

        #endregion

        #region Control

        /// <inheritdoc cref="CharactersDocumentation.For_Escape" path="/summary"/>
        /// <remarks>
        /// <para>---</para>
        /// <para><self-reference><see cref="Escape_Constant"/></self-reference></para>
        /// <para>Documentation: <documentation-reference><inheritdoc cref="CharactersDocumentation.For_Escape" path="descendant::self-reference"/></documentation-reference></para>
        /// </remarks>
        const char Escape_Constant = '\u001b'; // Hexadecimal for 27.

        /// <inheritdoc cref="Escape_Constant" path="/summary"/>
        /// <remarks>
        /// <para>---</para>
        /// <para><self-reference><see cref="Escape"/></self-reference></para>
        /// <para>Documentation: <inheritdoc cref="Escape_Constant" path="descendant::documentation-reference"/></para>
        /// </remarks>
        char Escape => ICharacters.Escape_Constant;

        #endregion

        #region Punctuation

        /// <inheritdoc cref="CharactersDocumentation.For_BackSlash" path="/summary"/>
        /// <remarks>
        /// <para>---</para>
        /// <para><self-reference><see cref="Backslash_Constant"/></self-reference></para>
        /// <para>Documentation: <documentation-reference><inheritdoc cref="CharactersDocumentation.For_BackSlash" path="descendant::self-reference"/></documentation-reference></para>
        /// </remarks>
        const char Backslash_Constant = '\\';

        /// <inheritdoc cref="Backslash_Constant" path="/summary"/>
        /// <remarks>
        /// <para>---</para>
        /// <para><self-reference><see cref="Backslash"/></self-reference></para>
        /// <para>Documentation: <inheritdoc cref="Backslash_Constant" path="descendant::documentation-reference"/></para>
        /// </remarks>
        char Backslash => ICharacters.Backslash_Constant;

        /// <inheritdoc cref="CharactersDocumentation.For_CarriageReturn" path="/summary"/>
        /// <remarks>
        /// <para>---</para>
        /// <para><self-reference><see cref="CarriageReturn_Constant"/></self-reference></para>
        /// <para>Documentation: <documentation-reference><inheritdoc cref="CharactersDocumentation.For_CarriageReturn" path="descendant::self-reference"/></documentation-reference></para>
        /// </remarks>
        const char CarriageReturn_Constant = '\r';

        /// <inheritdoc cref="CarriageReturn_Constant" path="/summary"/>
        /// <remarks>
        /// <para>---</para>
        /// <para><self-reference><see cref="CarriageReturn"/></self-reference></para>
        /// <para>Documentation: <inheritdoc cref="CarriageReturn_Constant" path="descendant::documentation-reference"/></para>
        /// </remarks>
        char CarriageReturn => ICharacters.CarriageReturn_Constant;

        /// <inheritdoc cref="CharactersDocumentation.For_CloseBrace" path="/summary"/>
        /// <remarks>
        /// <para>---</para>
        /// <para><self-reference><see cref="CloseBrace_Constant"/></self-reference></para>
        /// <para>Documentation: <documentation-reference><inheritdoc cref="CharactersDocumentation.For_CloseBrace" path="descendant::self-reference"/></documentation-reference></para>
        /// </remarks>
        const char CloseBrace_Constant = '}';

        /// <inheritdoc cref="CloseBrace_Constant" path="/summary"/>
        /// <remarks>
        /// <para>---</para>
        /// <para><self-reference><see cref="CloseBrace"/></self-reference></para>
        /// <para>Documentation: <inheritdoc cref="CloseBrace_Constant" path="descendant::documentation-reference"/></para>
        /// </remarks>
        char CloseBrace => ICharacters.CloseBrace_Constant;

        /// <inheritdoc cref="CharactersDocumentation.For_CloseBracket" path="/summary"/>
        /// <remarks>
        /// <para>---</para>
        /// <para><self-reference><see cref="CloseBracket_Constant"/></self-reference></para>
        /// <para>Documentation: <documentation-reference><inheritdoc cref="CharactersDocumentation.For_CloseBracket" path="descendant::self-reference"/></documentation-reference></para>
        /// </remarks>
        const char CloseBracket_Constant = ']';

        /// <inheritdoc cref="CloseBracket_Constant" path="/summary"/>
        /// <remarks>
        /// <para>---</para>
        /// <para><self-reference><see cref="CloseBracket"/></self-reference></para>
        /// <para>Documentation: <inheritdoc cref="CloseBracket_Constant" path="descendant::documentation-reference"/></para>
        /// </remarks>
        char CloseBracket => ICharacters.CloseBracket_Constant;

        /// <inheritdoc cref="CharactersDocumentation.For_Comma" path="/summary"/>
        /// <remarks>
        /// <para>---</para>
        /// <para><self-reference><see cref="Comma_Constant"/></self-reference></para>
        /// <para>Documentation: <documentation-reference><inheritdoc cref="CharactersDocumentation.For_Comma" path="descendant::self-reference"/></documentation-reference></para>
        /// </remarks>
        const char Comma_Constant = ',';

        /// <inheritdoc cref="Comma_Constant" path="/summary"/>
        /// <remarks>
        /// <para>---</para>
        /// <para><self-reference><see cref="Comma"/></self-reference></para>
        /// <para>Documentation: <inheritdoc cref="Comma_Constant" path="descendant::documentation-reference"/></para>
        /// </remarks>
        char Comma => ICharacters.Comma_Constant;

        /// <inheritdoc cref="CharactersDocumentation.For_Dash" path="/summary"/>
        /// <remarks>
        /// <para>---</para>
        /// <para><self-reference><see cref="Dash_Constant"/></self-reference></para>
        /// <para>Documentation: <documentation-reference><inheritdoc cref="CharactersDocumentation.For_Dash" path="descendant::self-reference"/></documentation-reference></para>
        /// </remarks>
        const char Dash_Constant = ',';

        /// <inheritdoc cref="Dash_Constant" path="/summary"/>
        /// <remarks>
        /// <para>---</para>
        /// <para><self-reference><see cref="Dash"/></self-reference></para>
        /// <para>Documentation: <inheritdoc cref="Dash_Constant" path="descendant::documentation-reference"/></para>
        /// </remarks>
        char Dash => ICharacters.Dash_Constant;

        /// <inheritdoc cref="CharactersDocumentation.For_Equals" path="/summary"/>
        /// <remarks>
        /// <para>---</para>
        /// <para><self-reference><see cref="Equals_Constant"/></self-reference></para>
        /// <para>Documentation: <documentation-reference><inheritdoc cref="CharactersDocumentation.For_Equals" path="descendant::self-reference"/></documentation-reference></para>
        /// </remarks>
        const char Equals_Constant = '=';

        /// <inheritdoc cref="Equals_Constant" path="/summary"/>
        /// <remarks>
        /// <para>---</para>
        /// <para><self-reference><see cref="Equals"/></self-reference></para>
        /// <para>Documentation: <inheritdoc cref="Equals_Constant" path="descendant::documentation-reference"/></para>
        /// </remarks>
        char Equals => ICharacters.Equals_Constant;

        /// <inheritdoc cref="CharactersDocumentation.For_OpenBrace" path="/summary"/>
        /// <remarks>
        /// <para>---</para>
        /// <para><self-reference><see cref="OpenBrace_Constant"/></self-reference></para>
        /// <para>Documentation: <documentation-reference><inheritdoc cref="CharactersDocumentation.For_OpenBrace" path="descendant::self-reference"/></documentation-reference></para>
        /// </remarks>
        const char OpenBrace_Constant = '{';

        /// <inheritdoc cref="OpenBrace_Constant" path="/summary"/>
        /// <remarks>
        /// <para>---</para>
        /// <para><self-reference><see cref="OpenBrace"/></self-reference></para>
        /// <para>Documentation: <inheritdoc cref="OpenBrace_Constant" path="descendant::documentation-reference"/></para>
        /// </remarks>
        char OpenBrace => ICharacters.OpenBrace_Constant;

        /// <inheritdoc cref="CharactersDocumentation.For_OpenBracket" path="/summary"/>
        /// <remarks>
        /// <para>---</para>
        /// <para><self-reference><see cref="OpenBracket_Constant"/></self-reference></para>
        /// <para>Documentation: <documentation-reference><inheritdoc cref="CharactersDocumentation.For_OpenBracket" path="descendant::self-reference"/></documentation-reference></para>
        /// </remarks>
        const char OpenBracket_Constant = '[';

        /// <inheritdoc cref="OpenBracket_Constant" path="/summary"/>
        /// <remarks>
        /// <para>---</para>
        /// <para><self-reference><see cref="OpenBracket"/></self-reference></para>
        /// <para>Documentation: <inheritdoc cref="OpenBracket_Constant" path="descendant::documentation-reference"/></para>
        /// </remarks>
        char OpenBracket => ICharacters.OpenBracket_Constant;

        /// <inheritdoc cref="CharactersDocumentation.For_Period" path="/summary"/>
        /// <remarks>
        /// <para>---</para>
        /// <para><self-reference><see cref="Period_Constant"/></self-reference></para>
        /// <para>Documentation: <documentation-reference><inheritdoc cref="CharactersDocumentation.For_Period" path="descendant::self-reference"/></documentation-reference></para>
        /// </remarks>
        const char Period_Constant = '.';

        /// <inheritdoc cref="Period_Constant" path="/summary"/>
        /// <remarks>
        /// <para>---</para>
        /// <para><self-reference><see cref="Period"/></self-reference></para>
        /// <para>Documentation: <inheritdoc cref="Period_Constant" path="descendant::documentation-reference"/></para>
        /// </remarks>
        char Period => ICharacters.Period_Constant;


        /// <inheritdoc cref="CharactersDocumentation.For_Pipe" path="/summary"/>
        /// <remarks>
        /// <para>---</para>
        /// <para><self-reference><see cref="Pipe_Constant"/></self-reference></para>
        /// <para>Documentation: <documentation-reference><inheritdoc cref="CharactersDocumentation.For_Pipe" path="descendant::self-reference"/></documentation-reference></para>
        /// </remarks>
        const char Pipe_Constant = '|';

        /// <inheritdoc cref="Pipe_Constant" path="/summary"/>
        /// <remarks>
        /// <para>---</para>
        /// <para><self-reference><see cref="Pipe"/></self-reference></para>
        /// <para>Documentation: <inheritdoc cref="Pipe_Constant" path="descendant::documentation-reference"/></para>
        /// </remarks>
        char Pipe => ICharacters.Pipe_Constant;


        /// <inheritdoc cref="CharactersDocumentation.For_Slash" path="/summary"/>
        /// <remarks>
        /// <para>---</para>
        /// <para><self-reference><see cref="Slash_Constant"/></self-reference></para>
        /// <para>Documentation: <documentation-reference><inheritdoc cref="CharactersDocumentation.For_Slash" path="descendant::self-reference"/></documentation-reference></para>
        /// </remarks>
        const char Slash_Constant = '/';

        /// <inheritdoc cref="Slash_Constant" path="/summary"/>
        /// <remarks>
        /// <para>---</para>
        /// <para><self-reference><see cref="Slash"/></self-reference></para>
        /// <para>Documentation: <inheritdoc cref="Slash_Constant" path="descendant::documentation-reference"/></para>
        /// </remarks>
        char Slash => ICharacters.Slash_Constant;

        /// <inheritdoc cref="CharactersDocumentation.For_Space" path="/summary"/>
        /// <remarks>
        /// <para>---</para>
        /// <para><self-reference><see cref="Space_Constant"/></self-reference></para>
        /// <para>Documentation: <documentation-reference><inheritdoc cref="CharactersDocumentation.For_Space" path="descendant::self-reference"/></documentation-reference></para>
        /// </remarks>
        const char Space_Constant = ' ';

        /// <inheritdoc cref="Space_Constant" path="/summary"/>
        /// <remarks>
        /// <para>---</para>
        /// <para><self-reference><see cref="Space"/></self-reference></para>
        /// <para>Documentation: <inheritdoc cref="Space_Constant" path="descendant::documentation-reference"/></para>
        /// </remarks>
        char Space => ICharacters.Space_Constant;


        /// <inheritdoc cref="CharactersDocumentation.For_Underscore" path="/summary"/>
        /// <remarks>
        /// <para>---</para>
        /// <para><self-reference><see cref="Underscore_Constant"/></self-reference></para>
        /// <para>Documentation: <documentation-reference><inheritdoc cref="CharactersDocumentation.For_Underscore" path="descendant::self-reference"/></documentation-reference></para>
        /// </remarks>
        const char Underscore_Constant = '_';

        /// <inheritdoc cref="Space_Constant" path="/summary"/>
        /// <remarks>
        /// <para>---</para>
        /// <para><self-reference><see cref="Underscore"/></self-reference></para>
        /// <para>Documentation: <inheritdoc cref="Underscore_Constant" path="descendant::documentation-reference"/></para>
        /// </remarks>
        char Underscore => ICharacters.Underscore_Constant;

        #endregion


        /// <inheritdoc cref="CharactersDocumentation.For_Colon"/>
        const char Colon_Constant = ':';

        /// <inheritdoc cref="Colon_Constant"/>
        char Colon => ICharacters.Colon_Constant;

        /// <inheritdoc cref="CharactersDocumentation.For_NewLine"/>
        const char NewLine_Constant = '\n';

        /// <inheritdoc cref="NewLine_Constant"/>
        char NewLine => ICharacters.NewLine_Constant;

        /// <inheritdoc cref="CharactersDocumentation.For_Null"/>
        const char Null_Constant = '\0';

        /// <inheritdoc cref="Null_Constant"/>
        char Null => ICharacters.Null_Constant;

        /// <inheritdoc cref="CharactersDocumentation.For_QuotationMark"/>
        const char QuotationMark_Constant = '"';

        /// <inheritdoc cref="QuotationMark_Constant"/>
        char QuotationMark => ICharacters.QuotationMark_Constant;

        /// <inheritdoc cref="CharactersDocumentation.For_Tab"/>
        const char Tab_Constant = '\t';

        /// <inheritdoc cref="Tab_Constant"/>
        char Tab => ICharacters.Tab_Constant;

#pragma warning restore IDE1006 // Naming Styles
    }
}
