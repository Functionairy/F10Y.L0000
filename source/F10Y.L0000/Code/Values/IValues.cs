using System;
using System.Diagnostics;
using System.IO;

using F10Y.T0003;


namespace F10Y.L0000
{
    [ValuesMarker]
    public partial interface IValues
    {
        public TextWriter Console_Out => Console.Out;

        /// <inheritdoc cref="IStrings.Empty"/>
        public string Empty_XAttribute_Value => Instances.Strings.Empty;

        /// <summary>
		/// The value for the command line to have no arguments is null.
		/// </summary>
		public const string EmptyCommandArguments_Constant = null;

        public string EmptyCommandArguments => IValues.EmptyCommandArguments_Constant;

        /// <summary>
        /// <para><value>true</value></para>
        /// By default, files are overwritten.
        /// </summary>
        public const bool Overwrite_Default_Constant = true;

        /// <inheritdoc cref="Overwrite_Default_Constant"/>
        public bool Overwrite_Default => IValues.Overwrite_Default_Constant;

        /// <summary>
        /// 1024, the default for <see cref="StreamReader"/>.
        /// </summary>
        public const int StreamBufferSize_Default_Constant = 1024;

        /// <inheritdoc cref="StreamBufferSize_Default_Constant"/>.
        public int StreamBufferSize_Default => IValues.StreamBufferSize_Default_Constant;

        /// <inheritdoc cref="Stopwatch.Frequency"/>
        public long Stopwatch_Frequency => Stopwatch.Frequency;

        /// <inheritdoc cref="Stopwatch.IsHighResolution"/>
        public bool Stopwatch_Is_HighResolution => Stopwatch.IsHighResolution;

        /// <inheritdoc cref="IIntegers.NegativeOne"/>
        public int Version_UndefinedPropertyValue => Instances.Integers.NegativeOne;

        /// <summary>
        /// The default working directory is the empty string.
        /// </summary>
        public string WorkingDirectory_Default => Instances.Strings.Empty;
    }
}
