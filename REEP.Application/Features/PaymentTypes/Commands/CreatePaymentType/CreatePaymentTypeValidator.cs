using FluentValidation;
using System.Data;

namespace REEP.Application.Features.PaymentTypes.Commands.CreatePaymentType
{
    public class CreatePaymentTypeValidator
        : AbstractValidator<CreatePaymentTypeCommand>
    {
        public CreatePaymentTypeValidator()
        {
            RuleFor(createPaymentTypeCommand => createPaymentTypeCommand.Type).NotEmpty().MaximumLength(50);
            RuleFor(createPaymentTypeCommand => createPaymentTypeCommand.IsDeleted).NotNull();
        }
    }
}
