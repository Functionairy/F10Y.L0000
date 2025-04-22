using System;
using System.IO;

using F10Y.T0002;


namespace F10Y.L0000
{
    [FunctionsMarker]
    public partial interface IFileStreamOperator
    {
        /// <summary>
        /// Eases construction of a new <see cref="FileStream"/> with a best-practice implementation of handling the overwrite parameter.
        /// </summary>
        public FileStream Open_Write(
            string filePath,
            bool overwrite = IValues.Overwrite_Default_Constant)
        {
            // File stream creation will fail if the parent directory does not exist.
            Instances.FileSystemOperator.Ensure_DirectoryExists_ForFilePath(filePath);

            // Get the file mode corresponding to the overwrite value.
            var fileMode = Instances.FileModeOperator.Get_FileMode(overwrite);

            var fileStream = new FileStream(
                filePath,
                fileMode,
                FileAccess.Write,
                // Allow other processes to read the file.
                FileShare.Read);

            return fileStream;
        }

        public FileStream Open_Read(string filePath)
        {
            var fileStream = new FileStream(
                filePath,
                FileMode.Open,
                FileAccess.Read,
                // Allow other processes to read the file.
                FileShare.Read);

            return fileStream;
        }
    }
}
