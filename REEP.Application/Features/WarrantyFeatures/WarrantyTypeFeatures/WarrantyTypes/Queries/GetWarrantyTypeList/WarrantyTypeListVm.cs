namespace REEP.Application.Features.WarrantyFeatures.WarrantyTypesFeatures.WarrantyTypes.Queries.GetWarrantyTypeList
{
    public class EquipmentTypeListVm
    {
        public ICollection<EquipmentTypeLookupDto> WarrantyTypes { get; set; } = [];
    }
}
