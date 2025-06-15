using MediatR;

namespace REEP.Application.Features.UserFeatures.UserTypeFeatures.UserTypes.Queries.GetUserTypeByTypeDetails
{
    public class GetUserTypeByTypeDetailsQuery
        : IRequest<UserTypeByTypeDetailsVm>
    {
        public string Type { get; set; } = null!;
    }
}
