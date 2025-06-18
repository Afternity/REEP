using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using REEP.WPF_Client.Backend.Services.IApiServices.IUserApiServices.IAuthApiServices;
using REEP.WPF_Client.Frontend.Common.ViewManagers;
using REEP.WPF_Client.Frontend.Views.AuthViews;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace REEP.WPF_Client.Frontend.ViewModels.AuthViewModels
{
    public partial class RegisterViewModel : ObservableObject
    {
        private readonly IAuthService _authService;
        private readonly WindowsManager _windowManager;

        [ObservableProperty]
        private string _firstName;

        [ObservableProperty]
        private string _secondName;

        [ObservableProperty]
        private string _lastName;

        [ObservableProperty]
        private string _email;

        [ObservableProperty]
        private string _otherContacts;

        [ObservableProperty]
        private string _password;

        [ObservableProperty]
        private string _confirmPassword;

        [ObservableProperty]
        private string _errorMessage;

        [ObservableProperty]
        private bool _isLoading;

        public RegisterViewModel(IAuthService authService, WindowsManager windowManager)
        {
            _authService = authService;
            _windowManager = windowManager;
        }

        [RelayCommand]
        private async Task RegisterAsync()
        {
            if (string.IsNullOrWhiteSpace(FirstName))
            {
                ErrorMessage = "Имя обязательно";
                return;
            }

            if (string.IsNullOrWhiteSpace(SecondName))
            {
                ErrorMessage = "Фамилия обязательна";
                return;
            }

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

            if (Password != ConfirmPassword)
            {
                ErrorMessage = "Пароли не совпадают";
                return;
            }

            IsLoading = true;
            ErrorMessage = string.Empty;

            try
            {
                var success = await _authService.RegisterAsync(
                    firstName: FirstName,
                    secondName: SecondName,
                    lastName: LastName,
                    email: Email,
                    otherContacts: OtherContacts,
                    password: Password);

                if (success)
                {
                    MessageBox.Show("Регистрация завершена успешно!", "Успех",
                        MessageBoxButton.OK, MessageBoxImage.Information);
                    _windowManager.StartWorkAuthWindow();
                }
                else
                {
                    ErrorMessage = "Ошибка регистрации. Возможно, email уже используется.";
                }
            }
            catch (System.Exception ex)
            {
                ErrorMessage = $"Ошибка: {ex.Message}";
            }
            finally
            {
                IsLoading = false;
            }
        }

        [RelayCommand]
        private void SwitchToLogin()
        {
            _windowManager.StartWorkAuthWindow();
        }
    }
}
