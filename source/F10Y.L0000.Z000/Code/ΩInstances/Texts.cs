using System;


namespace F10Y.L0000.Z000
{
    public class Texts : ITexts
    {
        #region Infrastructure

        public static ITexts Instance { get; } = new Texts();


        private Texts()
        {
        }

        #endregion
    }
}


namespace F10Y.L0000.Z000.Raw
{
    public class Texts : ITexts
    {
        #region Infrastructure

        public static ITexts Instance { get; } = new Texts();


        private Texts()
        {
        }

        #endregion
    }
}