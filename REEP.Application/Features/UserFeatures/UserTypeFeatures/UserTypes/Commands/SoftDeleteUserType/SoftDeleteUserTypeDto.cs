using AutoMapper;
using REEP.Application.Common.Mappings;

namespace REEP.Application.Features.UserFeatures.UserTypeFeatures.UserTypes.Commands.SoftDeleteUserType
{
    public class SoftDeleteUserTypeDto : IMapWith<SoftDeleteUserTypeCommand>
    {
        public Guid Id { get; set; }
        public bool IsDeleted { get; set; } = true;
        public void Mapping(Profile profile)
        {
            profile.CreateMap<SoftDeleteUserTypeDto, SoftDeleteUserTypeCommand>();
        }
    }
}
