using Refit;
using REEP.WPF_Client.Backend.Models.MaintenanceModels.TaskFromUserModels;
using REEP.WPF_Client.Backend.Services.IApiServices.IMaintenanceApiServices.TaskFromUserApiServices;

namespace REEP.WPF_Client.Backend.Services.ApiServices.MaintenanceApiServices.TaskFromUser
{
    public class TaskFromUserService : ITaskFromUserService
    {
        private readonly ITaskFromUserApi _tastFromUserApi;

        public TaskFromUserService(ITaskFromUserApi tastFromUserApi)
        {
            _tastFromUserApi = tastFromUserApi;
        }

        public async Task<bool> CreateMaintenanceRequset([Body] CreateMaintenanceRequestDto request)
        {
            try
            {
                await _tastFromUserApi.CreateMaintenanceRequset(request);
                return true;
            }
            catch (ApiException)
            {
                return false;
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}
