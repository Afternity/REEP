using Microsoft.Extensions.DependencyInjection;
using System.Windows;
using REEP.WPF_Client.Frontend.Views.AuthViews;
using REEP.WPF_Client.Frontend.ViewModels.AuthViewModels;


namespace REEP.WPF_Client.Frontend.Common.ViewManagers.WindowManages
{
    public class WindowManager
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

        public void StartWorkRegisterWindow()
        {
            var view = App.ServiceProvider.GetRequiredService<RegisterWindowView>();
            view.DataContext = App.ServiceProvider.GetRequiredService<RegisterViewModel>();
            view.Show();

            Application.Current.Windows.OfType<AuthWindowView>().FirstOrDefault()?.Close();
        }
    }
}
