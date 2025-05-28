using MediatR;
using REEP.Application.Features.ContractTypes.Queries.GetContractTypesDetails;

namespace REEP.Application.Features.ContractTypes.Queries.GetContractTypesList
{
    public class GetContractTypesListQuery : IRequest<ContractTypeDetailsVm>
    {
        public bool IsDeleted { get; set; }
    }
}
