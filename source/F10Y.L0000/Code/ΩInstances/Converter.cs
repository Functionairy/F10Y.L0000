using System;


namespace F10Y.L0000
{
    public class Converter : IConverter
    {
        #region Infrastructure

        public static IConverter Instance { get; } = new Converter();


        private Converter()
        {
        }

        #endregion
    }
}
