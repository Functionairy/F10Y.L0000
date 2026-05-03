using System;
using System.Net.Http;
using System.Threading.Tasks;

using F10Y.T0002;


namespace F10Y.L0000
{
    [FunctionsMarker]
    public partial interface IHttpClientOperator
    {
        async Task<HttpResponseMessage> Get_Response(
            HttpClient client,
            string url,
            bool ensureSuccessStatusCode = IValues.EnsureSuccessStatusCode_Default_Constant)
        {
            var response = await client.GetAsync(url);

            if (ensureSuccessStatusCode)
            {
                response.EnsureSuccessStatusCode();
            }

            return response;
        }

        /// <summary>
        /// Note: try to reuse the <see cref="HttpClient"/> (use <see cref="Get_Response(HttpClient, string, bool)"/>).
        /// This prevents TCP socket exhaustion.
        /// </summary>
        async Task<HttpResponseMessage> Get_Response(
            string url,
            bool ensureSuccessStatusCode = IValues.EnsureSuccessStatusCode_Default_Constant)
        {
            using var client = new HttpClient();

            var output = await this.Get_Response(
                client,
                url,
                ensureSuccessStatusCode);

            return output;
        }

        async Task<string> Get_ResponseContent_AsString(
            string url,
            bool ensureSuccessStatusCode = IValues.EnsureSuccessStatusCode_Default_Constant)
        {
            using var response = await this.Get_Response(
                url,
                ensureSuccessStatusCode);

            var output = await response.Content.ReadAsStringAsync();
            return output;
        }
    }
}
