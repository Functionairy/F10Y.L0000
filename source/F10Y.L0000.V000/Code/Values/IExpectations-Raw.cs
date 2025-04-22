using System;

using F10Y.T0003;

using ExpectationTypes = F10Y.L0002.T000;


namespace F10Y.L0000.V000.Raw
{
    [ValuesMarker]
    public partial interface IExpectations
    {
        /// <summary>
        /// <para><value><inheritdoc cref="Z000.ITexts.Example_Text" path="descendant::value"/> => <inheritdoc cref="Z000.ITexts.Example_Text_Enquoted" path="descendant::value"/></value></para>
        /// </summary>
        public ExpectationTypes.IExpectation<string, string> N_001 => Instances.ExpectationOperator.From(
            Instances.Texts.Example_Text,
            Instances.Texts.Example_Text_Enquoted);

        /// <summary>
        /// <para><value><inheritdoc cref="Z000.Raw.ITexts.N_003" path="descendant::value"/> => <inheritdoc cref="Z000.ITexts.Example_Text_Enquoted" path="descendant::value"/></value></para>
        /// </summary>
        public ExpectationTypes.IExpectation<string, string> N_002 => Instances.ExpectationOperator.From(
            Instances.Texts._Raw.N_003,
            Instances.Texts.Example_Text_Enquoted);

        /// <summary>
        /// <para><value><inheritdoc cref="Z000.Raw.ITexts.N_004" path="descendant::value"/> => <inheritdoc cref="Z000.ITexts.Example_Text_Enquoted" path="descendant::value"/></value></para>
        /// </summary>
        public ExpectationTypes.IExpectation<string, string> N_003 => Instances.ExpectationOperator.From(
            Instances.Texts._Raw.N_004,
            Instances.Texts.Example_Text_Enquoted);

        /// <summary>
        /// <para><value><inheritdoc cref="Z000.ITexts.Example_Text_Enquoted" path="descendant::value"/> => <inheritdoc cref="Z000.ITexts.Example_Text_Enquoted" path="descendant::value"/></value></para>
        /// </summary>
        public ExpectationTypes.IExpectation<string, string> N_004 => Instances.ExpectationOperator.From(
            Instances.Texts.Example_Text_Enquoted,
            Instances.Texts.Example_Text_Enquoted);
    }
}
