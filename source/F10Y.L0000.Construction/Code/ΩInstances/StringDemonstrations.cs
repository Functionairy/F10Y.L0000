using System;


namespace F10Y.L0000.Construction
{
    public class StringDemonstrations : IStringDemonstrations
    {
        #region Infrastructure

        public static IStringDemonstrations Instance { get; } = new StringDemonstrations();


        private StringDemonstrations()
        {
        }

        #endregion
    }
}
