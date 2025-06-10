using AutoMapper;
using REEP.Application.Common.Mappings;

namespace REEP.Application.Features.WarrantyFeatures.WarrantyTypeFeatures.WarrantyTypes.Commands.SoftDeleteWarrantyType
{
    public class SoftDeleteEquipmentTypeDto : IMapWith<SoftDeleteEquipmentTypeCommand>
    {
        public Guid Id { get; set; }
        public bool IsDeleted { get; set; } = true;
        public void Mapping(Profile profile)
        {
            profile.CreateMap<SoftDeleteEquipmentTypeDto, SoftDeleteEquipmentTypeCommand>();
        }
    }
}
