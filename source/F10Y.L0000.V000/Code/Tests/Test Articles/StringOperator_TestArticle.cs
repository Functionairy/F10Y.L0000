using System;

using F10Y.T0010;


namespace F10Y.L0000.V000
{
    [TestArticleMarker]
    public class StringOperator_TestArticle : IStringOperator_TestArticleDefintion
    {
        public string Ensure_Enquoted(string @string)
            => Instances.StringOperator.Ensure_Enquoted(@string);

        public bool Has_IndexOfAny(
            string @string,
            out int indexOfAny_OrNotFound,
            params char[] characters)
            => Instances.StringOperator.Has_IndexOfAny(
                @string,
                out indexOfAny_OrNotFound,
                characters);
    }
}