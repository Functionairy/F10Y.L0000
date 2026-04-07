using System;
using System.Linq;
using System.Reflection;

using F10Y.T0002;


namespace F10Y.L0000
{
    [FunctionsMarker]
    public partial interface IMethodInfoOperator :
        Heritable.IMethodBaseOperator
    {
        /// <summary>
        /// Gets the generic type inputs of a method.
        /// </summary>
        Type[] Get_GenericTypeInputs(MethodInfo methodInfo)
        {
            var output = Instances.MethodBaseOperator.Get_GenericTypeInputs(methodInfo);
            return output;
        }

        MethodInfo Get_MethodOf<T>(
            string methodName,
            params Type[] argumentTypes_InOrder)
            => this.Get_MethodInfo<T>(
                methodName,
                argumentTypes_InOrder);

        MethodInfo Get_MethodInfo<T>(
            string methodName,
            params Type[] argumentTypes_InOrder)
        {
            var typeInfo = Instances.TypeInfoOperator.Get_TypeInfo<T>();

            var output = Instances.TypeInfoOperator.Get_Method(
                typeInfo,
                methodName,
                argumentTypes_InOrder);

            return output;
        }

        /// <summary>
        /// Determines whether the method is a property get or set method.
        /// </summary>
        bool Is_PropertyMethod(MethodInfo methodInfo)
        {
            // There is no direct method to determine if a method is a property method.
            // This implemention gets the properties of the method's declaring type, and then tests if the method is one of the get- or set-mmethods of any of the properties.

            var output = true
                // All property methods have special names.
                && methodInfo.IsSpecialName
                // Among all the properties of the method's declaring type, is the current method a get- or set-method of a property?
                && methodInfo.DeclaringType.GetProperties()
                    .Any(property => false
                        || property.GetGetMethod() == methodInfo
                        || property.GetSetMethod() == methodInfo);

            return output;
        }
    }
}
