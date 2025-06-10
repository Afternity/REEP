using FluentValidation;

namespace REEP.Application.Features.ContractFeatures.ContractManyToManyFeatures.ContractAndPayments.Commands.HardDeleteContractAndPayment
{
    public class HardDeleteContractAndPaymentValidator
        : AbstractValidator<HardDeleteContractAndPaymentCommand>
    {
        public HardDeleteContractAndPaymentValidator()
        {
            RuleFor(command => command.ContractId)
                .NotEqual(Guid.Empty);
            RuleFor(command => command.PaymentId)
                .NotEqual(Guid.Empty);
        }
    }
}
