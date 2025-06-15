using FluentValidation;

namespace REEP.Application.Features.UserFeatures.Users.Commands.CreateUser
{
    public class CreateUserValidator
        : AbstractValidator<CreateUserCommand>
    {
        public CreateUserValidator()
        {
            RuleFor(command => command.FirstName)
                .MaximumLength(50)
                .NotEmpty();
            RuleFor(command => command.SecondName)
                .MaximumLength(50)
                .NotEmpty(); 
            RuleFor(command => command.LastName)
                .MaximumLength(50);
            RuleFor(command => command.Email)
                .MaximumLength(50)
                .NotEmpty();
            RuleFor(command => command.Password)
                .MaximumLength(100)
                .NotEmpty();
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
