using MediatR;

namespace REEP.Application.Features.ContractFeatures.Payments.Commands.SoftDeletePayment
{
    public class SoftDeletePaymentCommand : IRequest<Unit>
    {
        public Guid Id { get; set; }
        public bool IsDeleted { get; set; } = true;
    }
}
