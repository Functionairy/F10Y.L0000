using System;

using F10Y.T0003;


namespace F10Y.L0000
{
    [ValuesMarker]
    public partial interface IDirectoryNames
    {
        /// <summary>
        /// <para><value>.</value></para>
        /// </summary>
        public string Current => ".";

        /// <summary>
        /// <para><value>..</value></para>
        /// </summary>
        public string Parent => "..";

        public string[] SpecialDirectories => new[]
        {
            this.Current,
            this.Parent,
        };
    }
}
