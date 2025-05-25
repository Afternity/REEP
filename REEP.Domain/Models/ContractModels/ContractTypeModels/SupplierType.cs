using REEP.Domain.InterfaceModels;

namespace REEP.Domain.Models.ContractModels.ContractTypeModels
{
    public class SupplierType : IAuditable
    {
        public Guid Id { get; set; }
        public string Type { get; set; } = string.Empty;
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        public DateTime? UpdatedAt { get; set; }

        public ICollection<Supplier> Suppliers { get; set; } = [];
    }
}
