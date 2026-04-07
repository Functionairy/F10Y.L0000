using System;
using System.Reflection;

using F10Y.T0002;


namespace F10Y.L0000
{
    /// <summary>
    /// Functions related to the <see cref="FieldInfo"/> type.
    /// </summary>
    /// <remarks>
    /// <inheritdoc cref="Documentation.Project_SelfDescription" path="/summary"/>
    /// </remarks>
    [FunctionsMarker]
    public partial interface IFieldInfoOperator :
        Heritable.IMemberInfoOperator
    {
        Type Get_FieldType(FieldInfo fieldInfo)
        {
            var output = fieldInfo.FieldType;
            return output;
        }

        bool Is_Static(FieldInfo fieldInfo)
            => fieldInfo.IsStatic;

        bool Is_InitOnly(FieldInfo fieldInfo)
            => fieldInfo.IsInitOnly;

        bool Is_ReadOnly(FieldInfo fieldInfo)
            => this.Is_InitOnly(fieldInfo);
    }
}
