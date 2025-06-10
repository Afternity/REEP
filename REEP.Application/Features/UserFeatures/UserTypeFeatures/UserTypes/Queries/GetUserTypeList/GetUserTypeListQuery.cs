using MediatR;

namespace REEP.Application.Features.UserFeatures.UserTypesFeatures.UserTypes.Queries.GetUserTypeList
{
    public class GetUserTypeListQuery : IRequest<UserTypeListVm>
    {
        public bool IsDeleted { get; set; } = false;
    }
}
