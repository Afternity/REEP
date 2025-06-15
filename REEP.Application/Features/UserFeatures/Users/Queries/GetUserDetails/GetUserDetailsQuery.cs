using MediatR;

namespace REEP.Application.Features.UserFeatures.Users.Queries.GetUserDetails
{
    public class GetUserDetailsQuery
        : IRequest<UserDetailsVm>
    {
        public Guid Id { get; set; }
    }
}
