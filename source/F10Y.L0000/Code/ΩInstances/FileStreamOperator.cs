using System;


namespace F10Y.L0000
{
    public class FileStreamOperator : IFileStreamOperator
    {
        #region Infrastructure

        public static IFileStreamOperator Instance { get; } = new FileStreamOperator();


        private FileStreamOperator()
        {
        }

        #endregion
    }
}
