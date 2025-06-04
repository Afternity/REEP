using MediatR;

namespace REEP.Application.Features.PaymentTypes.Commands.SoftDeletePaymetType
{
    public class SoftDeletePaymentTypeCommand : IRequest<Unit>
    {
        public Guid Id { get; set; }
        public bool IsDeleted { get; set; } = true;
    }
}
