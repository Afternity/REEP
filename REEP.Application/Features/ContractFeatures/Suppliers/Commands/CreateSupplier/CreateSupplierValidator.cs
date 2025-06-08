using FluentValidation;

namespace REEP.Application.Features.ContractFeatures.Suppliers.Commands.CreateSupplier
{
    public class CreateSupplierValidator
        : AbstractValidator<CreateSupplierCommand>
    {
        public CreateSupplierValidator()
        {
            RuleFor(command => command.FirstName)
                .MaximumLength(50);
            RuleFor(command => command.SecondName)
                .MaximumLength(50);
            RuleFor(command => command.LastName)
                .MaximumLength(50);
            RuleFor(command => command.OtherName)
                .MaximumLength(100);
            RuleFor(command => command.Number)
                .MaximumLength(50);
            RuleFor(command => command.Email)
                .MaximumLength(50);
            RuleFor(command => command.OtherContacts)
                .MaximumLength(100);
            RuleFor(command => command.IsDeleted)
                .NotNull();
            RuleFor(command => command.Type)
                .NotEmpty()
                .MaximumLength(50);
        }
    }
}
