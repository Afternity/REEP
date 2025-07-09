using FluentValidation;

namespace REEP.Application.Features.WarrantyFeatures.Warranties.Commands.CreateWarrantyByType
{
    public class CreateWarrantyByTypeValidator
         : AbstractValidator<CreateWarrantyByTypeCommand>
    {
        public CreateWarrantyByTypeValidator()
        {
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
            RuleFor(command => command.IsDeleted)
                .NotNull();
            RuleFor(command => command.ContractId)
                .NotEqual(Guid.Empty);
            RuleFor(command => command.WarrantyType)
                .NotEmpty().
                MaximumLength(50);
        }
    }
}
