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
        const char ArgumentListSeparator_Constant = ',';

        /// <inheritdoc cref="ArgumentListSeparator_Constant"/>
        char ArgumentListSeparator => ArgumentListSeparator_Constant;

        /// <summary>
        /// <para>'[' (open brace)</para>
        /// </summary>
        const char ArrayOpenSeparator_Constant = '[';

        /// <inheritdoc cref="ArrayOpenSeparator_Constant"/>
        char ArrayOpenSeparator => ArrayOpenSeparator_Constant;

        /// <summary>
        /// <para>']' (close brace)</para>
        /// </summary>
        const char ArrayCloseSeparator_Constant = ']';

        /// <inheritdoc cref="ArrayCloseSeparator_Constant"/>
        char ArrayCloseSeparator => ArrayCloseSeparator_Constant;

        /// <summary>
        /// <para>'[' (open brace)</para>
        /// </summary>
        const char AttributeOpenSeparator_Constant = '[';

        /// <inheritdoc cref="AttributeOpenSeparator_Constant"/>
        char AttributeOpenSeparator => AttributeOpenSeparator_Constant;

        /// <summary>
        /// <para>']' (close brace)</para>
        /// </summary>
        const char AttributeCloseSeparator_Constant = ']';

        /// <inheritdoc cref="AttributeCloseSeparator_Constant"/>
        char AttributeCloseSeparator => AttributeCloseSeparator_Constant;

        /// <summary>
        /// <para>'#' (hash)</para>
        /// In the type input lists of explicitly implemented members, the namespaced token separator changes from '.' to '#'.
        /// </summary>
        const char ExplicitImplementationNamespaceTokenSeparator_Constant = '#';

        /// <inheritdoc cref="ExplicitImplementationNamespaceTokenSeparator_Constant"/>
        char ExplicitImplementationNamespaceTokenSeparator => ExplicitImplementationNamespaceTokenSeparator_Constant;

        /// <summary>
        /// <para>'@' (alphasand)</para>
        /// In the type input lists of explicitly implemented members, the type name separator changes from ',' to '@'.
        /// </summary>
        const char ExplicitImplementationArgumentListSeparator_Constant = '@';

        /// <inheritdoc cref="ExplicitImplementationArgumentListSeparator_Constant"/>
        char ExplicitImplementationArgumentListSeparator => ExplicitImplementationArgumentListSeparator_Constant;

        /// <summary>
        /// <para>'&lt;' (open angle-bracket)</para>
        /// Used for both type parameter, and type argument lists.
        /// </summary>
        const char GenericTypeListOpenTokenSeparator_Constant = '<';

        /// <inheritdoc cref="GenericTypeListOpenTokenSeparator_Constant"/>
        char GenericTypeListOpenTokenSeparator => GenericTypeListOpenTokenSeparator_Constant;

        /// <summary>
        /// <para>'&gt;' (close angle-bracket)</para>
        /// </summary>
        const char GenericTypeListCloseTokenSeparator_Constant = '>';

        /// <inheritdoc cref="GenericTypeListCloseTokenSeparator_Constant"/>
        char GenericTypeListCloseTokenSeparator => GenericTypeListCloseTokenSeparator_Constant;

        /// <summary>
        /// <para>'`1' (two back-ticks)</para>
        /// </summary>
        const string MethodTypeParameterCountSeparator_Constant = "``";

        /// <inheritdoc cref="MethodTypeParameterCountSeparator_Constant"/>
        string MethodTypeParameterCountSeparator => MethodTypeParameterCountSeparator_Constant;

        /// <summary>
        /// <para><name>'.' (period)</name></para>
        /// Separates tokens in a namespace name (e.g. System.String) from each other.
        /// </summary>
        const char NamespaceNameTokenSeparator_Constant = ICharacters.Period_Constant;

        /// <inheritdoc cref="NamespaceNameTokenSeparator_Constant"/>
        char NamespaceNameTokenSeparator => NamespaceNameTokenSeparator_Constant;

        /// <summary>
        /// <para><name>'.' (period)</name></para>
        /// Separates tokens in a namespace name (e.g. System.String) from each other.
        /// </summary>
        const string NamespaceNameTokenSeparator_String_Constant = IStrings.Period_Constant;

        /// <inheritdoc cref="NamespaceNameTokenSeparator_String_Constant"/>
        string NamespaceNameTokenSeparator_String => NamespaceNameTokenSeparator_String_Constant;

        /// <summary>
        /// <para><name>'+' (plus)</name></para>
        /// Separates tokens in a nested type name (parent type name, child type name) from each other.
        /// </summary>
        const char NestedTypeNameTokenSeparator_Constant = '+';

        /// <inheritdoc cref="NestedTypeNameTokenSeparator_Constant"/>
        char NestedTypeNameTokenSeparator => NestedTypeNameTokenSeparator_Constant;

        /// <inheritdoc cref="NestedTypeNameTokenSeparator_Constant"/>
        const string NestedTypeNameTokenSeparator_String_Constant = "+";

        /// <inheritdoc cref="NestedTypeNameTokenSeparator_String_Constant"/>
        string NestedTypeNameTokenSeparator_String => NestedTypeNameTokenSeparator_String_Constant;

        /// <summary>
        /// <para>')' (close-parenthesis)</para>
        /// Closes the parameter list for a method identity string.
        /// </summary>
        const char ParameterListCloseTokenSeparator_Constant = ')';

        /// <inheritdoc cref="ParameterListCloseTokenSeparator_Constant"/>
        char ParameterListCloseTokenSeparator => ParameterListCloseTokenSeparator_Constant;

        /// <summary>
        /// <para>'(' (open-parenthesis)</para>
        /// Separates the namespaced, typed, method name from its parameter list.
        /// </summary>
        const char ParameterListOpenTokenSeparator_Constant = '(';

        /// <inheritdoc cref="ParameterListOpenTokenSeparator_Constant"/>
        char ParameterListOpenTokenSeparator => ParameterListOpenTokenSeparator_Constant;

        /// <summary>
        /// <para>' ' (space)</para>
        /// Separates the namespaced type name of a parameter from the name of a parameter.
        /// </summary>
        const char ParameterNameTokenSeparator_Constant = ' ';

        /// <inheritdoc cref="ParameterNameTokenSeparator_Constant"/>
        char ParameterNameTokenSeparator => ParameterNameTokenSeparator_Constant;

        /// <summary>
        /// <para>' ' (space)</para>
        /// Separates the namespaced type name of a parameter from the name of a parameter.
        /// </summary>
        const string ParameterNameTokenSeparator_String_Constant = " ";

        /// <inheritdoc cref="ParameterNameTokenSeparator_String_Constant"/>
        string ParameterNameTokenSeparator_String => ParameterNameTokenSeparator_String_Constant;

        /// <summary>
        /// <para><name>'&lt;' (open-angle bracket)</name></para>
        /// </summary>
        const char TypeArgumentListOpenTokenSeparator_Constant = '<';

        /// <inheritdoc cref="TypeArgumentListOpenTokenSeparator_Constant"/>
        char TypeArgumentListOpenTokenSeparator => TypeArgumentListOpenTokenSeparator_Constant;

        /// <summary>
        /// <para><name>'>' (close-angle bracket)</name></para>
        /// </summary>
        const char TypeArgumentListCloseTokenSeparator_Constant = '>';

        /// <inheritdoc cref="TypeArgumentListCloseTokenSeparator_Constant"/>
        char TypeArgumentListCloseTokenSeparator => TypeArgumentListCloseTokenSeparator_Constant;


        /// <summary>
        /// <para><name>'{' (open-brace)</name></para>
        /// </summary>
        const char TypeArgumentList_InParameterContext_OpenTokenSeparator_Constant = '{';

        /// <inheritdoc cref="TypeArgumentList_InParameterContext_OpenTokenSeparator_Constant"/>
        char TypeArgumentList_InParameterContext_OpenTokenSeparator => TypeArgumentList_InParameterContext_OpenTokenSeparator_Constant;

        /// <summary>
        /// <para><name>'}' (close-brace)</name></para>
        /// </summary>
        const char TypeArgumentList_InParameterContext_CloseTokenSeparator_Constant = '}';

        /// <inheritdoc cref="TypeArgumentList_InParameterContext_CloseTokenSeparator_Constant"/>
        char TypeArgumentList_InParameterContext_CloseTokenSeparator => TypeArgumentList_InParameterContext_CloseTokenSeparator_Constant;


        /// <summary>
        /// <para>'`' (back-tick)</para>
        /// Separates the namespaced type name for type names (or namespaced typed method name for method names)
        /// from the type parameter count and then the rest of the identity name value.
        /// </summary>
        const char TypeParameterCountSeparator_Constant = '`';

        /// <inheritdoc cref="TypeParameterCountSeparator_Constant"/>
        char TypeParameterCountSeparator => TypeParameterCountSeparator_Constant;

        const string TypeParameterCountSeparator_String_Constant = "`";

        /// <inheritdoc cref="TypeParameterCountSeparator_String_Constant"/>
        string TypeParameterCountSeparator_String => TypeParameterCountSeparator_String_Constant;
    }
}
