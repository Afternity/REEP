

using MediatR;

namespace REEP.Application.Features.StatusFeatures.StatusTypesFeatures.StatusTypes.Queries.GetStatusTypeDetails
{
    public class GetUserTypeDetailsQuery : IRequest<UserTypeDetailsVm>
    {
        public Guid Id { get; set; }
    }
}
