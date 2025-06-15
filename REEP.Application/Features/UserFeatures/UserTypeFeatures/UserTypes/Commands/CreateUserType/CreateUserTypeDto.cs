using AutoMapper;
using REEP.Application.Common.Mappings;

namespace REEP.Application.Features.UserFeatures.UserTypeFeatures.UserTypes.Commands.CreateUserType
{
    public class CreateUserTypeDto
        : IMapWith<CreateUserTypeCommand>
    {
        public string Type { get; set; } = null!;
        public bool IsDeleted { get; set; } = false;

        public void Mapping(Profile profile)
        {
            profile.CreateMap<CreateUserTypeDto, CreateUserTypeCommand>();
        }
    }
}
