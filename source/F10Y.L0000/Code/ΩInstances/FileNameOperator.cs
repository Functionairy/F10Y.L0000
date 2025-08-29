using System;


namespace F10Y.L0000
{
    public class FileNameOperator : IFileNameOperator
    {
        #region Infrastructure

        public static IFileNameOperator Instance { get; } = new FileNameOperator();


        private FileNameOperator()
        {
        }

        #endregion
    }
}
