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
        public string Get_DirectoryName_ViaDirectoryInfo(string directoryPath)
        {
            var directoryInfo = Instances.DirectoryInfoOperator.From(directoryPath);

            var output = directoryInfo.Name;
            return output;
        }

        public string Get_DirectoryName_ViaLastPathPart(string directoryPath)
        {
            var output = Instances.PathOperator.Get_PathPart_Last(directoryPath);
            return output;
        }

        public string Get_FileName_ViaFileInfo(string filePath)
        {
            var fileInfo = Instances.FileInfoOperator.From(filePath);

            var output = fileInfo.Name;
            return output;
        }

        public string Get_FileName_ViaLastPathPart(string filePath)
        {
            var output = Instances.PathOperator.Get_PathPart_Last(filePath);
            return output;
        }

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
