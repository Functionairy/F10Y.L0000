using System;
using System.IO;

using F10Y.T0002;


namespace F10Y.L0000
{
    [FunctionsMarker]
    public partial interface IFileInfoOperator
    {
        FileInfo From(string filePath)
            => this.New(filePath);

        string Get_FileName(FileInfo fileInfo)
        {
            var output = fileInfo.Name;
            return output;
        }

        FileInfo Get_FileInfo(string filePath)
            => this.New(filePath);

        string Get_FilePath(FileInfo fileInfo)
        {
            var output = fileInfo.FullName;
            return output;
        }

        DateTime Get_LastModifiedTime(FileInfo fileInfo)
            => fileInfo.LastWriteTime;

        DateTime Get_LastModifiedTime_UTC(FileInfo fileInfo)
            => fileInfo.LastWriteTimeUtc;

        DirectoryInfo Get_ParentDirectory(FileInfo fileInfo)
            => fileInfo.Directory;

        string Get_ParentDirectoryPath(FileInfo fileInfo)
        {
            var parent = this.Get_ParentDirectory(fileInfo);

            var output = Instances.DirectoryInfoOperator.Get_DirectoryPath(parent);
            return output;
        }

        long Get_Size(FileInfo fileInfo)
            => fileInfo.Length;

        FileInfo New(string filePath)
            => new FileInfo(filePath);

        FileInfo Of(string filePath)
            => this.New(filePath);
    }
}
