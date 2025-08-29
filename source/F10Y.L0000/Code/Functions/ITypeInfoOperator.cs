using System;
using System.Collections.Generic;
using System.Reflection;

using F10Y.T0002;

using F10Y.L0000.Extensions;


namespace F10Y.L0000
{
    [FunctionsMarker]
    public partial interface ITypeInfoOperator
    {
        /// <summary>
        /// Note: does not include nested types (as those are provided by the declared types of an assembly).
        /// </summary>
        /// <remarks>
        /// Similar to <see cref="TypeInfo.DeclaredMembers"/>, but I have no idea what members that returns.
        /// </remarks>
        public IEnumerable<MemberInfo> Enumerate_MemberInfos(TypeInfo typeInfo)
        {
            var output = Instances.EnumerableOperator.Empty<MemberInfo>()
                .Append(typeInfo.DeclaredConstructors)
                .Append(typeInfo.DeclaredMethods)
                .Append(typeInfo.DeclaredEvents)
                .Append(typeInfo.DeclaredFields)
                .Append(typeInfo.DeclaredProperties)
                // Do not include nested types.
                ;

            return output;
        }

        public MethodInfo Get_Method(
            TypeInfo typeInfo,
            string methodName,
            params Type[] argumentTypes_InOrder)
        {
            var output = typeInfo.GetMethod(
                methodName,
                argumentTypes_InOrder);

            return output;
        }

        public TypeInfo Get_TypeInfo<T>()
        {
            var type = Instances.TypeOperator.Get_Type<T>();

            var output = this.Get_TypeInfo(type);
            return output;
        }

        public TypeInfo Get_TypeInfo(Type type)
        {
            // Somehow does not appear in Intellisense?
            var output = type.GetTypeInfo();
            return output;
        }
    }
}
