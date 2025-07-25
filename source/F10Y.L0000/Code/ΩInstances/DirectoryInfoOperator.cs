using System;


namespace F10Y.L0000
{
    public class DirectoryInfoOperator : IDirectoryInfoOperator
    {
        #region Infrastructure

        public static IDirectoryInfoOperator Instance { get; } = new DirectoryInfoOperator();


        private DirectoryInfoOperator()
        {
        }

        #endregion
    }
}
