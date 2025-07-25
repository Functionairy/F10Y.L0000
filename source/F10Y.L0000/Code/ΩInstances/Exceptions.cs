using System;


namespace F10Y.L0000
{
    public class Exceptions : IExceptions
    {
        #region Infrastructure

        public static IExceptions Instance { get; } = new Exceptions();


        private Exceptions()
        {
        }

        #endregion
    }
}
