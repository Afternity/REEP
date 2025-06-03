using REEP.WPF_Client.Common.ApiInterfaces;
using REEP.WPF_Client.Models.ContractType.CommandDto;
using REEP.WPF_Client.Models.ContractType.QueryVm.DetailsVm;
using REEP.WPF_Client.Models.ContractType.QueryVm.ListVm;
using System.Net.Http;
using System.Net.Http.Json;

namespace REEP.WPF_Client.Services.ApiServices
{
    public class ContractTypeService : IContractTypeApi
    {
        private readonly HttpClient _client;
        public ContractTypeService(IHttpClientFactory httpClientFactory) =>
            _client = httpClientFactory.CreateClient("ApiClient");

        public async Task<Guid> CreateContractType(CreateContractTypeDto createDto)
        {
            var response = await _client.PostAsJsonAsync("", createDto);
            return await response.Content.ReadFromJsonAsync<Guid>();
        }

        public async Task UpdateContractType(UpdateContractTypeDto updateDto)
        {
            await _client.PutAsJsonAsync("", updateDto);
        }

        public async Task SoftDeleteContractType(SoftDeleteContractTypeDto softDeleteDto)
        {
            await _client.PutAsJsonAsync("", softDeleteDto);
        }

        public async Task HardDeleteContractType(Guid id)
        {
            await _client.DeleteAsync($"{id}");
        }

        public async Task<ContractTypeDetailsVm> GetContractType(Guid id)
        {
            return await _client.GetFromJsonAsync<ContractTypeDetailsVm>($"{id}");
        }

        public async Task<ContractTypeListVm> GetContractTypes(bool isDeleted = false)
        {
            return await _client.GetFromJsonAsync<ContractTypeListVm>($"?isDeleted={isDeleted}");
        }

    }
}
