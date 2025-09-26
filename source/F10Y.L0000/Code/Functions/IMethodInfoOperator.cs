using System;
using System.Reflection;

using F10Y.T0002;


namespace F10Y.L0000
{
    [FunctionsMarker]
    public partial interface IMethodInfoOperator
    {
        /// <summary>
        /// Gets the generic type inputs of a method.
        /// </summary>
        public Type[] Get_GenericTypeInputs(MethodInfo methodInfo)
        {
            var output = Instances.MethodBaseOperator.Get_GenericTypeInputs(methodInfo);
            return output;
        }

        public MethodInfo Get_MethodOf<T>(
            string methodName,
            params Type[] argumentTypes_InOrder)
            => this.Get_MethodInfo<T>(
                methodName,
                argumentTypes_InOrder);

        public MethodInfo Get_MethodInfo<T>(
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
    }
}
