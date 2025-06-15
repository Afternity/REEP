using Duende.IdentityModel.Client;
using System.Net.Http;
using System.Net.Http.Json;

namespace REEP.WPF_Client.Backend.Services.AuthServisec
{
    public class AuthService : IAuthService
    {
        private readonly HttpClient _httpClient;

        public AuthService(IHttpClientFactory httpClientFactory)
        {
            _httpClient = httpClientFactory.CreateClient("ApiClient");
        }

        public async Task<bool> LoginAsync(string username, string password)
        {
            try
            {
                var response = await _httpClient.PostAsJsonAsync("api/auth/login",
                    new { Username = username, Password = password });

                if (response.IsSuccessStatusCode)
                {
                    App.CurrentUsername = username;
                    return true;
                }
                return false;
            }
            catch
            {
                return false;
            }
        }

        public async Task<bool> RegisterAsync(string username, string password)
        {
            var response = await _httpClient.PostAsJsonAsync("api/auth/register",
                new { Username = username, Password = password });

            return response.IsSuccessStatusCode;
        }
    }
}
