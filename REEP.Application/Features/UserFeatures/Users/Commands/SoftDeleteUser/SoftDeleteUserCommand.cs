using MediatR;

namespace REEP.Application.Features.UserFeatures.Users.Commands.SoftDeleteUser
{
    public class SoftDeleteUserCommand
        : IRequest<Unit>
    {
        public Guid Id { get; set; }
        public bool IsDeleted { get; set; } = true;
    }
}
