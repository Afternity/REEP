using MediatR;

namespace REEP.Application.Features.UserFeatures.Users.Queries.GetUserList
{
    public class GetUserListQuery
        : IRequest<UserListVm>
    {
        public bool IsDeleted { get; set; } = false;
    }
}
