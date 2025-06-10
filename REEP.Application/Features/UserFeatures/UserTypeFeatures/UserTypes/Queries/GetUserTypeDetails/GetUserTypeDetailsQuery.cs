using MediatR;

namespace REEP.Application.Features.UserFeatures.UserTypesFeatures.UserTypes.Queries.GetUserTypeDetails
{
    public class GetUserTypeDetailsQuery : IRequest<UserTypeDetailsVm>
    {
        public Guid Id { get; set; }
    }
}
