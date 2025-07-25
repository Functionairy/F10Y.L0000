using System;


namespace F10Y.L0000.Construction
{
    public class StringOperatorDemonstrations : IStringOperatorDemonstrations
    {
        #region Infrastructure

        public static IStringOperatorDemonstrations Instance { get; } = new StringOperatorDemonstrations();


        private StringOperatorDemonstrations()
        {
        }

        #endregion
    }
}
