using FluentValidation;

namespace REEP.Application.Features.ContractFeatures.ContractTypesFeatures.PaymentTypes.Commands.UpdatePaymentType
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
