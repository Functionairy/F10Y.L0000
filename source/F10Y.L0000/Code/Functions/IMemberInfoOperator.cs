using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

using F10Y.T0002;


namespace F10Y.L0000
{
    [FunctionsMarker]
    public partial interface IMemberInfoOperator
    {
        public Assembly Get_Assembly(MemberInfo memberInfo)
        {
            // Can't use the declaring type of the member info, since the member info might be a type (and thus have no declaring type)!
            var output = memberInfo.Module.Assembly;
            return output;
        }

        /// <summary>
        /// Note: the <see cref="CustomAttributeData"/> type returned by <see cref="MemberInfo.CustomAttributes"/> is more useful than
        /// the <see cref="Attribute"/> type returned by <see cref="CustomAttributeExtensions.GetCustomAttributes(MemberInfo)"/>.
        /// </summary>
        public IEnumerable<CustomAttributeData> Get_Attributes(MemberInfo memberInfo)
        {
            var output = memberInfo.CustomAttributes;
            return output;
        } 

        /// <summary>
        /// Returns the result of <see cref="MemberInfo.DeclaringType"/>.
        /// </summary>
        public Type Get_DeclaringType(MemberInfo memberInfo)
            => memberInfo.DeclaringType;

        /// <summary>
        /// Gets the raw name of a member (<see cref="MemberInfo.Name"/>),
        /// without any adjustements.
        /// </summary>
        /// <remarks>
        /// This is lame, it's just ".ctor" or ".cctor" (static class constructor) or others.
        /// </remarks>
        public string Get_Name(MemberInfo memberInfo)
        {
            var output = memberInfo.Name;
            return output;
        }

        public CustomAttributeData Get_AttributeOfType(
            MemberInfo memberInfo,
            string attributeNamespacedTypeName)
        {
            var hasAttribute = this.Has_AttributeOfType(
                memberInfo,
                attributeNamespacedTypeName,
                out var attribute_OrDefault);

            if(!hasAttribute)
            {
                throw new Exception($"No attribute of type '{attributeNamespacedTypeName}' found.");
            }

            return attribute_OrDefault;
        }

        public bool Has_AttributeOfType(
            MemberInfo memberInfo,
            string attributeNamespacedTypeName,
            out CustomAttributeData attribute_OrDefault)
        {
            attribute_OrDefault = this.Get_Attributes(memberInfo)
                .Where(Instances.AttributeOperator.Get_AttributeTypeNamespacedTypeName_Is(attributeNamespacedTypeName))
                // Choose first even though there might be multiple since this function is more like "Any()".
                .FirstOrDefault();

            var output = Instances.DefaultOperator.Is_NotDefault(attribute_OrDefault);
            return output;
        }

        public bool Has_AttributeOfType(
            MemberInfo memberInfo,
            string attributeNamespacedTypeName)
            => this.Has_AttributeOfType(
                memberInfo,
                attributeNamespacedTypeName,
                out _);

        public bool Has_AttributesOfType(
            MemberInfo memberInfo,
            string attributeNamespacedTypeName,
            out CustomAttributeData[] attributes_OrEmpty)
        {
            attributes_OrEmpty = this.Get_Attributes(memberInfo)
                .Where(Instances.AttributeOperator.Get_AttributeTypeNamespacedTypeName_Is(attributeNamespacedTypeName))
                // Choose first even though there might be multiple since this function is more like "Any()".
                .ToArray();

            var output = Instances.ArrayOperator.Is_NotEmpty(attributes_OrEmpty);
            return output;
        }

        public bool Is_MethodInfo(
            MemberInfo memberInfo,
            out MethodInfo methodInfo_OrDefault)
            => Instances.TypeOperator.Type_Is(
                memberInfo,
                out methodInfo_OrDefault);

        public bool Is_MethodInfo(MemberInfo memberInfo)
            => this.Is_MethodInfo(
                memberInfo,
                out _);

        public bool Is_Name(
            MemberInfo member,
            string memberName)
        {
            var name = this.Get_Name(member);

            var output = memberName == name;
            return output;
        }

        public bool Is_PropertyInfo(
            MemberInfo memberInfo,
            out PropertyInfo propertyInfo_OrDefault)
            => Instances.TypeOperator.Type_Is(
                memberInfo,
                out propertyInfo_OrDefault);

        public bool Is_PropertyInfo(MemberInfo memberInfo)
            => this.Is_PropertyInfo(
                memberInfo,
                out _);

        public bool Is_TypeInfo(
            MemberInfo memberInfo,
            out TypeInfo typeInfo_OrDefault)
            => Instances.TypeOperator.Type_Is(
                memberInfo,
                out typeInfo_OrDefault);

        public bool Is_TypeInfo(MemberInfo memberInfo)
            => this.Is_TypeInfo(
                memberInfo,
                out _);

        /// <summary>
        /// This is a little less lame that <see cref="Get_Name(MemberInfo)"/>, in that it outputs:
        /// <list type="bullet">
        /// <item>Boolean Are_Equal_Not(System.String, System.String) for methods</item>
        /// <item>Char Quote for properties</item>
        /// <item>F10Y.L0000.ExitCodes for types</item>
        /// <item>System.Func`2[System.String,System.Boolean] Equals_AnyOf(System.String[])</item>
        /// <item>T[] Empty[T]()</item>
        /// </list>
        /// But also the same kinda useless contructor information:
        /// <list type="bullet">
        /// <item>Void .cctor()</item>
        /// <item>Void .ctor()</item>
        /// </list>
        /// </summary>
        public string To_String(MemberInfo memberInfo)
            => memberInfo.ToString();
    }
}
