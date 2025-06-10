using MediatR;

namespace REEP.Application.Features.UserFeatures.UserTypeFeatures.UserTypes.Commands.HardDeleteUserType
{
    public class HardDeleteUserTypeCommand : IRequest<Unit>
    {
        public Guid Id {  get; set; }
    }
}
