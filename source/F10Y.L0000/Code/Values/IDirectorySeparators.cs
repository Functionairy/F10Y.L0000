using System;

using F10Y.T0003;


namespace F10Y.L0000
{
    /// <summary>
    /// Filesystem path directory separator values.
    /// </summary>
    /// <remarks>
    /// .NET Standard 2.1 Foundation Library, unopinionated.
    /// </remarks>
    [ValuesMarker]
    public partial interface IDirectorySeparators
    {
        /// <summary>
        /// Both Windows and non-Windows directory separators.
        /// </summary>
        private static readonly Lazy<char[]> zBoth = new Lazy<char[]>(() => new[]
        {
            Instances.Characters.Backslash,
            Instances.Characters.Slash,
        });

        /// <inheritdoc cref="zBoth"/>
        public char[] Both => zBoth.Value;

        /// <inheritdoc cref="IDirectorySeparatorOperator.Get_DirectorySeparator_ForEnvironment"/>
        public char Environment => Instances.DirectorySeparatorOperator.Get_DirectorySeparator_ForEnvironment();

        /// <inheritdoc cref="IDirectorySeparatorOperator.Get_DirectorySeparator_ForEnvironment_Alternate"/>
        public char Environment_Alternate => Instances.DirectorySeparatorOperator.Get_DirectorySeparator_ForEnvironment_Alternate();

        /// <summary>
        /// The non-Windows path directory separator.
        /// <para>---</para>
        /// <inheritdoc cref="ICharacters.Slash" path="descendant::description"/>
        /// </summary>
        /// <remarks>
        /// <para><self-reference><see cref="NonWindows_AsCharacter"/></self-reference></para>
        /// <para>Documentation: <inheritdoc cref="ICharacters.Slash" path="descendant::documentation-reference"/></para>
        /// </remarks>
        public char NonWindows_AsCharacter => Instances.Characters.Slash;

        /// <summary>
        /// The non-Windows path directory separator.
        /// <para>---</para>
        /// <inheritdoc cref="IStrings.Slash" path="descendant::description"/>
        /// </summary>
        /// <remarks>
        /// <para><self-reference><see cref="NonWindows_AsString"/></self-reference></para>
        /// <para>Documentation: <inheritdoc cref="IStrings.Slash" path="descendant::documentation-reference"/></para>
        /// </remarks>
        public string NonWindows_AsString => Instances.Strings.Slash;

        /// <inheritdoc cref="NonWindows_AsCharacter"/>
        public char NonWindows => NonWindows_AsCharacter;

        /// <summary>
        /// The Windows path directory separator.
        /// <para>---</para>
        /// <inheritdoc cref="ICharacters.Backslash" path="descendant::description"/>
        /// </summary>
        /// <remarks>
        /// <para><self-reference><see cref="Windows_AsCharacter"/></self-reference></para>
        /// <para>Documentation: <inheritdoc cref="ICharacters.Backslash" path="descendant::documentation-reference"/></para>
        /// </remarks>
        public char Windows_AsCharacter => Instances.Characters.Backslash;

        /// <summary>
        /// The Windows path directory separator.
        /// <para>---</para>
        /// <inheritdoc cref="IStrings.Backslash" path="descendant::description"/>
        /// </summary>
        /// <remarks>
        /// <para><self-reference><see cref="Windows_AsString"/></self-reference></para>
        /// <para>Documentation: <inheritdoc cref="IStrings.Backslash" path="descendant::documentation-reference"/></para>
        /// </remarks>
        public string Windows_AsString => Instances.Strings.Backslash;

        /// <inheritdoc cref="Windows_AsCharacter"/>
        public char Windows => Windows_AsCharacter;
    }
}
