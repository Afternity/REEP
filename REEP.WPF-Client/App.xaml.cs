using Microsoft.Extensions.DependencyInjection;
using REEP.WPF_Client.Backend.Services.AuthServisec;
using REEP.WPF_Client.Backend.Services.IApiServices.IAuthApiServices;
using REEP.WPF_Client.Frontend.Common.ViewManagers.WindowManages;
using REEP.WPF_Client.Frontend.ViewModels.AuthViewModels;
using REEP.WPF_Client.Frontend.Views.AuthViews;
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

        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);

            var services = new ServiceCollection();
            ConfigureServices(services);
            ServiceProvider = services.BuildServiceProvider();

            var authWindow = ServiceProvider.GetRequiredService<AuthWindowView>();
            authWindow.DataContext = ServiceProvider.GetRequiredService<AuthViewModel>();
            authWindow.Show();
        }

        private void ConfigureServices(IServiceCollection services)
        {
            // Настройка Refit
            services.AddRefitClient<IAuthApi>()
                .ConfigureHttpClient(c =>
                {
                    c.BaseAddress = new Uri("https://localhost:7110");
                    c.DefaultRequestHeaders.Accept.Add(
                        new MediaTypeWithQualityHeaderValue("application/json"));
                });

            // Регистрация сервисов
            services.AddTransient<IAuthService, AuthService>();
            services.AddSingleton<WindowManager>();

            // Регистрация ViewModels
            services.AddTransient<AuthViewModel>();
            services.AddTransient<RegisterViewModel>();

            // Регистрация Views
            services.AddTransient<AuthWindowView>();
            services.AddTransient<RegisterWindowView>();
        }
    }
}
