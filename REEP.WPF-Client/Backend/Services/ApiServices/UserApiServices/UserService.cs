using Refit;
using REEP.WPF_Client.Backend.Models.UserModels;
using REEP.WPF_Client.Backend.Models.UserModels.AuthModels;
using REEP.WPF_Client.Backend.Services.IApiServices.IUserApiServices;

namespace REEP.WPF_Client.Backend.Services.ApiServices.UserApiServices
{
    public class UserService : IUserService
    {
        private readonly IUserApi _userApi;

        public UserService(IUserApi userApi)
        {
            _userApi = userApi;
        }

        public async Task<Guid> CreateUserAsync(CreateUserDto createUserDto)
        {
            try
            {
                return await _userApi.CreateUserAsync(createUserDto);
            }
            catch (ApiException ex)
            {
                throw new Exception("Failed to create user", ex);
            }
        }

        public async Task<bool> RegisterUserAsync(CreateUserFromRegisterDto dto)
        {
            try
            {
                await _userApi.RegisterUserAsync(dto);
                return true;
            }
            catch (ApiException)
            {
                return false;
            }
        }

        public async Task<bool> UpdateUserAsync(UpdateUserDto updateDto)
        {
            try
            {
                await _userApi.UpdateUserAsync(updateDto);
                return true;
            }
            catch (ApiException)
            {
                return false;
            }
        }

        public async Task<bool> UpdateUserProfileAsync(UpdateUserFromProfileDto profileDto)
        {
            try
            {
                await _userApi.UpdateUserProfileAsync(profileDto);
                return true;
            }
            catch (ApiException)
            {
                return false;
            }
        }

        public async Task<bool> SoftDeleteUserAsync(SoftDeleteUserDto softDeleteDto)
        {
            try
            {
                await _userApi.SoftDeleteUserAsync(softDeleteDto);
                return true;
            }
            catch (ApiException)
            {
                return false;
            }
        }

        public async Task<bool> HardDeleteUserAsync(Guid id)
        {
            try
            {
                await _userApi.HardDeleteUserAsync(id);
                return true;
            }
            catch (ApiException)
            {
                return false;
            }
        }

        public async Task<UserDetailsVm> GetUserDetailsAsync(Guid id)
        {
            try
            {
                return await _userApi.GetUserDetailsAsync(id);
            }
            catch (ApiException ex)
            {
                throw new Exception($"Failed to get user details for {id}", ex);
            }
        }

        public async Task<UserDetailsVm> GetUserFromAuthDetailsAsync(string email, string password)
        {
            try
            {
                return await _userApi.GetUserFromAuthDetailsAsync(email, password);
            }
            catch (ApiException ex)
            {
                throw new Exception("Authentication failed", ex);
            }
        }

        public async Task<UserListVm> GetAllUsersAsync(bool isDeleted)
        {
            try
            {
                return await _userApi.GetAllUsersAsync(isDeleted);
            }
            catch (ApiException ex)
            {
                throw new Exception("Failed to get users list", ex);
            }
        }
    }
}
