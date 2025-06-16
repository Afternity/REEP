using MediatR;

namespace REEP.Application.Features.UserFeatures.Users.Queries.GetUserFromAuthDetails
{
    public class GetUserFromAuthDetailsQuery
        : IRequest<UserFromAuthDetailsVm>
    {
        public string Email { get; set; } = null!;
        public string Password { get; set; } = null!;
    }
}
