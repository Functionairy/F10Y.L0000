using System;


namespace F10Y.L0000
{
    public class HttpClientOperator : IHttpClientOperator
    {
        #region Infrastructure

        public static IHttpClientOperator Instance { get; } = new HttpClientOperator();


        private HttpClientOperator()
        {
        }

        #endregion
    }
}
