using System;


namespace F10Y.L0000.Q000.L000
{
    public class GuidDemonstrations : IGuidDemonstrations
    {
        #region Infrastructure

        public static IGuidDemonstrations Instance { get; } = new GuidDemonstrations();


        private GuidDemonstrations()
        {
        }

        #endregion
    }
}
