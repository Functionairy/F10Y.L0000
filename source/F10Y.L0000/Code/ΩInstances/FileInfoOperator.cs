using System;


namespace F10Y.L0000
{
    public class FileInfoOperator : IFileInfoOperator
    {
        #region Infrastructure

        public static IFileInfoOperator Instance { get; } = new FileInfoOperator();


        private FileInfoOperator()
        {
        }

        #endregion
    }
}
