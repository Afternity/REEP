using FluentValidation;

namespace REEP.Application.Features.ContractFeatures.ContractManyToManyFeatures.ContractAndPayments.Commands.SoftDeleteContractAndPayment
{
    public class SoftDeleteContractAndPaymentValidator
        : AbstractValidator<SoftDeleteContractAndPaymentCommand>
    {
        public SoftDeleteContractAndPaymentValidator()
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
