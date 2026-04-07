using System;
using System.Reflection;

using F10Y.T0002;


namespace F10Y.L0000
{
    [FunctionsMarker]
    public partial interface IPropertyInfoOperator :
        Heritable.IMemberInfoOperator
    {
        MethodInfo Get_GetMethod(PropertyInfo propertyInfo)
            => propertyInfo.GetMethod;

        /// <summary>
        /// Gets either the get-method or set-method of the property, dependening on which is not-null.
        /// (Preferences the get-method.)
        /// </summary>
        MethodInfo Get_Method(PropertyInfo propertyInfo)
            => this.Get_GetMethod(propertyInfo) ?? this.Get_SetMethod(propertyInfo);

        MethodInfo Get_SetMethod(PropertyInfo propertyInfo)
            => propertyInfo.SetMethod;
    }
}
