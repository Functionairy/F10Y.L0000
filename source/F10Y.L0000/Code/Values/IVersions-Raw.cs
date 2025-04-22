using System;

using F10Y.T0003;


namespace F10Y.L0000.Raw
{
    [ValuesMarker]
    public partial interface IVersions
    {
        /// <summary>
        /// "1.0.0"
        /// </summary>
        public Version _1_0_0 => new Version(1, 0, 0);

        /// <summary>
        /// "0.0.1"
        /// </summary>
        public Version _0_0_1 => new Version(0, 0, 1);
    }
}
