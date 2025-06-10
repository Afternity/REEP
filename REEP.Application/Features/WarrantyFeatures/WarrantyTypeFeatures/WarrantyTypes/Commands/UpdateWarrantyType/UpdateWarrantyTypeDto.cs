using AutoMapper;
using REEP.Application.Common.Mappings;

namespace REEP.Application.Features.WarrantyFeatures.WarrantyTypeFeatures.WarrantyTypes.Commands.UpdateWarrantyType
{
    public class UpdateEquipmentTypeDto : IMapWith<UpdateEquipmentTypeCommand>
    {
        public Guid Id { get; set; }
        public string Type { get; set; } = null!;

        public void Mapping(Profile profile)
        {
            profile.CreateMap<UpdateEquipmentTypeDto, UpdateEquipmentTypeCommand>();
        }
    }
}
