using Refit;
using REEP.WPF_Client.Backend.Services.IApiServices.IUserApiServices.IAuthApiServices;
using REEP.WPF_Client.Backend.Models.UserModels.AuthModels;

namespace REEP.WPF_Client.Backend.Services.ApiServices.UserApiServices.AuthServices
{
    public class AuthService : IAuthService
    {
        private readonly IAuthApi _authApi;

        public AuthService(IAuthApi authApi)
        {
            _authApi = authApi;
        }

        public async Task<bool> AuthAsync(string email, string password)
        {
            try
            {
                App.CurrentUser = await _authApi.AuthAsync(email, password);
                return App.CurrentUser != null;
            }
            catch (ApiException)
            {
                return false;
            }
        }

        public async Task<bool> RegisterAsync(
            string firstName,
            string secondName,
            string lastName,
            string email,
            string otherContacts,
            string password)
        {
            try
            {
                var request = new CreateUserFromRegisterDto
                {
                    FirstName = firstName,
                    SecondName = secondName,
                    LastName = lastName,
                    Email = email,
                    OtherContacts = otherContacts,
                    Password = password
                };

                await _authApi.RegisterAsync(request);
                return true;
            }
            catch (ApiException ex)
            {
                // Можно добавить логирование
                return false;
            }
        }
    } 
}
