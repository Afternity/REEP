using REEP.WPF_Client.Common.ApiInterfaces;
using REEP.WPF_Client.Services.ApiServices;
using REEP.WPF_Client.Services.InfractructureServices;
using REEP.WPF_Client.ViewModels;
using REEP.WPF_Client.Views.Client.Admin;
using REEP.WPF_Client.Views.Infractructure;
using System.Windows;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;


namespace REEP.WPF_Client
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        protected override void OnStartup(StartupEventArgs e)
        {
            try
            {
                ServiceCollection services = new ServiceCollection();

                services.AddHttpClient("ApiClient", client =>
                {
                    client.BaseAddress = new Uri("https://localhost:7110/api/");
                    client.DefaultRequestHeaders.Add("Accept", "application/json");
                });

                services.AddTransient<IContractTypeApi, ContractTypeService>();

                services.AddSingleton<StartupMenuAdminService>();
                services.AddSingleton<StartupMenuUserService>();

                services.AddTransient<ContractTypeViewModel>();
                services.AddTransient<StartupMenuAdminView>();
                services.AddTransient<StartupMenuUserView>();

                services.AddTransient<ContractTypeView>();

                services.AddLogging(configure => configure.AddDebug());

                var builder = services.BuildServiceProvider();

                var view = builder.GetRequiredService<ContractTypeView>();
                view.DataContext = builder.GetRequiredService<ContractTypeViewModel>();
                view.Show();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Failed to start application: {ex.Message}", "Error",
                     MessageBoxButton.OK, MessageBoxImage.Error);
                Shutdown();
            }
        }
    }

}
