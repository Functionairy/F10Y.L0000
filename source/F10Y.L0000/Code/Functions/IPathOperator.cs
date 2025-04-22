using System;
using System.IO;

using F10Y.T0002;


namespace F10Y.L0000
{
    [FunctionsMarker]
    public partial interface IPathOperator
    {
        public string Get_DirectoryPath(
            string baseDirectoryPath,
            string relativeDirectoryPath)
        {
            var output = this.Get_Path(
                baseDirectoryPath,
                relativeDirectoryPath);

            return output;
        }

        public string Get_ParentDirectoryPath_ForFile(string filePath)
        {
            var fileInfo = new FileInfo(filePath);

            var parentDirectoryPath = fileInfo.Directory.FullName;

            // Unchecked, since we know the directory full name is *not* directory indicated.
            var output = this.Make_DirectoryIndicated(parentDirectoryPath);
            return output;
        }

        public string Get_Path(
            string basePath,
            string path_RelativeToBasePath)
        {
            var output = Path.Combine(
                basePath,
                path_RelativeToBasePath);

            return output;
        }

        public string Make_DirectoryIndicated(string path)
        {
            var output = path + "\\"; // this.Make_DirectoryIndicated(path, true);
            return output;
        }
    }
}
