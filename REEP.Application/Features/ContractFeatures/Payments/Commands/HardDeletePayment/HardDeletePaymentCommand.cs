using MediatR;

namespace REEP.Application.Features.ContractFeatures.Payments.Commands.HardDeletePayment
{
    public class HardDeletePaymentCommand : IRequest<Unit>
    {
        public Guid Id { get; set; }
    }
}
