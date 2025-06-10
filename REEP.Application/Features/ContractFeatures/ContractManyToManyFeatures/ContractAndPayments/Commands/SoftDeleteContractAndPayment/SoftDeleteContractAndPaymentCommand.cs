using MediatR;

namespace REEP.Application.Features.ContractFeatures.ContractManyToManyFeatures.ContractAndPayments.Commands.SoftDeleteContractAndPayment
{
    public class SoftDeleteContractAndPaymentCommand
        : IRequest<Unit>
    {
        public Guid ContractId { get; set; }
        public Guid PaymentId { get; set; }
        public bool IsDeleted { get; set; } = false;
    }
}
