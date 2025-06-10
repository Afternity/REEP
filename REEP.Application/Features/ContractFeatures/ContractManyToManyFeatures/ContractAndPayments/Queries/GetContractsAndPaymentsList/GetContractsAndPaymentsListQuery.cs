using MediatR;

namespace REEP.Application.Features.ContractFeatures.ContractManyToManyFeatures.ContractAndPayments.Queries.GetContractsAndPaymentsList
{
    public class GetContractsAndPaymentsListQuery
        : IRequest<ContractsAndPaymentsListVm>
    {
        public bool IsDeleted { get; set; } = false;
    }
}
