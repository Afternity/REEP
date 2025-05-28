using REEP.Domain.Models.ContractModels.ContractTypeModels;

namespace REEP.Application.Interfaces.InterfaceRepositories
{
    public interface IContractTypeRepository
    {
        Task<ContractType> GetByIdAsync(Guid id, CancellationToken cancellationToken);
        Task CreateAsync(ContractType contractType, CancellationToken cancellationToken);
        Task UpdateAsync(ContractType contractType);
        Task DeleteAsync(ContractType contractType);
    }
}
