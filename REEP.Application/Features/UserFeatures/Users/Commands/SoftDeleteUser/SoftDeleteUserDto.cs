using AutoMapper;
using REEP.Application.Common.Mappings;

namespace REEP.Application.Features.UserFeatures.Users.Commands.SoftDeleteUser
{
    public class SoftDeleteUserDto
        : IMapWith<SoftDeleteUserCommand>
    {
        public Guid Id { get; set; }
        public bool IsDeleted { get; set; } = true;

        public void Mapping(Profile profile)
        {
            profile.CreateMap<SoftDeleteUserDto, SoftDeleteUserCommand>();
        }
    }
}
