using System;


namespace F10Y.L0000.Construction
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
