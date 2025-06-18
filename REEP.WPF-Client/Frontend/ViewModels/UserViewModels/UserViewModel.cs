using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using REEP.WPF_Client.Backend.Models.UserModels;
using REEP.WPF_Client.Backend.Services.IApiServices.IUserApiServices;
using REEP.WPF_Client.Frontend.Common.ViewManagers;
using System.Windows;

namespace REEP.WPF_Client.Frontend.ViewModels.UserViewModels
{
    public partial class UserViewModel : ObservableObject
    {
        private readonly IUserService _userService;
        private readonly WindowsManager _windowsManager;

        [ObservableProperty]
        private bool _isDeletedUser = false;

        [ObservableProperty]
        private UserListVm _users = new();

        [ObservableProperty]
        private UserLookupDto? _selectedUser;

        [ObservableProperty]
        private UserDetailsVm? _userDetails;

        public bool HasSelectedUser => SelectedUser != null;

        public UserViewModel(
            IUserService userService,
            WindowsManager windowsManager)
        {
            _userService = userService;
            _windowsManager = windowsManager;
            LoadDataAsync().ConfigureAwait(false);
        }

        private async Task LoadDataAsync()
        {
            try
            {
                Users = await _userService.GetAllUsersAsync(IsDeletedUser) ?? new UserListVm();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка загрузки пользователей: {ex.Message}",
                    "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        [RelayCommand]
        private async Task UpdateData()
        {
           await LoadDataAsync();
        }

        [RelayCommand]
        private void CreateUser()
        {
            _windowsManager.OpenCreateUserWindow(); 
        }

        [RelayCommand]
        private void UpdateUser()
        {
            if (SelectedUser == null) return;

            _windowsManager.OpenUpdateUserWindow(SelectedUser.Id);
        }

        [RelayCommand]
        private void SoftDeleteUser()
        {
            if (SelectedUser == null) return;

            _windowsManager.OpenSoftDeleteUserWindow(SelectedUser.Id);
        }

        [RelayCommand]
        private async Task HardDeleteUser()
        {
            if (SelectedUser == null) return;

            var confirm = MessageBox.Show(
                $"Вы уверены, что хотите навсегда удалить пользователя {SelectedUser.Email}?",
                "Подтверждение удаления",
                MessageBoxButton.YesNo,
                MessageBoxImage.Warning);

            if (confirm == MessageBoxResult.Yes)
            {
                try
                {
                    var success = await _userService.HardDeleteUserAsync(SelectedUser.Id);

                    if (success)
                    {
                        MessageBox.Show("Пользователь полностью удален",
                            "Успех", MessageBoxButton.OK, MessageBoxImage.Information);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Ошибка удаления пользователя: {ex.Message}",
                        "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
        }

        [RelayCommand]
        private async Task ShowUserDetails()
        {
            if (SelectedUser == null) return;

            try
            {
                // Обновляем детали пользователя, получая свежие данные с сервера
                var freshDetails = await _userService.GetUserDetailsAsync(SelectedUser.Id);
                UserDetails = freshDetails;

                MessageBox.Show(
                    $"Детали пользователя успешно извечены!\n\n" +
                    $"Email: {freshDetails.Email}\n" +
                    $"Тип: {freshDetails.Type}",
                    "Детали пользователя",
                    MessageBoxButton.OK,
                    MessageBoxImage.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка получения деталей пользователя: {ex.Message}",
                    "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }
}

