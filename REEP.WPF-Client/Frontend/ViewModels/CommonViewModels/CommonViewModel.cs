using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System.Collections.ObjectModel;
using System.Windows.Controls;
using REEP.WPF_Client.Frontend.Common.Models;
using REEP.WPF_Client.Backend.Models.UserModels.AuthModels;
using REEP.WPF_Client.Frontend.Common.ViewManagers;

namespace REEP.WPF_Client.Frontend.ViewModels.CommonViewModels
{
    public partial class CommonViewModel : ObservableObject
    {
        private readonly PagesManager _pagesManager;
        private readonly WindowsManager _windowManager;

        [ObservableProperty]
        private Page _currentPage;

        public ObservableCollection<NavigationItem> NavigationItems { get; }

        public CommonViewModel(PagesManager pageManager, WindowsManager windowManager)
        {
            _pagesManager = pageManager;
            _windowManager = windowManager;
            NavigationItems = _pagesManager.LoadNavigation();

            // Загружаем стартовую страницу
            NavigateTo("HomePage");
        }

        [RelayCommand]
        private void NavigateTo(string pageName)
        {
            CurrentPage = _pagesManager.NavigateTo(pageName);
        }

        [RelayCommand]
        private void OpenProfile()
        {
            // Логика открытия профиля
            CurrentPage = _pagesManager.NavigateTo("ProfilePage");
        }

        [RelayCommand]
        private void OpenExit()
        {
            _windowManager.ExitAuthWindow();
        }

        [RelayCommand]
        private void OpenUserPage()
        {
            CurrentPage = _pagesManager.NavigateTo("UserPage");
        }
    }
}
