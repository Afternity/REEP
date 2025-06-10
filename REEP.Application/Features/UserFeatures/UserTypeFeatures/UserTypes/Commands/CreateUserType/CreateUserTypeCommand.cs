using MediatR;

namespace REEP.Application.Features.UserFeatures.UserTypeFeatures.UserTypes.Commands.CreateUserType
{
    public class CreateUserTypeCommand : IRequest<Guid>
    {
        public string Type { get; set; } = null!;
        public bool IsDeleted { get; set; } = false;
    }
}
