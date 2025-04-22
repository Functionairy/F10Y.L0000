using System;

using F10Y.T0002;


namespace F10Y.L0000.V000
{
    //using X = Func<string, string>;
    using Ensure_Enquoted = Func<string, string>;

    [FunctionsMarker]
    public partial interface ITestMethods
    {
        /// <inheritdoc cref="IExpectationSets.For_Ensure_Enquoted_All"/>
        public void Ensure_Enquoted_All(Ensure_Enquoted ensure_Enquoted)
            => Instances.TestOperator.Test_Function(
                ensure_Enquoted,
                Instances.ExpectationSets.For_Ensure_Enquoted_All);

        /// <inheritdoc cref="IExpectations.For_Ensure_Enquoted"/>
        public void Ensure_Enquoted_Neither(Ensure_Enquoted ensure_Enquoted)
            => Instances.TestOperator.Test_Function(
                ensure_Enquoted,
                Instances.Expectations.For_Ensure_Enquoted);

        /// <inheritdoc cref="Raw.IExpectations.N_004"/>
        public void Ensure_Enquoted_Both(Ensure_Enquoted ensure_Enquoted)
            => Instances.TestOperator.Test_Function(
                ensure_Enquoted,
                Instances.Expectations._Raw.N_004);

        /// <inheritdoc cref="Raw.IExpectations.N_002"/>
        public void Ensure_Enquoted_Beginning(Ensure_Enquoted ensure_Enquoted)
            => Instances.TestOperator.Test_Function(
                ensure_Enquoted,
                Instances.Expectations._Raw.N_002);

        /// <inheritdoc cref="Raw.IExpectations.N_003"/>
        public void Ensure_Enquoted_Ending(Ensure_Enquoted ensure_Enquoted)
            => Instances.TestOperator.Test_Function(
                ensure_Enquoted,
                Instances.Expectations._Raw.N_003);
    }
}
