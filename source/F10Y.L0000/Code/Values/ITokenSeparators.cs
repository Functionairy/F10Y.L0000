using System;

using F10Y.T0003;


namespace F10Y.L0000
{
    [ValuesMarker]
    public partial interface ITokenSeparators
    {
        /// <summary>
        /// <para>',' (comma)</para>
        /// </summary>
        public const char ArgumentListSeparator_Constant = ',';

        /// <inheritdoc cref="ArgumentListSeparator_Constant"/>
        public char ArgumentListSeparator => ArgumentListSeparator_Constant;

        /// <summary>
        /// <para>'#' (hash)</para>
        /// In the type input lists of explicitly implemented members, the namespaced token separator changes from '.' to '#'.
        /// </summary>
        public const char ExplicitImplementationNamespaceTokenSeparator_Constant = '#';

        /// <inheritdoc cref="ExplicitImplementationNamespaceTokenSeparator_Constant"/>
        public char ExplicitImplementationNamespaceTokenSeparator => ExplicitImplementationNamespaceTokenSeparator_Constant;

        /// <summary>
        /// <para>'@' (alphasand)</para>
        /// In the type input lists of explicitly implemented members, the type name separator changes from ',' to '@'.
        /// </summary>
        public const char ExplicitImplementationArgumentListSeparator_Constant = '@';

        /// <inheritdoc cref="ExplicitImplementationArgumentListSeparator_Constant"/>
        public char ExplicitImplementationArgumentListSeparator => ExplicitImplementationArgumentListSeparator_Constant;

        /// <summary>
        /// <para>'&lt;' (open angle-bracket)</para>
        /// Used for both type parameter, and type argument lists.
        /// </summary>
        public const char GenericTypeListOpenTokenSeparator_Constant = '<';

        /// <inheritdoc cref="GenericTypeListOpenTokenSeparator_Constant"/>
        public char GenericTypeListOpenTokenSeparator => GenericTypeListOpenTokenSeparator_Constant;

        /// <summary>
        /// <para>'&gt;' (close angle-bracket)</para>
        /// </summary>
        public const char GenericTypeListCloseTokenSeparator_Constant = '>';

        /// <inheritdoc cref="GenericTypeListCloseTokenSeparator_Constant"/>
        public char GenericTypeListCloseTokenSeparator => GenericTypeListCloseTokenSeparator_Constant;

        /// <summary>
        /// <para>'`1' (two back-ticks)</para>
        /// </summary>
        public const string MethodTypeParameterCountSeparator_Constant = "``";

        /// <inheritdoc cref="MethodTypeParameterCountSeparator_Constant"/>
        public string MethodTypeParameterCountSeparator => MethodTypeParameterCountSeparator_Constant;

        /// <summary>
        /// <para><name>'.' (period)</name></para>
        /// Separates tokens in a namespace name (e.g. System.String) from each other.
        /// </summary>
        public const char NamespaceNameTokenSeparator_Constant = ICharacters.Period_Constant;

        /// <inheritdoc cref="NamespaceNameTokenSeparator_Constant"/>
        public char NamespaceNameTokenSeparator => NamespaceNameTokenSeparator_Constant;

        /// <summary>
        /// <para><name>'.' (period)</name></para>
        /// Separates tokens in a namespace name (e.g. System.String) from each other.
        /// </summary>
        public const string NamespaceNameTokenSeparator_String_Constant = IStrings.Period_Constant;

        /// <inheritdoc cref="NamespaceNameTokenSeparator_String_Constant"/>
        public string NamespaceNameTokenSeparator_String => NamespaceNameTokenSeparator_String_Constant;

        /// <summary>
        /// <para><name>'+' (plus)</name></para>
        /// Separates tokens in a nested type name (parent type name, child type name) from each other.
        /// </summary>
        public const char NestedTypeNameTokenSeparator_Constant = '+';

        /// <inheritdoc cref="NestedTypeNameTokenSeparator_Constant"/>
        public char NestedTypeNameTokenSeparator => NestedTypeNameTokenSeparator_Constant;

        /// <inheritdoc cref="NestedTypeNameTokenSeparator_Constant"/>
        public const string NestedTypeNameTokenSeparator_String_Constant = "+";

        /// <inheritdoc cref="NestedTypeNameTokenSeparator_String_Constant"/>
        public string NestedTypeNameTokenSeparator_String => NestedTypeNameTokenSeparator_String_Constant;

        /// <summary>
        /// <para>')' (close-parenthesis)</para>
        /// Closes the parameter list for a method identity string.
        /// </summary>
        public const char ParameterListCloseTokenSeparator_Constant = ')';

        /// <inheritdoc cref="ParameterListCloseTokenSeparator_Constant"/>
        public char ParameterListCloseTokenSeparator => ParameterListCloseTokenSeparator_Constant;

        /// <summary>
        /// <para>'(' (open-parenthesis)</para>
        /// Separates the namespaced, typed, method name from its parameter list.
        /// </summary>
        public const char ParameterListOpenTokenSeparator_Constant = '(';

        /// <inheritdoc cref="ParameterListOpenTokenSeparator_Constant"/>
        public char ParameterListOpenTokenSeparator => ParameterListOpenTokenSeparator_Constant;

        /// <summary>
        /// <para>' ' (space)</para>
        /// Separates the namespaced type name of a parameter from the name of a parameter.
        /// </summary>
        public const char ParameterNameTokenSeparator_Constant = ' ';

        /// <inheritdoc cref="ParameterNameTokenSeparator_Constant"/>
        public char ParameterNameTokenSeparator => ParameterNameTokenSeparator_Constant;

        /// <summary>
        /// <para>' ' (space)</para>
        /// Separates the namespaced type name of a parameter from the name of a parameter.
        /// </summary>
        public const string ParameterNameTokenSeparator_String_Constant = " ";

        /// <inheritdoc cref="ParameterNameTokenSeparator_String_Constant"/>
        public string ParameterNameTokenSeparator_String => ParameterNameTokenSeparator_String_Constant;

        /// <summary>
        /// <para><name>'&lt;' (open-angle bracket)</name></para>
        /// </summary>
        public const char TypeArgumentListOpenTokenSeparator_Constant = '<';

        /// <inheritdoc cref="TypeArgumentListOpenTokenSeparator_Constant"/>
        public char TypeArgumentListOpenTokenSeparator => TypeArgumentListOpenTokenSeparator_Constant;

        /// <summary>
        /// <para><name>'>' (close-angle bracket)</name></para>
        /// </summary>
        public const char TypeArgumentListCloseTokenSeparator_Constant = '>';

        /// <inheritdoc cref="TypeArgumentListCloseTokenSeparator_Constant"/>
        public char TypeArgumentListCloseTokenSeparator => TypeArgumentListCloseTokenSeparator_Constant;

        /// <summary>
        /// <para>'`' (back-tick)</para>
        /// Separates the namespaced type name for type names (or namespaced typed method name for method names)
        /// from the type parameter count and then the rest of the identity name value.
        /// </summary>
        public const char TypeParameterCountSeparator_Constant = '`';

        /// <inheritdoc cref="TypeParameterCountSeparator_Constant"/>
        public char TypeParameterCountSeparator => TypeParameterCountSeparator_Constant;

        public const string TypeParameterCountSeparator_String_Constant = "`";

        /// <inheritdoc cref="TypeParameterCountSeparator_String_Constant"/>
        public string TypeParameterCountSeparator_String => TypeParameterCountSeparator_String_Constant;
    }
}
