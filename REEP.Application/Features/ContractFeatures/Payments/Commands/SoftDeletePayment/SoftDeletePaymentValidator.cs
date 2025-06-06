using FluentValidation;

namespace REEP.Application.Features.ContractFeatures.Payments.Commands.SoftDeletePayment
{
    public class SoftDeletePaymentValidator 
        : AbstractValidator<SoftDeletePaymentCommand>
    {
        public SoftDeletePaymentValidator()
        {
            RuleFor(command => command.Id)
                .NotEqual(Guid.Empty);
            RuleFor(command => command.IsDeleted)
                .NotNull();
        }
    }
}
