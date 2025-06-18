using REEP.WPF_Client.Backend.Models.UserModels;
using REEP.WPF_Client.Backend.Models.UserModels.AuthModels;
using Refit;

namespace REEP.WPF_Client.Backend.Services.IApiServices.IUserApiServices
{
    public interface IUserApi
    {
        [Post("/api/v1.0/user")]
        Task<Guid> CreateUserAsync([Body] CreateUserDto createUserDto);

        [Post("/api/v1.0/user/register")]
        Task RegisterUserAsync([Body] CreateUserFromRegisterDto createUserFromRegisterDto);

        [Put("/api/v1.0/user")]
        Task UpdateUserAsync([Body] UpdateUserDto updateUserDto);

        [Put("/api/v1.0/user/profile")]
        Task UpdateUserProfileAsync([Body] UpdateUserFromProfileDto updateUserFromProfileDto);

        [Put("/api/v1.0/user/soft-delete")]
        Task SoftDeleteUserAsync([Body] SoftDeleteUserDto softDeleteUserDto);

        [Delete("/api/v1.0/user/{id}")]
        Task HardDeleteUserAsync(Guid id);

        [Get("/api/v1.0/user/{id}")]
        Task<UserDetailsVm> GetUserDetailsAsync(Guid id);

        [Get("/api/v1.0/user/{email}:{password}")]
        Task<UserDetailsVm> GetUserFromAuthDetailsAsync(string email, string password);

        [Get("/api/v1.0/user/{isDeleted}/get-all")]
        Task<UserListVm> GetAllUsersAsync(bool isDeleted);
    }
}

