using Refit;
using REEP.WPF_Client.Backend.Models.AuthModels;

namespace REEP.WPF_Client.Backend.Services.IApiServices.IAuthApiServices
{
    public interface IAuthApi
    {
        [Post("/api/v1.0/user/register")]
        Task RegisterAsync([Body] CreateUserFromRegisterDto request);

        [Get("/api/v1.0/user/{email}:{password}")]
        Task<UserFromAuthDetailsVm> AuthAsync(string email, string password);

    }
}
