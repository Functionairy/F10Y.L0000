using System;
using System.Reflection;

using F10Y.T0002;


namespace F10Y.L0000
{
    [FunctionsMarker]
    public partial interface ICustomAttributeDataOperator
    {
        Type Get_Type(CustomAttributeData attribute)
            => attribute.AttributeType;

        string Get_TypeFullName(CustomAttributeData attribute)
        {
            var type = this.Get_Type(attribute);

            var output = Instances.TypeOperator.Get_FullName(type);
            return output;
        }
    }
}
