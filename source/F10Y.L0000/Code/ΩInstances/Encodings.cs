using System;


namespace F10Y.L0000
{
    public class Encodings : IEncodings
    {
        #region Infrastructure

        public static IEncodings Instance { get; } = new Encodings();


        private Encodings()
        {
        }

        #endregion
    }
}
