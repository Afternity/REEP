using AutoMapper;
using REEP.Application.Common.Mappings;

namespace REEP.Application.Features.StatusFeatures.StatusTypeFeatures.StatusTypes.Commands.UpdateStatusType
{
    public class UpdateUserTypeDto : IMapWith<UpdateUserTypeCommand>
    {
        public Guid Id { get; set; }
        public string Type { get; set; } = null!;

        public void Mapping(Profile profile)
        {
            profile.CreateMap<UpdateUserTypeDto, UpdateUserTypeCommand>();
        }
    }
}
