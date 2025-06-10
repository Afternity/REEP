using FluentValidation;

namespace REEP.Application.Features.ContractFeatures.ContractManyToManyFeatures.ContractAndPayments.Commands.SoftDeleteContractsAndPayments
{
    public class SoftDeleteContractsAndPaymentsValidator
        : AbstractValidator<SoftDeleteContractsAndPaymentsCommand>
    {
        public SoftDeleteContractsAndPaymentsValidator()
        {
            RuleFor(command => command.ContractId)
              .NotEqual(Guid.Empty);
            RuleFor(command => command.PaymentId)
                .NotEqual(Guid.Empty);
            RuleFor(command => command.IsDeleted)
                .NotNull();
        }
    }
}
