using System;


namespace F10Y.L0000
{
    public class ExitCodes : IExitCodes
    {
        #region Infrastructure

        public static IExitCodes Instance { get; } = new ExitCodes();


        private ExitCodes()
        {
        }

        #endregion
    }
}
