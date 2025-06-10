using MediatR;

namespace REEP.Application.Features.StatusFeatures.StatusTypesFeatures.StatusTypes.Queries.GetStatusTypeList
{
    public class GetUserTypeListQuery : IRequest<UserTypeListVm>
    {
        public bool IsDeleted { get; set; } = false;
    }
}
