using MediatR;

namespace REEP.Application.Features.StatusFeatures.StatusTypesFeatures.StatusTypes.Queries.GetStatusTypeByTypeDetails
{
    public class GetUserTypeByTypeDetailsQuery : IRequest<UserTypeByTypeDetailsVm>
    {
        public string Type { get; set; } = null!;
    }
}
