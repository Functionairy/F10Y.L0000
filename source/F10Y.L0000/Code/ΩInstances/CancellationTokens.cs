using System;


namespace F10Y.L0000
{
    public class CancellationTokens : ICancellationTokens
    {
        #region Infrastructure

        public static ICancellationTokens Instance { get; } = new CancellationTokens();


        private CancellationTokens()
        {
        }

        #endregion
    }
}
