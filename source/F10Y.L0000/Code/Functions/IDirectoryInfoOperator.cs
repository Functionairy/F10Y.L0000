using System;
using System.IO;

using F10Y.T0002;


namespace F10Y.L0000
{
    [FunctionsMarker]
    public partial interface IDirectoryInfoOperator
    {
        public DirectoryInfo From(string directoryPath)
        {
            var output = new DirectoryInfo(directoryPath);
            return output;
        }

        public string Get_DirectoryName(DirectoryInfo directoryInfo)
        {
            var output = directoryInfo.Name;
            return output;
        }

        public string Get_DirectoryPath(DirectoryInfo directoryInfo)
        {
            var output = directoryInfo.FullName;
            return output;
        }

        public DirectoryInfo Get_Parent(DirectoryInfo directoryInfo)
            => directoryInfo.Parent;

        public string Get_ParentDirectoryPath(DirectoryInfo directoryInfo)
        {
            var parent = this.Get_Parent(directoryInfo);

            var output = this.Get_DirectoryPath(parent);
            return output;
        }
    }
}
