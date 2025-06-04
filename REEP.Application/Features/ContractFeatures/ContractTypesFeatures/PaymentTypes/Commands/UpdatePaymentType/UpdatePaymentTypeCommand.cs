using MediatR;

namespace REEP.Application.Features.ContractFeatures.ContractTypesFeatures.PaymentTypes.Commands.UpdatePaymentType
{
    public class UpdatePaymentTypeCommand : IRequest<Unit>
    {
        public Guid Id { get; set; }
        public string Type { get; set; } = null!;
    }
}
