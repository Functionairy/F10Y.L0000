using System;


namespace F10Y.L0000
{
    public class XTexts : IXTexts
    {
        #region Infrastructure

        public static IXTexts Instance { get; } = new XTexts();


        private XTexts()
        {
        }

        #endregion
    }
}
