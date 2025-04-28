using System;

using F10Y.T0003;

using StringsDocumentation = F10Y.Y0000.Documentation.For_Strings;


namespace F10Y.L0000
{
    [ValuesMarker]
    public partial interface IStrings
    {
        /// <inheritdoc cref="StringsDocumentation.For_Copyright"/>
        public const string Copyright_Constant = "©";

        /// <inheritdoc cref="IStrings.Copyright_Constant"/>
        public string Copyright => IStrings.Copyright_Constant;

        /// <inheritdoc cref="StringsDocumentation.For_Empty"/>
        public const string Empty_Constant = "";

        /// <inheritdoc cref="Empty_Constant"/>
        public string Empty => IStrings.Empty_Constant;

        /// <inheritdoc cref="StringsDocumentation.For_NewLine"/>
        public const string NewLine_Constant = "\n";

        /// <inheritdoc cref="NewLine_Constant"/>
        public string NewLine => IStrings.NewLine_Constant;

        /// <inheritdoc cref="StringsDocumentation.For_Null"/>
        public const string Null_Constant = null;

        /// <inheritdoc cref="Null_Constant"/>
        public string Null => IStrings.Null_Constant;

        /// <inheritdoc cref="StringsDocumentation.For_QuotationMark"/>
        public const string QuotationMark_Constant = "\"";

        /// <inheritdoc cref="QuotationMark_Constant"/>
        public string QuotationMark => IStrings.QuotationMark_Constant;

        /// <inheritdoc cref="StringsDocumentation.For_Semicolon"/>
        public const string Semicolon_Constant = ";";

        /// <inheritdoc cref="Semicolon_Constant"/>
        public string Semicolon => IStrings.Semicolon_Constant;

        /// <inheritdoc cref="StringsDocumentation.For_Space"/>
        public const string Space_Constant = " ";

        /// <inheritdoc cref="Space_Constant"/>
        public string Space => IStrings.Space_Constant;


        #region Alphabet - Lowercase


        #endregion


        #region Alphabet - Uppercase

        /// <inheritdoc cref="StringsDocumentation.For_A"/>
        public const string A_Constant = "A";

        /// <inheritdoc cref="A_Constant"/>
        public string A => IStrings.A_Constant;

        /// <inheritdoc cref="StringsDocumentation.For_B"/>
        public const string B_Constant = "B";

        /// <inheritdoc cref="B_Constant"/>
        public string B => IStrings.B_Constant;

        /// <inheritdoc cref="StringsDocumentation.For_C"/>
        public const string C_Constant = "C";

        /// <inheritdoc cref="C_Constant"/>
        public string C => IStrings.C_Constant;

        /// <inheritdoc cref="StringsDocumentation.For_D"/>
        public const string D_Constant = "D";

        /// <inheritdoc cref="D_Constant"/>
        public string D => IStrings.D_Constant;

        /// <inheritdoc cref="StringsDocumentation.For_E"/>
        public const string E_Constant = "E";

        /// <inheritdoc cref="E_Constant"/>
        public string E => IStrings.E_Constant;


        #endregion


        /// <inheritdoc cref="StringsDocumentation.For_False_Lowercase"/>
        public const string False_Lowercase_Constant = "false";

        /// <inheritdoc cref="False_Lowercase_Constant"/>
        public string False_Lowercase => IStrings.False_Lowercase_Constant;

        /// <inheritdoc cref="StringsDocumentation.For_True_Lowercase"/>
        public const string True_Lowercase_Constant = "true";

        /// <inheritdoc cref="True_Lowercase_Constant"/>
        public string True_Lowercase => IStrings.True_Lowercase_Constant;


        /// <inheritdoc cref="StringsDocumentation.For_NewLine_Windows"/>
        public const string NewLine_Windows_Constant = "\r\n";

        /// <inheritdoc cref="NewLine_Windows_Constant"/>
        public string NewLine_Windows => IStrings.NewLine_Windows_Constant;

        /// <inheritdoc cref="NewLine_Constant"/>
        public const string NewLine_NonWindows_Constant = IStrings.NewLine_Constant;

        /// <inheritdoc cref="NewLine_NonWindows_Constant"/>
        public string NewLine_NonWindows => IStrings.NewLine_NonWindows_Constant;
    }
}
