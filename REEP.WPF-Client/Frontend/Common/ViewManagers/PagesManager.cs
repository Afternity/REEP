using Microsoft.Extensions.DependencyInjection;
using REEP.WPF_Client.Frontend.Common.Models;
using REEP.WPF_Client.Frontend.ViewModels.AuthViewModels;
using REEP.WPF_Client.Frontend.ViewModels.CommonViewModels;
using REEP.WPF_Client.Frontend.ViewModels.MaintenanceViewModels.TaskFromUser;
using REEP.WPF_Client.Frontend.ViewModels.UserViewModels;
using REEP.WPF_Client.Frontend.Views.AuthViews;
using REEP.WPF_Client.Frontend.Views.CommonViews;
using REEP.WPF_Client.Frontend.Views.ContractViews;
using REEP.WPF_Client.Frontend.Views.MaintenanceVeiws.TaskFromUser;
using REEP.WPF_Client.Frontend.Views.UserViews;
using System.Collections.ObjectModel;
using System.Windows.Controls;

namespace REEP.WPF_Client.Frontend.Common.ViewManagers
{
    public class PagesManager
    {
        private ObservableCollection<NavigationItem> _navigationItems = [];

        public ObservableCollection<NavigationItem> LoadNavigation()
        {

            if (App.CurrentUser.Type == "Сотрудник")
                UserNavigation();
            else
                AdminNavigation();

            return _navigationItems;
        }

        private void AdminNavigation()
        {
            _navigationItems = new ObservableCollection<NavigationItem>
            {
                new("Главная", "HomePage"),
                new("Контракты", "ContractPage"),
                new("Гарантии", "PasspotrPage"),
                new("Оборудование", "PasspotrPage"),
                new("Пасспарта", "PasspotrPage"),
                new("Пользователи", "UserPage"),
                new("Задачи", "TaskPage")
            };
        }

        private void UserNavigation()
        {
            _navigationItems = new ObservableCollection<NavigationItem>
            {
                new("Главная", "HomePage"),
                new("Профиль", "ProfilePage"),
                new("Задачи", "TaskPage")
            };
        }

        public Page NavigateTo(string pageName)
        {
            return pageName switch
            {
                "ContractPage" => new HomePageView(),
                "HomePage" => new HomePageView(),
                "ProfilePage" => ProfilePage(),
                "UserPage" => UserPage(),
                "TaskPage" => CreateMaintenanceRequestPage(),
                _ => throw new ArgumentException($"Unknown page: {pageName}")
            };
        }

        public ProfilePageView ProfilePage()
        {
            var view = App.ServiceProvider.GetRequiredService<ProfilePageView>();
            view.DataContext = App.ServiceProvider.GetRequiredService<ProfileViewModel>();
            return view;
        }

        public UserPageView UserPage()
        {
            var view = App.ServiceProvider.GetRequiredService<UserPageView>();
            view.DataContext = App.ServiceProvider.GetRequiredService<UserViewModel>();
            return view;
        }

        public CreateMaintenanceRequestPageView CreateMaintenanceRequestPage()
        {
            var view = App.ServiceProvider.GetRequiredService<CreateMaintenanceRequestPageView>();
            view.DataContext = App.ServiceProvider.GetRequiredService<CreateMaintenanceRequestViewModel>();
            return view;
        }
    }
}
