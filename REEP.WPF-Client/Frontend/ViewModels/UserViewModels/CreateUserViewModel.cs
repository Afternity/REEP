using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using REEP.WPF_Client.Backend.Models.UserModels;
using REEP.WPF_Client.Backend.Services.IApiServices.IUserApiServices;
using REEP.WPF_Client.Frontend.Common.ViewManagers;
using System.Windows;

namespace REEP.WPF_Client.Frontend.ViewModels.UserViewModels
{
    public partial class CreateUserViewModel : ObservableObject
    {
        private readonly IUserService _userService;
        private readonly WindowsManager _windowsManager;

        [ObservableProperty]
        private CreateUserDto _selectedUser = new();

        public CreateUserViewModel(
            IUserService userService,
            WindowsManager windowsManager)
        {
            _userService = userService;
            _windowsManager = windowsManager;
        }

        [RelayCommand]
        private async Task CreateUser()
        {
            try
            {
                // Проверка обязательных полей
                if (string.IsNullOrWhiteSpace(SelectedUser.FirstName) ||
                    string.IsNullOrWhiteSpace(SelectedUser.SecondName) ||
                    string.IsNullOrWhiteSpace(SelectedUser.Email) ||
                    string.IsNullOrWhiteSpace(SelectedUser.Type) ||
                    string.IsNullOrWhiteSpace(SelectedUser.Password))
                {
                    MessageBox.Show("Заполните все обязательные поля (помечены *)",
                        "Ошибка", MessageBoxButton.OK, MessageBoxImage.Warning);
                    return;
                }

                var userId = await _userService.CreateUserAsync(SelectedUser);

                if (userId != Guid.Empty)
                {
                    MessageBox.Show("Пользователь успешно добавлен",
                       "Успех", MessageBoxButton.OK, MessageBoxImage.Information);
                }
                else
                {
                    MessageBox.Show("Не удалось создать пользователя",
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
        private void CloseCreateUserWindow()
        {
            _windowsManager.OnlyCloseCreateUserWindow();
        }
    }
}
