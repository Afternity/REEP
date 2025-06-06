using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace REEP.Application.Features.ContractFeatures.Payments.Commands.UpdatePayment
{
    public class UpdatePaymentValidator
        : AbstractValidator<UpdatePaymentCommand>
    {
        public UpdatePaymentValidator()
        {
            RuleFor(command => command.Id)
                .NotEqual(Guid.Empty);
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
            RuleFor(command => command.Type)
                .NotEmpty()
                .MaximumLength(50);
        }
    }
}
