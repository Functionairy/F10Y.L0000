using System;

using F10Y.T0003;

using ExpectationTypes = F10Y.L0002.T000;


namespace F10Y.L0000.V000.Raw
{
    [ValuesMarker]
    public partial interface IExpectationSets
    {
#pragma warning disable IDE1006 // Naming Styles

        private static V000.IExpectations _Expectations => V000.Expectations.Instance;

#pragma warning restore IDE1006 // Naming Styles


        /// <summary>
        /// <list type="number">
        /// <item><inheritdoc cref="V000.IExpectations.For_Ensure_Enquoted" path="descendant::value[1]"/></item>
        /// <item><inheritdoc cref="IExpectations.N_002" path="descendant::value[1]"/></item>
        /// <item><inheritdoc cref="IExpectations.N_003" path="descendant::value[1]"/></item>
        /// <item><inheritdoc cref="IExpectations.N_004" path="descendant::value[1]"/></item>
        /// </list>
        /// </summary>
        public ExpectationTypes.IExpectation<string, string>[] N_001 =>
        [
            _Expectations.For_Ensure_Enquoted,
            _Expectations._Raw.N_002,
            _Expectations._Raw.N_003,
            _Expectations._Raw.N_004,
        ];
    }
}
