using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace REEP.Application.Features.UserFeatures.Users.Commands.CreateUserFromRegister
{
    public class CreateUserFromRegisterValidator
        : AbstractValidator<CreateUserFromRegisterCommand>
    {
        public CreateUserFromRegisterValidator()
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
        }
    }
}
