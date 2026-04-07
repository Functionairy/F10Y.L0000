using System;
using System.Reflection;

using F10Y.T0002;


namespace F10Y.L0000
{
    [FunctionsMarker]
    public partial interface IAssemblyNameOperator
    {
        /// <summary>
        /// 
        /// </summary>
        /// <remarks>
        /// Returns <see cref="AssemblyName.Name"/>.
        /// </remarks>
        string Get_Name_Simple(AssemblyName assemblyName)
            => assemblyName.Name;
    }
}
