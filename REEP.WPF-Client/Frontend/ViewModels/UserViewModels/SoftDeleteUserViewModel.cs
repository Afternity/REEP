using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using REEP.WPF_Client.Backend.Models.UserModels;
using REEP.WPF_Client.Backend.Services.IApiServices.IUserApiServices;
using REEP.WPF_Client.Frontend.Common.ViewManagers;
using System.Windows;

namespace REEP.WPF_Client.Frontend.ViewModels.UserViewModels
{
    public partial class SoftDeleteUserViewModel : ObservableObject
    {
        private readonly IUserService _userService;
        private readonly WindowsManager _windowsManager;
        private readonly Guid _userId;

        [ObservableProperty]
        private UserDetailsVm _selectedUser;

        public SoftDeleteUserViewModel(
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
                    CloseSoftDeleteUserWindow();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка загрузки данных пользователя: {ex.Message}",
                    "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                CloseSoftDeleteUserWindow();
            }
        }

        [RelayCommand]
        private async Task SoftDeleteUser()
        {
            if (SelectedUser == null) return;

            var message = SelectedUser.IsDeleted
                ? "Вы уверены, что хотите пометить пользователя как удалённого?"
                : "Вы уверены, что хотите восстановить пользователя?";

            var result = MessageBox.Show(message, "Подтверждение",
                MessageBoxButton.YesNo, MessageBoxImage.Question);

            if (result != MessageBoxResult.Yes) return;

            try
            {
                var dto = new SoftDeleteUserDto
                {
                    Id = SelectedUser.Id,
                    IsDeleted = SelectedUser.IsDeleted
                };

                bool success = await _userService.SoftDeleteUserAsync(dto);

                if (success)
                {
                    MessageBox.Show(SelectedUser.IsDeleted
                            ? "Пользователь успешно помечен как удалённый"
                            : "Пользователь успешно восстановлен",
                        "Успех", MessageBoxButton.OK, MessageBoxImage.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка изменения статуса пользователя: {ex.Message}",
                    "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        [RelayCommand]
        private void CloseSoftDeleteUserWindow()
        {
            _windowsManager.OnlyCloseSoftDeleteUserWindow();
        }
    }
}
