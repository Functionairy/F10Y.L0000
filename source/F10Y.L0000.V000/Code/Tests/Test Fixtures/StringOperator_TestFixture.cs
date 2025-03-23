using System;

using Microsoft.VisualStudio.TestTools.UnitTesting;

using F10Y.T0010;


namespace F10Y.L0000.V000
{
    [TestClass, TestFixtureMarker]
    public class StringOperator_TestFixture : StringOperator_TestFixtureDefinition<StringOperator_TestArticle>
    {
        public override StringOperator_TestArticle TestArticle { get; } = new StringOperator_TestArticle();
    }
}