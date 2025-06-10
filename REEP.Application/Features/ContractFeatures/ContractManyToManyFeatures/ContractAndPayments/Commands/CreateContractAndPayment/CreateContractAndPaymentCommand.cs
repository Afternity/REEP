using MediatR;

namespace REEP.Application.Features.ContractFeatures.ContractManyToManyFeatures.ContractAndPayments.Commands.CreateContractAndPayment
{
    public class CreateContractAndPaymentCommand
        : IRequest<Unit>
    {
        public Guid ContractId { get; set; }
        public Guid PaymentId { get; set; }
        public bool IsActive { get; set; } = true;
        public bool IsDeleted { get; set; } = false;
    }
}
