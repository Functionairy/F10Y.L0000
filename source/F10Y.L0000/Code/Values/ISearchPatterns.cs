using System;

using F10Y.T0003;


namespace F10Y.L0000
{
    [ValuesMarker]
    public partial interface ISearchPatterns
    {
        /// <inheritdoc cref="IStrings.Asterix"/>
        public string All => Instances.Strings.Asterix;
    }
}
