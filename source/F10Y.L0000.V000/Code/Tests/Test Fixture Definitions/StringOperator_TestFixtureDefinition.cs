using System;

using Microsoft.VisualStudio.TestTools.UnitTesting;

using F10Y.T0010;
using F10Y.T0013;



namespace F10Y.L0000.V000
{
    [TestFixtureDefinitionMarker]
    public abstract class StringOperator_TestFixtureDefinition<TTestArticle> : TestFixtureBase<TTestArticle>
        where TTestArticle : IStringOperator_TestArticleDefintion
    {
        [TestMethod]
        public void Ensure_Enquoted()
        {
            var expectation = Instances.Expectations.For_Ensure_Enquoted;

            Instances.TestOperator.Test_Function(
                this.TestArticle.Ensure_Enquoted,
                expectation);
        }
    }
}