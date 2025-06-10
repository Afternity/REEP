using FluentValidation;

namespace REEP.Application.Features.ContractFeatures.ContractManyToManyFeatures.ContractAndPayments.Commands.CreateContractAndPayment
{
    public class CreateContractAndPaymentValidator
        : AbstractValidator<CreateContractAndPaymentCommand>
    {
        public CreateContractAndPaymentValidator()
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
