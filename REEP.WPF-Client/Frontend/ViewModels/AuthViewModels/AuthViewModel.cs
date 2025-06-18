using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using REEP.WPF_Client.Backend.Services.IApiServices.IUserApiServices.IAuthApiServices;
using REEP.WPF_Client.Frontend.Common.ViewManagers;

namespace REEP.WPF_Client.Frontend.ViewModels.AuthViewModels
{
    public partial class AuthViewModel : ObservableObject
    {
        private readonly IAuthService _authService;
        private readonly WindowsManager _windowManager;

        [ObservableProperty]
        private string _email = "a89267939941@gmail.com";

        [ObservableProperty]
        private string _password = "111";

        [ObservableProperty]
        private string _errorMessage;

        [ObservableProperty]
        private bool _isLoading;

        public AuthViewModel(IAuthService authService, WindowsManager windowManager)
        {
            _authService = authService;
            _windowManager = windowManager;
        }

        [RelayCommand]
        private async Task LoginAsync()
        {
            if (string.IsNullOrWhiteSpace(Email))
            {
                ErrorMessage = "Email обязателен";
                return;
            }

            if (string.IsNullOrWhiteSpace(Password))
            {
                ErrorMessage = "Пароль обязателен";
                return;
            }

            IsLoading = true;
            ErrorMessage = string.Empty;

            try
            {
                var success = await _authService.AuthAsync(Email, Password);
                if (success)
                {
                    ErrorMessage = "Вход выполнен успешно!";

                    _windowManager.StartWorkHomeCommonWidow();
                }
                else
                {
                    ErrorMessage = "Неверный email или пароль";
                }
            }
            catch (Exception ex)
            {
                ErrorMessage = $"Ошибка: {ex.Message}";
            }
            finally
            {
                IsLoading = false;
            }
        }

        [RelayCommand]
        private void SwitchToRegister()
        {
            _windowManager.StartWorkRegisterWindow();
        }
    }
}
