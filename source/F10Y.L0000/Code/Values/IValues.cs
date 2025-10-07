using System;
using System.Diagnostics;
using System.IO;

using F10Y.T0003;


namespace F10Y.L0000
{
    [ValuesMarker]
    public partial interface IValues
    {
        /// <summary>
        /// <para><value>C:\</value></para>
        /// </summary>
        const string C_DriveName_Constant = @"C:\";

        /// <inheritdoc cref="C_DriveName_Constant"/>
        string C_DriveName => C_DriveName_Constant;

        TextWriter Console_Out => Console.Out;

        /// <inheritdoc cref="IStrings.Empty"/>
        string Empty_XAttribute_Value => Instances.Strings.Empty;

        /// <summary>
		/// The value for the command line to have no arguments is null.
		/// </summary>
		const string EmptyCommandArguments_Constant = null;

        string EmptyCommandArguments => IValues.EmptyCommandArguments_Constant;

        /// <summary>
        /// <para><value>true</value></para>
        /// By default, we ensure a successful status code for HTTP responses.
        /// </summary>
        const bool EnsureSuccessStatusCode_Default_Constant = true;

        /// <inheritdoc cref="EnsureSuccessStatusCode_Default_Constant"/>
        bool EnsureSuccessStatusCode_Default => IValues.EnsureSuccessStatusCode_Default_Constant;

        /// <inheritdoc cref="ICharacters.Period_Constant"/>
        const char FileExtension_Separator_Character_Constant = ICharacters.Period_Constant;

        /// <inheritdoc cref="FileExtension_Separator_Character_Constant"/>
        char FileExtension_Separator_Character => IValues.FileExtension_Separator_Character_Constant;

        /// <inheritdoc cref="IStrings.Period_Constant"/>
        const string FileExtension_Separator_String_Constant = IStrings.Period_Constant;

        /// <inheritdoc cref="FileExtension_Separator_Character_Constant"/>
        string FileExtension_Separator_String => IValues.FileExtension_Separator_String_Constant;

        /// <inheritdoc cref="FileExtension_Separator_Character_Constant"/>
        const char FileExtension_Separator_Constant = IValues.FileExtension_Separator_Character_Constant;

        /// <inheritdoc cref="FileExtension_Separator_Constant"/>
        char FileExtension_Separator => IValues.FileExtension_Separator_Constant;

        /// <summary>
        /// <para>When a character is not found (for example, when a string is too short) this character is returned.</para>
        /// <inheritdoc cref="ICharacters.Null_Constant" path="/summary"/>
        /// </summary>
        const char NotFound_Character_Constant = ICharacters.Null_Constant;

        /// <inheritdoc cref="IValues.NotFound_Character_Constant"/>
        char NotFound_Character => IValues.NotFound_Character_Constant;

        /// <summary>
        /// <para><value>true</value></para>
        /// By default, files are overwritten.
        /// </summary>
        const bool Overwrite_Default_Constant = true;

        /// <inheritdoc cref="Overwrite_Default_Constant"/>
         bool Overwrite_Default => IValues.Overwrite_Default_Constant;

        /// <summary>
        /// 1024, the default for <see cref="StreamReader"/>.
        /// </summary>
        const int StreamBufferSize_Default_Constant = 1024;

        /// <inheritdoc cref="StreamBufferSize_Default_Constant"/>.
        int StreamBufferSize_Default => IValues.StreamBufferSize_Default_Constant;

        /// <inheritdoc cref="Stopwatch.Frequency"/>
        long Stopwatch_Frequency => Stopwatch.Frequency;

        /// <inheritdoc cref="Stopwatch.IsHighResolution"/>
        bool Stopwatch_Is_HighResolution => Stopwatch.IsHighResolution;

        /// <inheritdoc cref="IIntegers.Zero"/>
        int Version_DefinedDefaultComponentValue => Instances.Integers.Zero;

        /// <inheritdoc cref="IIntegers.NegativeOne"/>
        int Version_UndefinedComponentValue => Instances.Integers.NegativeOne;

        /// <summary>
        /// The default working directory is the empty string.
        /// </summary>
        string WorkingDirectory_Default => Instances.Strings.Empty;

        /// <summary>
        /// <inheritdoc cref="IStrings.DEFAULT_Constant" path="descendant::value"/>
        /// </summary>
        /// <remarks>
        /// <see cref="System.Xml.Linq.XElement"/>s cannot be constructed without a name,
        /// but you can change the element's name after construction.
        /// You might want to just construct an element, and then set its name.
        /// This value is used by <see cref="IXElementOperator.New()"/> to do this.
        /// </remarks>
        string XElementName_Default => IStrings.DEFAULT_Constant;

        /// <summary>
        /// <para><value>false</value></para>
        /// </summary>
        bool False => false;

        /// <summary>
        /// <para><value>true</value></para>
        /// </summary>
        bool True => true;

    }
}
