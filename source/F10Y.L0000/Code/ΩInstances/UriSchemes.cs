using System;


namespace F10Y.L0000
{
    public class UriSchemes : IUriSchemes
    {
        #region Infrastructure

        public static IUriSchemes Instance { get; } = new UriSchemes();


        private UriSchemes()
        {
        }

        #endregion
    }
}
