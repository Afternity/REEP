using AutoMapper;
using REEP.Application.Common.Mappings;

namespace REEP.Application.Features.WarrantyFeatures.WarrantyTypeFeatures.WarrantyTypes.Commands.CreateWarrantyType
{
    public class CreateEquipmentTypeDto : IMapWith<CreateEquipmentTypeCommand>
    {
        public string Type { get; set; } = null!;
        public bool IsDeleted { get; set; } 

        public void Mapping(Profile profile)
        {
            profile.CreateMap<CreateEquipmentTypeDto, CreateEquipmentTypeCommand>();
        }
    }
}
