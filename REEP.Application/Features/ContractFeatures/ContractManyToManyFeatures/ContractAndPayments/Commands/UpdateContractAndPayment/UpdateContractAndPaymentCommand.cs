using MediatR;

namespace REEP.Application.Features.ContractFeatures.ContractManyToManyFeatures.ContractAndPayments.Commands.UpdateContractAndPayment
{
    public class UpdateContractAndPaymentCommand
        : IRequest<Unit>
    {
        public Guid ContractId { get; set; }
        public Guid PaymentId { get; set; }
        public bool IsActive { get; set; } = false;
    }
}
