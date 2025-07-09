namespace REEP.Application.Features.WarrantyFeatures.Warranties.Queries.GetWarrantyList
{
    public class WarrantyListVm
    {
        public ICollection<WarrantyLookupDto> Warranties { get; set; } = [];
    }
}
