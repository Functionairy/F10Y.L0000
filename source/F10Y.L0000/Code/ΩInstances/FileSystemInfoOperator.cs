using System;


namespace F10Y.L0000
{
    public class FileSystemInfoOperator : IFileSystemInfoOperator
    {
        #region Infrastructure

        public static IFileSystemInfoOperator Instance { get; } = new FileSystemInfoOperator();


        private FileSystemInfoOperator()
        {
        }

        #endregion
    }
}
