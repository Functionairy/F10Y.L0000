using System;
using System.Data;
using System.Net.Http;
using System.Threading.Tasks;

using F10Y.T0002;


namespace F10Y.L0000
{
    [FunctionsMarker]
    public partial interface IHttpClientOperator
    {
        public async Task<HttpResponseMessage> Get_Reponse(
            string url,
            bool ensureSuccessStatusCode = IValues.EnsureSuccessStatusCode_Default_Constant)
        {
            using var client = new HttpClient();

            var response = await client.GetAsync(url);

            if(ensureSuccessStatusCode)
            {
                response.EnsureSuccessStatusCode();
            }

            return response;
        }

        public async Task<string> Get_ReponseContent_AsString(
            string url,
            bool ensureSuccessStatusCode = IValues.EnsureSuccessStatusCode_Default_Constant)
        {
            using var response = await this.Get_Reponse(
                url,
                ensureSuccessStatusCode);

            var output = await response.Content.ReadAsStringAsync();
            return output;
        }
    }
}
