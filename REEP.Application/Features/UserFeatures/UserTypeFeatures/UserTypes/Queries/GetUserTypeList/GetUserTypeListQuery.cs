using MediatR;

namespace REEP.Application.Features.UserFeatures.UserTypeFeatures.UserTypes.Queries.GetUserTypeList
{
    public class GetUserTypeListQuery
        : IRequest<UserTypeListVm>
    {
        public bool IsDeleted { get; set; } = false;
    }
}
