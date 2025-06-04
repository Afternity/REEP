using MediatR;

namespace REEP.Application.Features.ContractFeatures.ContractTypesFeatures.ContractTypes.Queries.GetContractTypeByTypeDetails
{
    public class GetContractTypeByTypeDetailsQuery : IRequest<ContractTypeByTypeDetailsVm>
    {
        public string Type { get; set; } = null!;
    }
}
