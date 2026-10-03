using System;
using System.Collections.Generic;
using System.Reflection;

using F10Y.T0002;

using F10Y.L0000.Extensions;
using System.Linq;


namespace F10Y.L0000
{
    [FunctionsMarker]
    public partial interface ITypeInfoOperator :
        Heritable.ITypeOperator
    {
        /// <summary>
        /// Note: does not include nested types (as those are provided by the declared types of an assembly).
        /// </summary>
        /// <remarks>
        /// Similar to <see cref="TypeInfo.DeclaredMembers"/>, but I have no idea what members that returns.
        /// </remarks>
        IEnumerable<MemberInfo> Enumerate_MemberInfos(TypeInfo typeInfo)
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

        MethodInfo Get_Method(
            TypeInfo typeInfo,
            string methodName,
            params Type[] argumentTypes_InOrder)
        {
            var output = typeInfo.GetMethod(
                methodName,
                argumentTypes_InOrder);

            return output;
        }

        MethodInfo Get_Method<T>(Func<MethodInfo, bool> predicate)
        {
            var has_Method = this.Has_Method<T>(
                predicate,
                out var output_OrDefault);

            if(!has_Method)
            {
                throw new Exception("No method found matching predicate.");
            }

            return output_OrDefault;
        }

        MethodInfo[] Get_Methods(Type type)
            => type.GetMethods();

        MethodInfo[] Get_Methods<T>()
            => this.Get_Methods(typeof(T));

        TypeInfo Get_TypeInfo<T>()
        {
            var type = Instances.TypeOperator.Get_Type<T>();

            var output = this.Get_TypeInfo(type);
            return output;
        }

        TypeInfo Get_TypeInfo(Type type)
        {
            // Somehow does not appear in Intellisense?
            var output = type.GetTypeInfo();
            return output;
        }

        bool Has_Method<T>(
            Func<MethodInfo, bool> predicate,
            out MethodInfo method_OrDefault)
        {
            method_OrDefault = this.Get_Methods<T>()
                .SingleOrDefault(predicate);

            var output = Instances.DefaultOperator.Is_NotDefault(method_OrDefault);
            return output;
        }
    }
}
