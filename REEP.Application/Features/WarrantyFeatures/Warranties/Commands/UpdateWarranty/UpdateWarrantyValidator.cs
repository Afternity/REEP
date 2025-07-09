using FluentValidation;

namespace REEP.Application.Features.WarrantyFeatures.Warranties.Commands.UpdateWarranty
{
    public class UpdateWarrantyValidator
        : AbstractValidator<UpdateWarrantyCommand>
    {
        public UpdateWarrantyValidator()
        {
            RuleFor(command => command.Id)
                .NotEqual(Guid.Empty);
            RuleFor(command => command.Name)
               .NotEmpty()
               .MaximumLength(50);
            RuleFor(command => command.Description)
                .NotEmpty()
                .MaximumLength(150);
            RuleFor(command => command.StartedAt)
                .NotEmpty();
            RuleFor(command => command.EndedAt)
                .NotEmpty()
                .GreaterThan(command => command.StartedAt)
                .WithMessage("EndedAt должен быть больше StartedAt");
            RuleFor(command => command.ContractId)
                .NotEqual(Guid.Empty);
            RuleFor(command => command.WarrantyTypeId)
                .NotEqual(Guid.Empty);
        }
    }
}
