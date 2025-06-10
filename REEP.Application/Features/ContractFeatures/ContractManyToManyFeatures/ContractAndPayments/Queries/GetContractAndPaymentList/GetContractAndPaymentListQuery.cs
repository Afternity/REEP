using MediatR;

namespace REEP.Application.Features.ContractFeatures.ContractManyToManyFeatures.ContractAndPayments.Queries.GetContractAndPaymentList
{
    public class GetContractAndPaymentListQuery
        : IRequest<ContractAndPaymentListVm>
    {
        public bool IsDeleted { get; set; } = false;
    }
}
