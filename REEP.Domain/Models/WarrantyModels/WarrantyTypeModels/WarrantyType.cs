using REEP.Domain.InterfaceModels;

namespace REEP.Domain.Models.WarrantyModels.WarrantyTypeModels
{
    public class WarrantyType : IAuditable
    {
        public Guid Id { get; set; }
        public string Type { get; set; } = string.Empty;
        public DateTime CreateDate { get; set; } = DateTime.UtcNow;
        public DateTime? UpdateDate { get; set; }

        public ICollection<Warranty> Warranties { get; set; } = [];
    }
}
