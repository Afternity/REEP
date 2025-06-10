using MediatR;

namespace REEP.Application.Features.ContractFeatures.ContractManyToManyFeatures.ContractAndPayments.Commands.HardDeleteContractAndPayment
{
    public class HardDeleteContractAndPaymentCommand
        : IRequest<Unit>
    {
        public Guid ContractId { get; set; }
        public Guid PaymentId { get; set; }
    }
}
