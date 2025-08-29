using System;


namespace F10Y.L0000
{
    public class HashCodes : IHashCodes
    {
        #region Infrastructure

        public static IHashCodes Instance { get; } = new HashCodes();


        private HashCodes()
        {
        }

        #endregion
    }
}
