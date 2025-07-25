using System;


namespace F10Y.L0000
{
    public class DirectorySeparators : IDirectorySeparators
    {
        #region Infrastructure

        public static IDirectorySeparators Instance { get; } = new DirectorySeparators();


        private DirectorySeparators()
        {
        }

        #endregion
    }
}
