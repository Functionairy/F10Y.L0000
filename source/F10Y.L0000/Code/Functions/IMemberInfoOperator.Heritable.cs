using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

using F10Y.L0000.Extensions;
using F10Y.T0002;


namespace F10Y.L0000.Heritable
{
    /// <inheritdoc cref="IMemberInfoOperator{T}"/>
    [FunctionsMarker]
    public partial interface IMemberInfoOperator :
        IMemberInfoOperator<MemberInfo>
    {
        /// <summary>
        /// Enumerates the attributes of the member.
        /// </summary>
        /// <remarks>
        /// Note: the <see cref="CustomAttributeData"/> type returned by <see cref="MemberInfo.CustomAttributes"/> is more useful than
        /// the <see cref="Attribute"/> type returned by <see cref="CustomAttributeExtensions.GetCustomAttributes(MemberInfo)"/>.
        /// </remarks>
        IEnumerable<CustomAttributeData> Enumerate_Attributes(MemberInfo memberInfo)
        {
            var output = memberInfo.CustomAttributes;
            return output;
        }

        /// <summary>
        /// Gets the attributes of the member.
        /// </summary>
        /// <inheritdoc cref="Enumerate_Attributes(MemberInfo)" path="/remarks"/>
        CustomAttributeData[] Get_Attributes(MemberInfo memberInfo)
            => this.Enumerate_Attributes(memberInfo)
                .Now();

        /// <summary>
        /// Returns the result of <see cref="MemberInfo.DeclaringType"/>.
        /// </summary>
        Type Get_DeclaringType(MemberInfo memberInfo)
            => memberInfo.DeclaringType;

        bool Has_AttributeOfType(
            MemberInfo memberInfo,
            string attribute_NamespacedTypeName,
            out CustomAttributeData attribute_OrDefault)
        {
            attribute_OrDefault = this.Enumerate_Attributes(memberInfo)
                .Where(Instances.AttributeOperator.Get_AttributeType_NamespacedTypeName_Is(attribute_NamespacedTypeName))
                // Choose first even though there might be multiple since this function is more like "Any()".
                .FirstOrDefault();

            var output = Instances.DefaultOperator.Is_NotDefault(attribute_OrDefault);
            return output;
        }

        bool Has_AttributeOfType(
            MemberInfo memberInfo,
            string attributeNamespacedTypeName)
            => this.Has_AttributeOfType(
                memberInfo,
                attributeNamespacedTypeName,
                out _);

        bool Has_AttributeOfTypes_First(
            MemberInfo memberInfo,
            string[] attribute_NamespacedTypeNames,
            out CustomAttributeData attribute_OrDefault)
        {
            foreach (var namespacedTypeName in attribute_NamespacedTypeNames)
            {
                var hasAttribute = this.Has_AttributeOfType(
                    memberInfo,
                    namespacedTypeName,
                    out attribute_OrDefault);

                if (hasAttribute)
                {
                    return true;
                }
            }

            attribute_OrDefault = default;

            return false;
        }

        bool Has_AttributeOfTypes(
            MemberInfo memberInfo,
            string[] attribute_NamespacedTypeNames)
            => this.Has_AttributeOfTypes_First(
                memberInfo,
                attribute_NamespacedTypeNames,
                out _);
    }

    /// <summary>
    /// Functions related to the <see cref="MemberInfo"/> type that are meant to be inherited by operators related to inherited types.
    /// </summary>
    /// <remarks>
    /// <inheritdoc cref="Documentation.Project_SelfDescription" path="/summary"/>
    /// </remarks>
    [FunctionsMarker]
    public partial interface IMemberInfoOperator<T>
        where T : MemberInfo
    {
        
    }
}
