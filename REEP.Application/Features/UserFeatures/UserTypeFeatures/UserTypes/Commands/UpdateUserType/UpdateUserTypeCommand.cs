using MediatR;

namespace REEP.Application.Features.UserFeatures.UserTypeFeatures.UserTypes.Commands.UpdateUserType
{
    public class UpdateUserTypeCommand : IRequest<Unit>
    {
        public Guid Id { get; set; }
        public string Type { get; set; } = null!;
    }
}
