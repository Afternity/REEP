using FluentValidation;

namespace REEP.Application.Features.PaymentTypes.Commands.SoftDeletePaymetType
{
    public class SoftDeletePaymentTypeValidator 
        : AbstractValidator<SoftDeletePaymentTypeCommand>
    {
        public SoftDeletePaymentTypeValidator()
        {
            RuleFor(softDeletePaymentTypeValidator => softDeletePaymentTypeValidator.Id).NotEqual(Guid.Empty);
            RuleFor(softDeletePaymentTypeCommand => softDeletePaymentTypeCommand.IsDeleted).NotNull();
        }
    }
}
