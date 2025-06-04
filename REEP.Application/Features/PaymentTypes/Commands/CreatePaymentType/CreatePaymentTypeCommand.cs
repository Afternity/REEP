using MediatR;

namespace REEP.Application.Features.PaymentTypes.Commands.CreatePaymentType
{
    public class CreatePaymentTypeCommand : IRequest<Guid>
    {
        public string Type { get; set; } = null!;
        public bool IsDeleted { get; set; } = false;
    }
}
