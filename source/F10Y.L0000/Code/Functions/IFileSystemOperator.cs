using System;
using System.IO;

using F10Y.T0002;


namespace F10Y.L0000
{
    [FunctionsMarker]
    public partial interface IFileSystemOperator
    {
        public bool Exists_Directory(string directoryPath)
        {
            var output = Directory.Exists(directoryPath);
            return output;
        }

        public bool Exists_File(string filePath)
        {
            var output = File.Exists(filePath);
            return output;
        }
    }
}
