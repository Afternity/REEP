namespace REEP.Application.Features.UserFeatures.Users.Queries.GetUserList
{
    public class UserListVm
    {
        public ICollection<UserLookupDto> Users { get; set; } = [];
    }
}
