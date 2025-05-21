namespace REEP.Domain.Models.WarrantyModels.WarrantyTypeModels
{
    public class WarrantyType
    {
        public Guid Id { get; set; }
        public string Type { get; set; } = string.Empty;
        public IList<Warranty> Warranties { get; set; } = [];
    }
}
