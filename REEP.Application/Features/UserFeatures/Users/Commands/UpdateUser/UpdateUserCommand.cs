using MediatR;

namespace REEP.Application.Features.UserFeatures.Users.Commands.UpdateUser
{
    public class UpdateUserCommand
        : IRequest<Unit>
    {
        public Guid Id { get; set; }
        public string FirstName { get; set; } = null!;
        public string SecondName { get; set; } = null!;
        public string? LastName { get; set; }
        public string Email { get; set; } = null!;
        public string? OtherContacts { get; set; }
        public string Password { get; set; } = null!;
        public string Type { get; set; } = null!;
    }
}
