using System.ComponentModel.DataAnnotations;

namespace REEP.Domain.Models.ContractModels.ContractManyToManyModels
{
    public class ContractAndSupplier
    {
        [Key]
        public Guid ContractId { get; set; }
        public Contract Contract { get; set; } = null!;

        [Key]
        public Guid SupplierId { get; set; }
        public Supplier Supplier { get; set; } = null!;

        public DateTime CreateDate { get; set; } = DateTime.UtcNow;
        public DateTime? UpdateDate { get; set; } 
    }
}
