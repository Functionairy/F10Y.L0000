using System;
using System.Xml.Linq;

using F10Y.T0002;


namespace F10Y.L0000
{
    [FunctionsMarker]
    public partial interface IXAttributeOperations
    {
        public Func<XAttribute, bool> Is_Value(string value)
            => attribute =>
                Instances.XAttributeOperator.Is_Value(
                    attribute,
                    value);
    }
}
