namespace REEP.Application.Features.UserFeatures.UserTypeFeatures.UserTypes.Queries.GetUserTypeList
{
    public class UserTypeListVm
    {
        public ICollection<UserTypeLookupDto> UserTypes { get; set; } = [];
    }
}
