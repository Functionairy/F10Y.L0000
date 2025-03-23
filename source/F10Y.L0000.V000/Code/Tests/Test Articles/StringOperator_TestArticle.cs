using System;

using F10Y.T0010;


namespace F10Y.L0000.V000
{
    [TestArticleMarker]
    public class StringOperator_TestArticle : IStringOperator_TestArticleDefintion
    {
        public string Ensure_Enquoted(string @string)
            => Instances.StringOperator.Ensure_Enquoted(@string);
    }
}