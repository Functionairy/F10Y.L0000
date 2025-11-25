using System;


namespace F10Y.L0000.Construction
{
    public class VersionDemonstrations : IVersionDemonstrations
    {
        #region Infrastructure

        public static IVersionDemonstrations Instance { get; } = new VersionDemonstrations();


        private VersionDemonstrations()
        {
        }

        #endregion
    }
}
