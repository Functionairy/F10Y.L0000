using System;
using System.Reflection;

using F10Y.T0002;


namespace F10Y.L0000.Heritable
{
    [FunctionsMarker]
    public partial interface ITypeOperator :
        IMemberInfoOperator
    {
        bool Is_NonPublic(Type type)
            => !this.Is_Public(type);

        bool Is_Public(Type type)
            => type.IsPublic;
    }
}
