using System;
using System.IO;

using F10Y.T0002;


namespace F10Y.L0000
{
    [FunctionsMarker]
    public partial interface IFileInfoOperator
    {
        public FileInfo From(string filePath)
        {
            var output = new FileInfo(filePath);
            return output;
        }

        public string Get_FileName(FileInfo fileInfo)
        {
            var output = fileInfo.Name;
            return output;
        }

        public string Get_FilePath(FileInfo fileInfo)
        {
            var output = fileInfo.FullName;
            return output;
        }

        public DirectoryInfo Get_ParentDirectory(FileInfo fileInfo)
            => fileInfo.Directory;

        public string Get_ParentDirectoryPath(FileInfo fileInfo)
        {
            var parent = this.Get_ParentDirectory(fileInfo);

            var output = Instances.DirectoryInfoOperator.Get_DirectoryPath(parent);
            return output;
        }
    }
}
