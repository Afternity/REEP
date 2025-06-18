using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using REEP.WPF_Client.Backend.Models.MaintenanceModels.TaskFromUserModels;
using REEP.WPF_Client.Backend.Services.IApiServices.IMaintenanceApiServices.TaskFromUserApiServices;
using System.Windows;

namespace REEP.WPF_Client.Frontend.ViewModels.MaintenanceViewModels.TaskFromUser
{
    public partial class CreateMaintenanceRequestViewModel : ObservableObject
    {
        private readonly ITaskFromUserService _taskFromUserService;

        [ObservableProperty]
        private string _description;
        public CreateMaintenanceRequestViewModel(
            ITaskFromUserService taskFromUserService)
        {
            _taskFromUserService = taskFromUserService;
        }

        [RelayCommand]
        private async Task PushAsync()
        {
            try
            {
                if (string.IsNullOrWhiteSpace(Description)) return;

                var createMaintenanceRequestDto = new CreateMaintenanceRequestDto()
                {
                    Description = Description,
                    CreateByUserId = App.CurrentUser.Id
                };

                bool success = await _taskFromUserService.CreateMaintenanceRequset(createMaintenanceRequestDto);

                if (success)
                {
                    MessageBox.Show("Запись отправлена",
                        "Успех", MessageBoxButton.OK, MessageBoxImage.Information);
                }
                else
                {
                    MessageBox.Show("Запись не отправлена",
                        "Успех", MessageBoxButton.OK, MessageBoxImage.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка отправления сообщения о неисправности: {ex.Message}",
                                    "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
            }
           
        }
    }
}
