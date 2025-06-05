using MediatR;

namespace REEP.Application.Features.ContractFeatures.Contracts.Queries.GetContractList
{
    public class GetContractListCommand : IRequest<ContractListVm>
    {
        public bool IsDeleted { get; set; } = false;
    }
}
