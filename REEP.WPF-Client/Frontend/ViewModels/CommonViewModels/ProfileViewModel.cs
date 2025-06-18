using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using REEP.WPF_Client.Backend.Models.UserModels;
using REEP.WPF_Client.Backend.Models.UserModels.AuthModels;
using REEP.WPF_Client.Backend.Services.IApiServices.IUserApiServices;
using System.Windows;

namespace REEP.WPF_Client.Frontend.ViewModels.CommonViewModels
{
    public partial class ProfileViewModel : ObservableObject
    {
        private readonly IUserService _userService;

        [ObservableProperty]
        private UserFromAuthDetailsVm _userDetails;

        public IAsyncRelayCommand SaveCommand { get; }
        public IAsyncRelayCommand RefreshCommand { get; }

        public ProfileViewModel(IUserService userService)
        {
            _userService = userService;
            UserDetails = App.CurrentUser ?? new UserFromAuthDetailsVm
            {
                FirstName = "Неизвестно",
                SecondName = "Неизвестно",
                LastName = "Неизвестно",
                Email = "Неизвестно",
                Type = "Неизвестно"
            };

            SaveCommand = new AsyncRelayCommand(SaveChanges);
            RefreshCommand = new AsyncRelayCommand(RefreshData);
        }

        private async Task SaveChanges()
        {
            try
            {
                var updateDto = new UpdateUserFromProfileDto
                {
                    Id = UserDetails.Id,
                    FirstName = UserDetails.FirstName,
                    SecondName = UserDetails.SecondName,
                    LastName = UserDetails.LastName,
                    Email = UserDetails.Email,
                    OtherContacts = UserDetails.OtherContacts,
                    Password = UserDetails.Password,
                    Type = UserDetails.Type
                };

                var success = await _userService.UpdateUserProfileAsync(updateDto);

                if (success)
                {
                    MessageBox.Show("Профиль успешно обновлен", "Успех",
                        MessageBoxButton.OK, MessageBoxImage.Information);
                    App.CurrentUser = UserDetails;
                }
                else
                {
                    MessageBox.Show("Не удалось обновить профиль", "Ошибка",
                        MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка при обновлении профиля: {ex.Message}",
                    "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private async Task RefreshData()
        {
            try
            {
                if (UserDetails?.Id == Guid.Empty) return;

                var userDetails = await _userService.GetUserDetailsAsync(UserDetails.Id);
                if (userDetails != null)
                {
                    UserDetails = new UserFromAuthDetailsVm
                    {
                        Id = userDetails.Id,
                        FirstName = userDetails.FirstName,
                        SecondName = userDetails.SecondName,
                        LastName = userDetails.LastName,
                        Email = userDetails.Email,
                        OtherContacts = userDetails.OtherContacts,
                        Password = userDetails.Password,
                        CreatedAt = userDetails.CreatedAt,
                        UpdatedAt = userDetails.UpdatedAt,
                        DeletedAt = userDetails.DeletedAt,
                        IsDeleted = userDetails.IsDeleted,
                        Type = userDetails.Type
                    };
                    App.CurrentUser = UserDetails;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка при обновлении данных: {ex.Message}",
                    "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }
}
