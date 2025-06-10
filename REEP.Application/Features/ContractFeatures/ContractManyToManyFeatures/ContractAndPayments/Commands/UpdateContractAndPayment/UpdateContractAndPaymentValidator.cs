using FluentValidation;

namespace REEP.Application.Features.ContractFeatures.ContractManyToManyFeatures.ContractAndPayments.Commands.UpdateContractAndPayment
{
    public class UpdateContractAndPaymentValidator
        : AbstractValidator<UpdateContractAndPaymentCommand>
    {
        public UpdateContractAndPaymentValidator()
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
