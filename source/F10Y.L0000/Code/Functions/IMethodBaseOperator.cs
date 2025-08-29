using System;
using System.Reflection;

using F10Y.T0002;


namespace F10Y.L0000
{
    [FunctionsMarker]
    public partial interface IMethodBaseOperator
    {
        public Type Get_DeclaringType(MethodBase methodBase)
        {
            var output = methodBase.DeclaringType;
            return output;
        }

        /// <summary>
        /// Gets all generic type inputs of the method.
        /// This includes the generic type inputs of the declaring type of the method, and the method itself.
        /// </summary>
        /// <remarks>
        /// Returns <see cref="MethodBase.GetGenericArguments"/>.
        /// </remarks>
        public Type[] Get_GenericTypeInputs_All(MethodBase methodBase)
        {
            var output = methodBase.GetGenericArguments();
            return output;
        }

        /// <summary>
        /// Gets the generic type inputs of a method.
        /// </summary>
        /// <remarks>
        /// Chooses <see cref="Get_GenericTypeInputs_All(MethodBase)"/> as the default.
        /// </remarks>
        public Type[] Get_GenericTypeInputs(MethodBase methodBase)
        {
            var output = this.Get_GenericTypeInputs_All(methodBase);
            return output;
        }
    }
}
