using FluentValidation;

namespace REEP.Application.Features.ContractFeatures.Payments.Commands.HardDeletePayment
{
    public class HardDeletePaymentValidator
        : AbstractValidator<HardDeletePaymentCommand>
    {
        public HardDeletePaymentValidator()
        {
            RuleFor(command => command.Id)
                .NotEqual(Guid.Empty);
        }
    }
}
