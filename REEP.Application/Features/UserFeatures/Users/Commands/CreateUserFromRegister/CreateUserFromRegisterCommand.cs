using MediatR;

namespace REEP.Application.Features.UserFeatures.Users.Commands.CreateUserFromRegister
{
    public class CreateUserFromRegisterCommand
        : IRequest<Unit>
    {
        public string FirstName { get; set; } = null!;
        public string SecondName { get; set; } = null!;
        public string? LastName { get; set; }
        public string Email { get; set; } = null!;
        public string? OtherContacts { get; set; }
        public string Password { get; set; } = null!;
    }
}
