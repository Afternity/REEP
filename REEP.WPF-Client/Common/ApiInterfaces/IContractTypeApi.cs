using REEP.WPF_Client.Models.ContractType.CommandDto;
using REEP.WPF_Client.Models.ContractType.QueryVm.DetailsVm;
using REEP.WPF_Client.Models.ContractType.QueryVm.ListVm;
using Refit;

namespace REEP.WPF_Client.Common.ApiInterfaces
{
    public interface IContractTypeApi
    {
        public interface IContractTypeApi
        {
            [Get("/ContractType/get/{id}")]
            Task<ContractTypeDetailsVm> GetContractType(Guid id);

            [Get("/ContractType/get-All")]
            Task<ContractTypeListVm> GetContractTypes(bool isDeleted = false);

            [Post("/ContractType")]
            Task<Guid> CreateContractType(CreateContractTypeDto createDto);

            [Put("/ContractType/update")]
            Task UpdateContractType(UpdateContractTypeDto updateDto);

            [Delete("/ContractType/hard-delete/{id}")]
            Task HardDeleteContractType(Guid id);

            [Put("/ContractType/soft-delete/{id}")]
            Task SoftDeleteContractType(SoftDeleteContractTypeDto softDeleteDto);
        }
    }
}
