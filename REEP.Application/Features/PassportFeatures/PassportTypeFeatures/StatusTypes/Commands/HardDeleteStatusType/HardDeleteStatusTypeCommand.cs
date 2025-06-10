using MediatR;

namespace REEP.Application.Features.StatusFeatures.StatusTypeFeatures.StatusTypes.Commands.HardDeleteStatusType
{
    public class HardDeleteUserTypeCommand : IRequest<Unit>
    {
        public Guid Id {  get; set; }
    }
}
