using MediatR;

namespace REEP.Application.Features.UserFeatures.Users.Commands.CreateUser
{
    internal class CreateUserCommand
        : IRequest<Guid>
    {
        public string FirstName { get; set; } = null!;
        public string SecondName { get; set; } = null!;
        public string? LastName { get; set; }
        public string Email { get; set; } = null!;
        public string? OtherContacts { get; set; }
        public string Password { get; set; } = null!;
        public DateTime CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public DateTime? DeletedAt { get; set; }
        public bool IsDeleted { get; set; } = false;
        public string UserType { get; set; } = null!;
    }
}
