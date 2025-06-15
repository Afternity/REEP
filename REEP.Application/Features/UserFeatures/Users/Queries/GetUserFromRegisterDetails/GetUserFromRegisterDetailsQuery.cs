using MediatR;

namespace REEP.Application.Features.UserFeatures.Users.Queries.GetUserFromRegisterDetails
{
    public class GetUserFromRegisterDetailsQuery
        : IRequest<UserFromRegisterDetailsVm>
    {
        public string Email { get; set; } = null!;
        public string Password { get; set; } = null!;
    }
}
