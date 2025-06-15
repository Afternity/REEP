using MediatR;

namespace REEP.Application.Features.UserFeatures.Users.Commands.HardDeleteUser
{
    public class HardDeleteUserCommand
        : IRequest<Unit>
    {
        public Guid Id { get; set; }
    }
}
