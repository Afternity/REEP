using MediatR;

namespace REEP.Application.Features.ContractFeatures.ContractManyToManyFeatures.ContractAndPayments.Queries.GetContractsAndPaymentsDetails
{
    public class GetContractsAndPaymentsDetailsQuery
        : IRequest<ContractsAndPaymentsDetailsVm>
    {
        public Guid ContractId { get; set; }
        public Guid PaymentId { get; set; }
    }
}
