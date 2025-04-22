using System;

using F10Y.T0003;
using F10Y.T0011;

using ExpectationTypes = F10Y.L0002.T000;


namespace F10Y.L0000.V000
{
    [ValuesMarker]
    public partial interface IExpectations
    {
#pragma warning disable IDE1006 // Naming Styles

        [Ignore]
        public Raw.IExpectations _Raw => Raw.Expectations.Instance;

#pragma warning restore IDE1006 // Naming Styles


        /// <inheritdoc cref="Raw.IExpectations.N_001"/>
        public ExpectationTypes.IExpectation<string, string> For_Ensure_Enquoted => _Raw.N_001;
    }
}
