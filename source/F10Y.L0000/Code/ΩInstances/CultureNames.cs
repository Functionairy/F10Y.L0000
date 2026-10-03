using System;


namespace F10Y.L0000
{
    public class CultureNames : ICultureNames
    {
        #region Infrastructure

        public static ICultureNames Instance { get; } = new CultureNames();


        private CultureNames()
        {
        }

        #endregion
    }
}
