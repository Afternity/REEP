using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using REEP.WPF_Client.Backend.Models.UserModels;
using REEP.WPF_Client.Backend.Services.IApiServices.IUserApiServices;
using REEP.WPF_Client.Frontend.Common.ViewManagers;
using System.Windows;

namespace REEP.WPF_Client.Frontend.ViewModels.UserViewModels
{
    public partial class UpdateUserViewModel : ObservableObject
    {
        private readonly IUserService _userService;
        private readonly WindowsManager _windowsManager;
        private readonly Guid _userId;

        [ObservableProperty]
        private UserDetailsVm _selectedUser = new();

        public UpdateUserViewModel(
            IUserService userService,
            WindowsManager windowsManager,
            Guid userId)
        {
            _userService = userService;
            _windowsManager = windowsManager;
            _userId = userId;
            LoadDataAsync().ConfigureAwait(false);
        }

        private async Task LoadDataAsync()
        {
            try
            {
                SelectedUser = await _userService.GetUserDetailsAsync(_userId);

                if (SelectedUser == null)
                {
                    MessageBox.Show("Пользователь не был загружен",
                        "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                    CloseUpdateUserWindow();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка загрузки данных пользователя: {ex.Message}",
                    "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                CloseUpdateUserWindow();
            }
        }

        [RelayCommand]
        private async Task UpdateUser()
        {
            if (SelectedUser == null) return;

            var result = MessageBox.Show(
                "Вы уверены, что хотите сохранить изменения?",
                "Подтверждение",
                MessageBoxButton.YesNo,
                MessageBoxImage.Question);

            if (result != MessageBoxResult.Yes) return;

            try
            {
                var dto = new UpdateUserDto
                {
                    Id = SelectedUser.Id,
                    FirstName = SelectedUser.FirstName,
                    SecondName = SelectedUser.SecondName,
                    LastName = SelectedUser.LastName,
                    Email = SelectedUser.Email,
                    OtherContacts = SelectedUser.OtherContacts,
                    Password = SelectedUser.Password,
                    Type = SelectedUser.Type
                };

                bool success = await _userService.UpdateUserAsync(dto);

                if (success)
                {
                    MessageBox.Show("Данные пользователя успешно обновлены",
                        "Успех", MessageBoxButton.OK, MessageBoxImage.Information);
                }
                else
                {
                    MessageBox.Show("Не удалось обновить данные пользователя",
                        "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка обновления пользователя: {ex.Message}",
                    "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        [RelayCommand]
        private void CloseUpdateUserWindow()
        {
            _windowsManager.OnlyCloseUpdateUserWindow();
        }
    }
}
