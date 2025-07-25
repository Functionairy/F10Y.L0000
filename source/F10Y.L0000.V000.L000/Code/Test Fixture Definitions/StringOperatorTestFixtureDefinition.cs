using System;

using Microsoft.VisualStudio.TestTools.UnitTesting;

using F10Y.T0010;
using F10Y.T0013;


namespace F10Y.L0000.V000.L000
{
    [TestFixtureDefinitionMarker]
    public abstract class StringOperatorTestFixtureDefinition<TTestArticle> : TestFixtureBase<TTestArticle>
        where TTestArticle : IStringOperatorTestArticleDefinition
    {
        [TestMethod]
        public void Has_IndexOfAny()
        {
            /// Inputs.
            var @string = @"C:\Temp\Temp.txt";
            var characters = new[]
            {
                '\\',
                '/'
            };


            /// Run.
            var has_IndexOfAny = this.TestArticle.Has_IndexOfAny(
                @string,
                out var indexOfAny_OrNotFound,
                characters);

            /// Assert.
            Assert.IsTrue(has_IndexOfAny);

            Assert.AreEqual(
                2,
                indexOfAny_OrNotFound);
        }
    }
}
