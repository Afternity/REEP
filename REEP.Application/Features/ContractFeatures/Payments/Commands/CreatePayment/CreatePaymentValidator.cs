using FluentValidation;

namespace REEP.Application.Features.ContractFeatures.Payments.Commands.CreatePayment
{
    public class CreatePaymentValidator
        : AbstractValidator<CreatePaymentCommand>
    {
        public CreatePaymentValidator()
        {
            RuleFor(command => command.Price)
                .NotEmpty()
                .PrecisionScale(18, 2, false);
            RuleFor(command => command.FirstPay)
                .NotEmpty();
            RuleFor(command => command.PeriodPay)
                .NotEmpty();
            RuleFor(command => command.LastPay)
                .NotEmpty()
                .GreaterThan(command => command.FirstPay)
                .WithMessage("EndedAt должен быть больше StartedAt");
            RuleFor(command => command.IsDeleted)
                .NotNull();
            RuleFor(command => command.Type)
                .NotEmpty()
                .MaximumLength(50);
        }
    }
}
