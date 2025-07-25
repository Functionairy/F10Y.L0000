using System;

using Microsoft.VisualStudio.TestTools.UnitTesting;

using F10Y.T0010;



namespace F10Y.L0000.V000
{
    [TestFixtureDefinitionMarker]
    public abstract class StringOperator_TestFixtureDefinition<TTestArticle> : L000.StringOperatorTestFixtureDefinition<TTestArticle>
        where TTestArticle : IStringOperator_TestArticleDefintion
    {
        ///// <inheritdoc cref="ITestMethods.Ensure_Enquoted_All(Func{string, string})"/>
        //[TestMethod]
        //public void Ensure_Enquoted_All() => Instances.TestMethods.Ensure_Enquoted_All(this.TestArticle.Ensure_Enquoted);

        /// <inheritdoc cref="ITestMethods.Ensure_Enquoted_Neither(Func{string, string})"/>
        [TestMethod]
        public void Ensure_Enquoted_Neither()
            => Instances.TestMethods.Ensure_Enquoted_Neither(this.TestArticle.Ensure_Enquoted);

        /// <inheritdoc cref="ITestMethods.Ensure_Enquoted_Both(Func{string, string})"/>
        [TestMethod]
        public void Ensure_Enquoted_Both()
            => Instances.TestMethods.Ensure_Enquoted_Both(this.TestArticle.Ensure_Enquoted);

        /// <inheritdoc cref="ITestMethods.Ensure_Enquoted_Beginning(Func{string, string})"/>
        [TestMethod]
        public void Ensure_Enquoted_Beginning()
            => Instances.TestMethods.Ensure_Enquoted_Beginning(this.TestArticle.Ensure_Enquoted);

        /// <inheritdoc cref="ITestMethods.Ensure_Enquoted_Ending(Func{string, string})"/>
        [TestMethod]
        public void Ensure_Enquoted_Ending()
            => Instances.TestMethods.Ensure_Enquoted_Ending(this.TestArticle.Ensure_Enquoted);
    }
}