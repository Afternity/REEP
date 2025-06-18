using Microsoft.Extensions.DependencyInjection;
using System.Windows;
using REEP.WPF_Client.Frontend.Views.AuthViews;
using REEP.WPF_Client.Frontend.ViewModels.AuthViewModels;
using REEP.WPF_Client.Frontend.Views.CommonViews;
using REEP.WPF_Client.Frontend.ViewModels.CommonViewModels;
using REEP.WPF_Client.Frontend.Views.UserViews;
using REEP.WPF_Client.Frontend.ViewModels.UserViewModels;


namespace REEP.WPF_Client.Frontend.Common.ViewManagers
{
    public class WindowsManager
    {
        public void AuthWindow()
        {
            var visibilityWindow = Application
                .Current
                .Windows
                .OfType<AuthWindowView>()
                .FirstOrDefault(window => window.IsVisible);

            if (visibilityWindow != null)
            {
                visibilityWindow.Activate();
                return;
            }

            var view = App.ServiceProvider.GetRequiredService<AuthWindowView>();
            view.DataContext = App.ServiceProvider.GetRequiredService<AuthViewModel>();
            view.Show();
        }

        public void RegisterWindow()
        {
            var visibilityWindow = Application
                .Current
                .Windows
                .OfType<RegisterWindowView>()
                .FirstOrDefault(window => window.IsVisible);

            if (visibilityWindow != null)
            {
                visibilityWindow.Activate();
                return;
            }

            var view = App.ServiceProvider.GetRequiredService<RegisterWindowView>();
            view.DataContext = App.ServiceProvider.GetRequiredService<RegisterViewModel>();
            view.Show();
        }

        public void StartWorkAuthWindow()
        {
            var view = App.ServiceProvider.GetRequiredService<AuthWindowView>();
            view.DataContext = App.ServiceProvider.GetRequiredService<AuthViewModel>();
            view.Show();

            Application.Current.Windows.OfType<RegisterWindowView>().FirstOrDefault()?.Close();
        }

        public void ExitAuthWindow()
        {
            var view = App.ServiceProvider.GetRequiredService<AuthWindowView>();
            view.DataContext = App.ServiceProvider.GetRequiredService<AuthViewModel>();
            view.Show();

            Application.Current.Windows.OfType<CommonWindowView>().FirstOrDefault()?.Close();
        }

        public void StartWorkRegisterWindow()
        {
            var view = App.ServiceProvider.GetRequiredService<RegisterWindowView>();
            view.DataContext = App.ServiceProvider.GetRequiredService<RegisterViewModel>();
            view.Show();

            Application.Current.Windows.OfType<AuthWindowView>().FirstOrDefault()?.Close();
        }

        public void StartWorkHomeCommonWidow()
        {
            var view = App.ServiceProvider.GetRequiredService<CommonWindowView>();
            view.DataContext = App.ServiceProvider.GetRequiredService<CommonViewModel>();
            view.Show();

            Application.Current.Windows.OfType<AuthWindowView>().FirstOrDefault()?.Close();
        }

        public void CloseAllUserCommandWindows()
        {
            Application.Current.Windows.OfType<CreateUserWindowView>().FirstOrDefault()?.Close();
            Application.Current.Windows.OfType<UpdateUserWindowView>().FirstOrDefault()?.Close();
            Application.Current.Windows.OfType<SoftDeleteUserWindowView>().FirstOrDefault()?.Close();
        }

        public void OnlyCloseCreateUserWindow()
        {
            Application.Current.Windows.OfType<CreateUserWindowView>().FirstOrDefault()?.Close();
        }

        public void OpenCreateUserWindow()
        {
            var visibilityWindow = Application
                .Current
                .Windows
                .OfType<CreateUserWindowView>()
                .FirstOrDefault(window => window.IsVisible);

            if (visibilityWindow != null)
            {
                visibilityWindow.Activate();
                return;
            }

            var view = App.ServiceProvider.GetRequiredService<CreateUserWindowView>();
            view.DataContext = App.ServiceProvider.GetRequiredService<CreateUserViewModel>();
            view.Show();
        }

        public void OnlyCloseSoftDeleteUserWindow()
        {
            Application.Current.Windows.OfType<SoftDeleteUserWindowView>().FirstOrDefault()?.Close();
        }

        public void OpenSoftDeleteUserWindow(Guid userId)
        {
            var existingWindow = Application.Current.Windows
                .OfType<SoftDeleteUserWindowView>()
                .FirstOrDefault(w => w.IsVisible);

            if (existingWindow != null)
            {
                existingWindow.Activate();
                return;
            }

            var view = App.ServiceProvider.GetRequiredService<SoftDeleteUserWindowView>();
            var viewModel = App.ServiceProvider.GetRequiredService<Func<Guid, SoftDeleteUserViewModel>>()(userId);

            view.DataContext = viewModel;
            view.Show();
        }

        public void OnlyCloseUpdateUserWindow()
        {
            Application.Current.Windows.OfType<UpdateUserWindowView>().FirstOrDefault()?.Close();
        }

        public void OpenUpdateUserWindow(Guid userId)
        {
            var visibilityWindow = Application
                .Current
                .Windows
                .OfType<UpdateUserWindowView>()
                .FirstOrDefault(window => window.IsVisible);

            if (visibilityWindow != null)
            {
                visibilityWindow.Activate();
                return;
            }

            var view = App.ServiceProvider.GetRequiredService<UpdateUserWindowView>();
            var viewModel = App.ServiceProvider.GetRequiredService<Func<Guid, UpdateUserViewModel>>()(userId);

            view.DataContext = viewModel;
            view.Show();
        }
    }
}
