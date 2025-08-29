using System;


namespace F10Y.L0000
{
    public class CultureInfos : ICultureInfos
    {
        #region Infrastructure

        public static ICultureInfos Instance { get; } = new CultureInfos();


        private CultureInfos()
        {
        }

        #endregion
    }
}
