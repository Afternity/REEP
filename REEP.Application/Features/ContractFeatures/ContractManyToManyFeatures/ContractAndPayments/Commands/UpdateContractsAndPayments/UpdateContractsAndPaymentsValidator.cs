using FluentValidation;

namespace REEP.Application.Features.ContractFeatures.ContractManyToManyFeatures.ContractAndPayments.Commands.UpdateContractsAndPayments
{
    public class UpdateContractsAndPaymentsValidator
        : AbstractValidator<UpdateContractsAndPaymentsCommand>
    {
        public UpdateContractsAndPaymentsValidator()
        {
            RuleFor(command => command.ContractId)
             .NotEqual(Guid.Empty);
            RuleFor(command => command.PaymentId)
                .NotEqual(Guid.Empty);
            RuleFor(command => command.IsActive)
                .NotNull();
        }
    }
}
