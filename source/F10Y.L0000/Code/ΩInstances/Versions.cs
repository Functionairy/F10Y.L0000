using System;


namespace F10Y.L0000
{
    public class Versions : IVersions
    {
        #region Infrastructure

        public static IVersions Instance { get; } = new Versions();


        private Versions()
        {
        }

        #endregion
    }
}


namespace F10Y.L0000.Raw
{
    public class Versions : IVersions
    {
        #region Infrastructure

        public static IVersions Instance { get; } = new Versions();


        private Versions()
        {
        }

        #endregion
    }
}