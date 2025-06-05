using FluentValidation;

namespace REEP.Application.Features.ContractFeatures.Contracts.Commands.UpdateContract
{
    public class UpdateContractValidator
        : AbstractValidator<UpdateContractCommand>
    {
        public UpdateContractValidator()
        {
            RuleFor(createContractCommand => createContractCommand.Id)
                .NotEqual(Guid.Empty);
            RuleFor(createContractCommand => createContractCommand.Name)
                .NotEmpty().MaximumLength(50);
            RuleFor(createContractCommand => createContractCommand.Description)
                .NotEmpty().MaximumLength(50);
            RuleFor(createContractCommand => createContractCommand.StartedAt)
                .NotEmpty();
            RuleFor(createContractCommand => createContractCommand.EndedAt)
                .NotEmpty()
                .GreaterThan(createContractCommand => createContractCommand.StartedAt)
                .WithMessage("EndedAt должен быть больше StartedAt");
            RuleFor(createContractCommand => createContractCommand.Type)
                .NotEmpty()
                .MaximumLength(50);
        }
    }
}
