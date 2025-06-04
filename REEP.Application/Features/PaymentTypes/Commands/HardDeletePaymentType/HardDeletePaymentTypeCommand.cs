using MediatR;

namespace REEP.Application.Features.PaymentTypes.Commands.HardDeletePaymentType
{
    public class HardDeletePaymentTypeCommand : IRequest<Unit>
    {
        public Guid Id { get; set; }
    }
}
