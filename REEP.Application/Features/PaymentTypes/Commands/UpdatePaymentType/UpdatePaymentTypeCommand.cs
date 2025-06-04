using MediatR;

namespace REEP.Application.Features.PaymentTypes.Commands.UpdatePaymentType
{
    public class UpdatePaymentTypeCommand : IRequest<Unit>
    {
        public Guid Id { get; set; }
        public string Type { get; set; } = null!;
    }
}
