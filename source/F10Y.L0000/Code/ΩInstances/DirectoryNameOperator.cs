using System;


namespace F10Y.L0000
{
    public class DirectoryNameOperator : IDirectoryNameOperator
    {
        #region Infrastructure

        public static IDirectoryNameOperator Instance { get; } = new DirectoryNameOperator();


        private DirectoryNameOperator()
        {
        }

        #endregion
    }
}
