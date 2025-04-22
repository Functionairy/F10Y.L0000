using System;


namespace F10Y.L0000
{
    public class FileOperator : IFileOperator
    {
        #region Infrastructure

        public static IFileOperator Instance { get; } = new FileOperator();


        private FileOperator()
        {
        }

        #endregion
    }
}
