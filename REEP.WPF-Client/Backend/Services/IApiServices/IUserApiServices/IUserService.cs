using REEP.WPF_Client.Backend.Models.UserModels;
using REEP.WPF_Client.Backend.Models.UserModels.AuthModels;

namespace REEP.WPF_Client.Backend.Services.IApiServices.IUserApiServices
{
    public interface IUserService
    {
        Task<Guid> CreateUserAsync(CreateUserDto createUserDto);
        Task<bool> RegisterUserAsync(CreateUserFromRegisterDto dto);
        Task<bool> UpdateUserAsync(UpdateUserDto updateDto);
        Task<bool> UpdateUserProfileAsync(UpdateUserFromProfileDto profileDto);
        Task<bool> SoftDeleteUserAsync(SoftDeleteUserDto softDeleteDto);
        Task<bool> HardDeleteUserAsync(Guid id);
        Task<UserDetailsVm> GetUserDetailsAsync(Guid id);
        Task<UserDetailsVm> GetUserFromAuthDetailsAsync(string email, string password);
        Task<UserListVm> GetAllUsersAsync(bool isDeleted);
    }
}
