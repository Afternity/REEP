using MediatR;

namespace REEP.Application.Features.ContractFeatures.ContractManyToManyFeatures.ContractAndPayments.Queries.GetContractAndPaymentDetails
{
    public class GetContractAndPaymentDetailsQuery
        : IRequest<ContractAndPaymentDetailsVm>
    {
        public Guid ContractId { get; set; }
        public Guid PaymentId { get; set; }
    }
}
