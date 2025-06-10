using FluentValidation;

namespace REEP.Application.Features.ContractFeatures.ContractManyToManyFeatures.ContractAndPayments.Commands.HardDeleteContractsAndPayments
{
    public class HardDeleteContractsAndPaymentsValidator
        : AbstractValidator<HardDeleteContractsAndPaymentsCommand>
    {
        public HardDeleteContractsAndPaymentsValidator()
        {
            RuleFor(command => command.ContractId)
                .NotEqual(Guid.Empty);
            RuleFor(command => command.PaymentId)
                .NotEqual(Guid.Empty);
        }
    }
}
