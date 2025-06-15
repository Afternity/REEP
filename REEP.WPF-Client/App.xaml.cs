using Microsoft.Extensions.DependencyInjection;
using REEP.WPF_Client.Frontend.Views.AuthViews;
using REEP.WPF_Client.Backend.Services.AuthServisec;
using System.Net.Http.Headers;
using System.Windows;
using REEP.WPF_Client.Frontend.ViewModels.AuthViewModels;


namespace REEP.WPF_Client
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        public static IServiceProvider ServiceProvider { get; private set; }
        public static string CurrentUsername { get; set; } // Храним имя пользователя

        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);

            var services = new ServiceCollection();
            ConfigureServices(services);
            ServiceProvider = services.BuildServiceProvider();

            // Показываем окно входа
            var loginWindow = ServiceProvider.GetRequiredService<AuthWindowView>();
            loginWindow.DataContext = ServiceProvider.GetRequiredService<AuthWindowView>();
            loginWindow.Show();
        }

        private void ConfigureServices(IServiceCollection services)
        {
            // Настройка HttpClient
            services.AddHttpClient("ApiClient", client =>
            {
                client.BaseAddress = new Uri("https://localhost:7110/");
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(
                    new MediaTypeWithQualityHeaderValue("application/json"));
            });

            // Регистрация services
            services.AddTransient<IAuthService, AuthService>();
            services.AddTransient<IApiService, ApiService>();

            // Регистрация views
            services.AddTransient<AuthWindowView>();

            // Регистрация viewModels
            services.AddTransient<AuthViewModel>();
        }
    }
}
