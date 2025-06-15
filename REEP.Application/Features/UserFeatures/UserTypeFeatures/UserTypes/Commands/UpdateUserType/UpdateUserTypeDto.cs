using AutoMapper;
using REEP.Application.Common.Mappings;

namespace REEP.Application.Features.UserFeatures.UserTypeFeatures.UserTypes.Commands.UpdateUserType
{public class UpdateUserTypeDto
        : IMapWith<UpdateUserTypeCommand>
    {
        public Guid Id { get; set; }
        public string Type { get; set; } = null!;

        public void Mapping(Profile profile)
        {
            profile.CreateMap<UpdateUserTypeDto, UpdateUserTypeCommand>();
        }
    }
}
