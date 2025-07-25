using System;

using F10Y.T0010;


namespace F10Y.L0000.V000
{
    [TestArticleDefinitionMarker]
    public interface IStringOperator_TestArticleDefintion :
        L000.IStringOperatorTestArticleDefinition
    {
        string Ensure_Enquoted(string @string);
    }
}