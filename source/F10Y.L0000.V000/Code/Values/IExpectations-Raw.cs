using System;

using F10Y.L0002;
using F10Y.T0003;


namespace F10Y.L0000.V000.Raw
{
    [ValuesMarker]
    public partial interface IExpectations
    {
        /// <summary>
        /// <inheritdoc cref="Z000.ITexts.Example_Text" path="descendant::value"/> => <inheritdoc cref="Z000.ITexts.Example_Text_Enquoted" path="descendant::value"/>
        /// </summary>
        public IExpectation<string, string> N_001 => Instances.ExpectationOperator.From(
            Instances.Texts.Example_Text,
            Instances.Texts.Example_Text_Enquoted);
    }
}
