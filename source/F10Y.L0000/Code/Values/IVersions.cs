using System;

using F10Y.T0003;
using F10Y.T0011;


namespace F10Y.L0000
{
    [ValuesMarker]
    public partial interface IVersions
    {
#pragma warning disable IDE1006 // Naming Styles

        [Ignore]
        public Raw.IVersions _Raw => Raw.Versions.Instance;

#pragma warning restore IDE1006 // Naming Styles


        /// <summary>
        /// The default version (for assuming when no version is present).
        /// <para><inheritdoc cref="Raw.IVersions._1_0_0" path="/summary"/></para>
        /// </summary>
        public Version Default => _Raw._1_0_0;

        /// <summary>
        /// The default initial version value.
        /// <para><inheritdoc cref="Raw.IVersions._0_0_1" path="/summary"/></para>
        /// </summary>
        public Version Initial_Default => _Raw._0_0_1;

        /// <summary>
        /// The none version is just null (since Version is a reference type).
        /// </summary>
        public Version None => null;
    }
}
