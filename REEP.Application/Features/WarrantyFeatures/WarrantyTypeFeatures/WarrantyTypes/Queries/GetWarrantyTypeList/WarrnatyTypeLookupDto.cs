using AutoMapper;
using REEP.Application.Common.Mappings;
using REEP.Domain.Models.WarrantyModels.WarrantyTypeModels;

namespace REEP.Application.Features.WarrantyFeatures.WarrantyTypesFeatures.WarrantyTypes.Queries.GetWarrantyTypeList
{
    public class EquipmentTypeLookupDto : IMapWith<WarrantyType>
    {
        public Guid Id { get; set; }
        public string Type { get; set; } = null!;

        public void Mapping(Profile profile)
        {
            profile.CreateMap<WarrantyType, EquipmentTypeLookupDto>();
        }
    }
}
