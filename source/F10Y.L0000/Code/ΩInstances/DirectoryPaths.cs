using System;


namespace F10Y.L0000
{
    public class DirectoryPaths : IDirectoryPaths
    {
        #region Infrastructure

        public static IDirectoryPaths Instance { get; } = new DirectoryPaths();


        private DirectoryPaths()
        {
        }

        #endregion
    }
}
