using System;
using System.Collections.Generic;
using System.Reflection;

using F10Y.T0002;


namespace F10Y.L0000
{
    [FunctionsMarker]
    public partial interface IAttributeOperator
    {
        public Type Get_AttributeType(CustomAttributeData attribute)
            => attribute.AttributeType;

        public Func<CustomAttributeData, bool> Get_AttributeTypeNamespacedTypeName_Is(string attributeTypeNamespacedTypeName)
        {
            bool Internal(CustomAttributeData attribute)
            {
                var output = this.Is_TypeNamespacedTypeName(
                    attribute,
                    attributeTypeNamespacedTypeName);

                return output;
            }

            return Internal;
        }

        public IList<CustomAttributeTypedArgument> Get_ConstructorArguments(CustomAttributeData attribute)
            => attribute.ConstructorArguments;

        public IList<CustomAttributeNamedArgument> Get_NamedArguments(CustomAttributeData attribute)
            => attribute.NamedArguments;

        public string Get_TypeNamespacedTypeName(CustomAttributeData attribute)
        {
            var output = Instances.TypeOperator.Get_NamespacedTypeName(attribute.AttributeType);
            return output;
        }

        public bool Is_TypeNamespacedTypeName(
            CustomAttributeData attribute,
            string attributeTypeNamespacedTypeName)
        {
            var namespacedTypeName = this.Get_TypeNamespacedTypeName(attribute);

            var output = namespacedTypeName == attributeTypeNamespacedTypeName;
            return output;
        }
    }
}
