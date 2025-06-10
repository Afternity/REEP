using AutoMapper;
using REEP.Application.Common.Mappings;

namespace REEP.Application.Features.EquipmentFeatures.EquipmentTypeFeatures.EquipmentTypes.Commands.CreateEquipmentType
{
    public class CreateStatusTypeDto : IMapWith<CreateStatusTypeCommand>
    {
        public string Type { get; set; } = null!;
        public bool IsDeleted { get; set; } 

        public void Mapping(Profile profile)
        {
            profile.CreateMap<CreateStatusTypeDto, CreateStatusTypeCommand>();
        }
    }
}
