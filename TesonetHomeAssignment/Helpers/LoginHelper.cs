using Newtonsoft.Json;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Formatting;
using System.Threading.Tasks;

namespace TesonetHomeAssignment.Helpers
{
    static class LoginHelper
    {
        public static async Task<string> SendLoginRequest(string username, string password, HttpClient client)
        {
            var values = new Dictionary<string, string>
            {
                { "username", username },
                { "password", password }
            };

            var content = new FormUrlEncodedContent(values);
            var response = await client.PostAsync("https://playground.tesonet.lt/v1/tokens", content);
            var convertedResponse = await response.Content.ReadAsAsync<LoginResponse>(new[] { new JsonMediaTypeFormatter() });

            return convertedResponse.Token;
        }

    }
    struct LoginResponse
    {
        [JsonProperty("token")]
        public string Token { get; set; }
    }
}
