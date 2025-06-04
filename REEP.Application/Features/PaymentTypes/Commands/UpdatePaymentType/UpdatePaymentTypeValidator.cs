using FluentValidation;

namespace REEP.Application.Features.PaymentTypes.Commands.UpdatePaymentType
{
    public class UpdatePaymentTypeValidator
        : AbstractValidator<UpdatePaymentTypeCommand>
    {
        public UpdatePaymentTypeValidator()
        {
            RuleFor(updatePaymentTypeValidator => updatePaymentTypeValidator.Id).NotEqual(Guid.Empty);
            RuleFor(updatePaymentTypeValidator => updatePaymentTypeValidator.Type).NotEmpty().MaximumLength(50);
        }
    }
}
