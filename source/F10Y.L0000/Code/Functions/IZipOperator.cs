using System;
using System.IO.Compression;

using F10Y.T0002;


namespace F10Y.L0000
{
    [FunctionsMarker]
    public partial interface IZipOperator
    {
        public void Unzip_ToDirectory(
            string source_zipFilePath,
            string destination_DirectoryPath,
            bool overwrite = IValues.Overwrite_Default_Constant)
        {
            ZipFile.ExtractToDirectory(
                source_zipFilePath,
                destination_DirectoryPath,
                overwrite);
        }
    }
}
