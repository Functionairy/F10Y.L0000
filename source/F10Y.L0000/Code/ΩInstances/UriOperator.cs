using System;


namespace F10Y.L0000
{
    public class UriOperator : IUriOperator
    {
        #region Infrastructure

        public static IUriOperator Instance { get; } = new UriOperator();


        private UriOperator()
        {
        }

        #endregion
    }
}
