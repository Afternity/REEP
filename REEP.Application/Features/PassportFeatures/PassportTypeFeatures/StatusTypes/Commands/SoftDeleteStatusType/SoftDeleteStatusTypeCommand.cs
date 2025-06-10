using MediatR;

namespace REEP.Application.Features.StatusFeatures.StatusTypeFeatures.StatusTypes.Commands.SoftDeleteStatusType
{
    public class SoftDeleteUserTypeCommand : IRequest<Unit>
    {
        public Guid Id { get; set; }
        public bool IsDeleted { get; set; } = true;
    }
}
