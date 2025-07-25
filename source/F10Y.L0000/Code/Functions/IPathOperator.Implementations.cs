using System;
using System.IO;

using F10Y.T0002;


namespace F10Y.L0000.Implementations
{
    /// <summary>
    /// Implementations for a stringly-typed path operator (NET Standard 2.1 Foundation Library).
    /// </summary>
    [FunctionsMarker]
    public partial interface IPathOperator
    {
        /// <inheritdoc cref="L0000.IPathOperator.Resolve(string)" path="/summary"/>
        /// <remarks>
        /// Uses the <see cref="Path.GetFullPath(string)"/> method.
        /// </remarks>
        public string Resolve_GetFullPath(string path_Unresolved)
        {
            var output = Path.GetFullPath(path_Unresolved);
            return output;
        }
    }
}
