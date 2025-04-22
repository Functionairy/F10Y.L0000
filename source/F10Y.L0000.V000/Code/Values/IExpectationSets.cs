using System;

using F10Y.T0003;
using F10Y.T0011;

using ExpectationTypes = F10Y.L0002.T000;


namespace F10Y.L0000.V000
{
    [ValuesMarker]
    public partial interface IExpectationSets
    {
#pragma warning disable IDE1006 // Naming Styles

        [Ignore]
        public Raw.IExpectationSets _Raw => Raw.ExpectationSets.Instance;

#pragma warning restore IDE1006 // Naming Styles


        /// <inheritdoc cref="Raw.IExpectationSets.N_001"/>
        public ExpectationTypes.IExpectation<string, string>[] For_Ensure_Enquoted_All => _Raw.N_001;
    }
}
