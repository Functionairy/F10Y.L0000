using System;
using System.Xml.Linq;

using F10Y.T0002;


namespace F10Y.L0000
{
    [FunctionsMarker]
    public partial interface IXTextOperator
    {
        public XText From(string text)
            => new XText(text);
    }
}
