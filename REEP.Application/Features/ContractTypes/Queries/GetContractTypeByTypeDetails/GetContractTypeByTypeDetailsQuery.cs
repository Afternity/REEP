using MediatR;

namespace REEP.Application.Features.ContractTypes.Queries.GetContractTypeByTypeDetails
{
    public class GetContractTypeByTypeDetailsQuery : IRequest<ContractTypeByTypeDetailsVm>
    {
        public string Type { get; set; } = null!;
    }
}
