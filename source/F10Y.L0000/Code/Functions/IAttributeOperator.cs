using System;
using System.Collections.Generic;
using System.Reflection;

using F10Y.L0000.Extensions;
using F10Y.T0002;


namespace F10Y.L0000
{
    [FunctionsMarker]
    public partial interface IAttributeOperator
    {
        Type Get_AttributeType(CustomAttributeData attribute)
            => attribute.AttributeType;

        Func<CustomAttributeData, bool> Get_AttributeType_NamespacedTypeName_Is(string attributeTypeNamespacedTypeName)
        {
            bool Internal(CustomAttributeData attribute)
            {
                var output = this.Is_AttributeType_NamespacedTypeName(
                    attribute,
                    attributeTypeNamespacedTypeName);

                return output;
            }

            return Internal;
        }

        CustomAttributeTypedArgument[] Get_ConstructorArguments(CustomAttributeData attribute)
            => this.List_ConstructorArguments(attribute)
                .Now();

        CustomAttributeNamedArgument[] Get_NamedArguments(CustomAttributeData attribute)
            => this.List_NamedArguments(attribute)
                .Now();

        string Get_AttributeType_NamespacedTypeName(CustomAttributeData attribute)
        {
            var output = Instances.TypeNameOperator.Get_NamespacedTypeName(attribute.AttributeType);
            return output;
        }

        bool Is_AttributeType_NamespacedTypeName(
            CustomAttributeData attribute,
            string attributeTypeNamespacedTypeName)
        {
            var namespacedTypeName = this.Get_AttributeType_NamespacedTypeName(attribute);

            var output = namespacedTypeName == attributeTypeNamespacedTypeName;
            return output;
        }

        IList<CustomAttributeTypedArgument> List_ConstructorArguments(CustomAttributeData attribute)
            => attribute.ConstructorArguments;

        IList<CustomAttributeNamedArgument> List_NamedArguments(CustomAttributeData attribute)
            => attribute.NamedArguments;
    }
}
