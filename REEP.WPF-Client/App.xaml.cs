using Microsoft.Extensions.DependencyInjection;
using REEP.WPF_Client.Backend.Models.UserModels.AuthModels;
using REEP.WPF_Client.Backend.Services.ApiServices.MaintenanceApiServices.TaskFromUser;
using REEP.WPF_Client.Backend.Services.ApiServices.UserApiServices;
using REEP.WPF_Client.Backend.Services.ApiServices.UserApiServices.AuthServices;
using REEP.WPF_Client.Backend.Services.IApiServices.IMaintenanceApiServices.TaskFromUserApiServices;
using REEP.WPF_Client.Backend.Services.IApiServices.IUserApiServices;
using REEP.WPF_Client.Backend.Services.IApiServices.IUserApiServices.IAuthApiServices;
using REEP.WPF_Client.Frontend.Common.ViewManagers;
using REEP.WPF_Client.Frontend.ViewModels.AuthViewModels;
using REEP.WPF_Client.Frontend.ViewModels.CommonViewModels;
using REEP.WPF_Client.Frontend.ViewModels.ContractViewModels;
using REEP.WPF_Client.Frontend.ViewModels.MaintenanceViewModels.TaskFromUser;
using REEP.WPF_Client.Frontend.ViewModels.UserViewModels;
using REEP.WPF_Client.Frontend.Views.AuthViews;
using REEP.WPF_Client.Frontend.Views.CommonViews;
using REEP.WPF_Client.Frontend.Views.ContractViews;
using REEP.WPF_Client.Frontend.Views.MaintenanceVeiws.TaskFromUser;
using REEP.WPF_Client.Frontend.Views.UserViews;
using Refit;
using System.Net.Http.Headers;
using System.Windows;


namespace REEP.WPF_Client
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        public static IServiceProvider ServiceProvider { get; private set; }
        public static UserFromAuthDetailsVm CurrentUser { get; set; }
        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);

            var services = new ServiceCollection();
            ConfigureServices(services);
            ServiceProvider = services.BuildServiceProvider();

            //CurrentUser = new UserFromAuthDetailsVm()
            //{
            //    Id = Guid.NewGuid(),
            //    SecondName = "asdfas",
            //    FirstName = "asdfa",
            //    LastName = "asdfasdf",
            //    Password = "12345",
            //    CreatedAt = DateTime.Now,
            //    IsDeleted = false,
            //    Type = "Сотрудник"
            //};

            //var testWindow = ServiceProvider.GetRequiredService<CommonWindowView>();
            //testWindow.DataContext = ServiceProvider.GetRequiredService<CommonViewModel>();
            //testWindow.Show();
            var authWindow = ServiceProvider.GetRequiredService<AuthWindowView>();
            authWindow.DataContext = ServiceProvider.GetRequiredService<AuthViewModel>();
            authWindow.Show();
        }

        private void ConfigureServices(IServiceCollection services)
        {
            // Настройка Refit для IAuthApi
            services.AddRefitClient<IAuthApi>()
                .ConfigureHttpClient(c =>
                {
                    c.BaseAddress = new Uri("https://localhost:7110");
                    c.DefaultRequestHeaders.Accept.Add(
                        new MediaTypeWithQualityHeaderValue("application/json"));
                });

            // Настройка Refit для IUserApi
            services.AddRefitClient<IUserApi>()
                .ConfigureHttpClient(c =>
                {
                    c.BaseAddress = new Uri("https://localhost:7110");
                    c.DefaultRequestHeaders.Accept.Add(
                        new MediaTypeWithQualityHeaderValue("application/json"));
                });

            // Настройка Refit для ITaskFromUserApi
            services.AddRefitClient<ITaskFromUserApi>()
                .ConfigureHttpClient(c =>
                {
                    c.BaseAddress = new Uri("https://localhost:7110");
                    c.DefaultRequestHeaders.Accept.Add(
                        new MediaTypeWithQualityHeaderValue("application/json"));
                });

            // Регистрация сервисов
            services.AddTransient<IAuthService, AuthService>();
            services.AddSingleton<IUserService, UserService>();
            services.AddSingleton<ITaskFromUserService, TaskFromUserService>();
            services.AddSingleton<WindowsManager>();
            services.AddSingleton<PagesManager>();

            // Регистрация ViewModels
            services.AddTransient<AuthViewModel>();
            services.AddTransient<RegisterViewModel>();

            services.AddTransient<CommonViewModel>();
            services.AddTransient<HomeViewModel>();
            services.AddTransient<ProfileViewModel>()
                ;
            services.AddTransient<ContractViewModel>();
            services.AddTransient<UserViewModel>();
            services.AddTransient<CreateUserViewModel>();
            services.AddTransient<Func<Guid, UpdateUserViewModel>>(provider =>
                userId => new UpdateUserViewModel(
                    provider.GetRequiredService<IUserService>(),
                    provider.GetRequiredService<WindowsManager>(),
                    userId)
                );
            services.AddTransient<Func<Guid, SoftDeleteUserViewModel>>(provider =>
                userId => new SoftDeleteUserViewModel(
                    provider.GetRequiredService<IUserService>(),
                    provider.GetRequiredService<WindowsManager>(),
                    userId)
                );
            services.AddTransient<CreateMaintenanceRequestViewModel>();

            // Регистрация Views
            // windows
            services.AddTransient<AuthWindowView>();
            services.AddTransient<RegisterWindowView>();

            services.AddTransient<CommonWindowView>();

            services.AddTransient<CreateUserWindowView>();
            services.AddTransient<UpdateUserWindowView>();
            services.AddTransient<SoftDeleteUserWindowView>();
            // pages
            services.AddTransient<HomePageView>();
            services.AddTransient<ProfilePageView>();

            services.AddTransient<ContractPageView>();
            services.AddTransient<UserPageView>();
            services.AddTransient<CreateMaintenanceRequestPageView>(); // для сотрудника
        }
    }
}
