using MediatR;

namespace REEP.Application.Features.ContractFeatures.Contracts.Queries.GetContractDetails
{
    public class GetContractDetailsQuery : IRequest<ContractDetailsVm>
    {
        public Guid Id { get; set; }
    }
}
