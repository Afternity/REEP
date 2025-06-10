using FluentValidation;

namespace REEP.Application.Features.ContractFeatures.ContractManyToManyFeatures.ContractAndPayments.Commands.CreateContractsAndPayments
{
    public class CreateContractsAndPaymentsValidator
        : AbstractValidator<CreateContractsAndPaymentsCommand>
    {
        public CreateContractsAndPaymentsValidator()
        {
            RuleFor(command => command.ContractId)
                .NotEqual(Guid.Empty);
            RuleFor(command => command.PaymentId)
                .NotEqual(Guid.Empty);
            RuleFor(command => command.IsActive)
                .NotNull();
            RuleFor(command => command.IsDeleted)
                .NotNull();
        }
    }
}
