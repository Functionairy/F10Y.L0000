using System;

using F10Y.T0010;


namespace F10Y.L0000.V000.L000
{
    [TestArticleDefinitionMarker]
    public partial interface IStringOperatorTestArticleDefinition
    {
        public bool Has_IndexOfAny(
            string @string,
            out int indexOfAny_OrNotFound,
            params char[] characters);
    }
}
