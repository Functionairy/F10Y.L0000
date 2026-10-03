using System;


namespace F10Y.L0000
{
    public class Decimals : IDecimals
    {
        #region Infrastructure

        public static IDecimals Instance { get; } = new Decimals();


        private Decimals()
        {
        }

        #endregion
    }
}
