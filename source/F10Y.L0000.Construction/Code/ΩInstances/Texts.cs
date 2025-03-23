using System;


namespace F10Y.L0000.Construction
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
