using AutoMapper;
using REEP.Application.Common.Mappings;
using REEP.Domain.Models.ContractModels.ContractTypeModels;

namespace REEP.Application.Features.WarrantyFeatures.WarrantyTypesFeatures.WarrantyTypes.Queries.GetWarrantyTypeByTypeDetails
{
    public class EquipmentTypeByTypeDetailsVm : IMapWith<SupplierType>
    {
        public string Type { get; set; } = null!;
        public DateTime CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public DateTime? DeletedAt { get; set; }
        public bool IsDeleted { get; set; } = false;

        public void Mapping(Profile profile)
        {
            profile.CreateMap<SupplierType, EquipmentTypeByTypeDetailsVm>();
        }
    }
}
