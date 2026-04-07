using System;
using System.Reflection;

using F10Y.T0002;


namespace F10Y.L0000.Heritable
{
    [FunctionsMarker]
    public partial interface IMethodBaseOperator :
        IMemberInfoOperator
    {
        /// <summary>
        /// Gets all generic type inputs of the method.
        /// This includes the generic type inputs of the declaring type of the method, and the method itself.
        /// </summary>
        /// <remarks>
        /// Returns <see cref="MethodBase.GetGenericArguments"/>.
        /// </remarks>
        Type[] Get_GenericTypeInputs_All(MethodBase methodBase)
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
        Type[] Get_GenericTypeInputs(MethodBase methodBase)
        {
            var output = this.Get_GenericTypeInputs_All(methodBase);
            return output;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <remarks>
        /// Note that private is not necessarily the same as non-public.
        /// </remarks>
        bool Is_Private(MethodBase methodBase)
            => methodBase.IsPrivate;

        bool Is_Public(MethodBase methodBase)
            => methodBase.IsPublic;

        /// <summary>
        /// 
        /// </summary>
        /// <remarks>
        /// Note that non-public is not necessarily the same as private.
        /// </remarks>
        bool Is_NonPublic(MethodBase methodBase)
            => !this.Is_Public(methodBase);

        bool Is_PublicNonStatic(MethodBase methodBase)
        {
            var output = true
                && this.Is_Public(methodBase)
                && this.Is_NonStatic(methodBase)
                ;

            return output;
        }

        bool Is_PublicStatic(MethodBase methodBase)
        {
            var output = true
                && this.Is_Public(methodBase)
                && this.Is_Static(methodBase)
                ;

            return output;
        }

        bool Is_Static(MethodBase methodBase)
            => methodBase.IsStatic;

        bool Is_NonStatic(MethodBase methodBase)
            => !this.Is_Static(methodBase);
    }
}
