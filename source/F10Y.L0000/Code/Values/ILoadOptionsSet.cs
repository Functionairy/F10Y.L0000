using System;
using System.Xml.Linq;

using F10Y.T0003;


namespace F10Y.L0000
{
    [ValuesMarker]
    public partial interface ILoadOptionsSet
    {
        /// <summary>
        /// <para><inheritdoc cref="None_Constant" path="descendant::value"/></para>
        /// The default load options is none.
        /// </summary>
        /// <remarks>
        /// Note: As opposed to a "default" value (which is just what the value defaults to), you could have a "standard" value in an personally- or organizationally-opinionated library.
        /// </remarks>
        public const LoadOptions Default_Constant = ILoadOptionsSet.None_Constant;

        /// <inheritdoc cref="Default_Constant"/>
        public LoadOptions Default => ILoadOptionsSet.Default_Constant;

        /// <summary>
        /// <para><value><see cref="LoadOptions.None"/></value></para>
        /// </summary>
        public const LoadOptions None_Constant = LoadOptions.None;

        /// <inheritdoc cref="None_Constant"/>
        public LoadOptions None => ILoadOptionsSet.None_Constant;

        /// <summary>
        /// <para><value><see cref="LoadOptions.PreserveWhitespace"/></value></para>
        /// The default load options preserves insignificant whitespace.
        /// </summary>
        public const LoadOptions PreserveWhitespace_Constant = LoadOptions.PreserveWhitespace;

        /// <inheritdoc cref="PreserveWhitespace_Constant"/>
        public LoadOptions PreserveWhitespace => ILoadOptionsSet.PreserveWhitespace_Constant;
    }
}
