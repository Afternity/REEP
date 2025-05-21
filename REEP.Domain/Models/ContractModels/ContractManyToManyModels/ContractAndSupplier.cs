using System.ComponentModel.DataAnnotations;
using REEP.Domain.InterfaceModels;

namespace REEP.Domain.Models.ContractModels.ContractManyToManyModels
{
    public class ContractAndSupplier : IAuditable
    {
        [Key]
        public Guid ContractId { get; set; }
        public Contract Contract { get; set; } = null!;

        [Key]
        public Guid SupplierId { get; set; }
        public Supplier Supplier { get; set; } = null!;

        public bool IsActive { get; set; } = true;
        public DateTime CreateDate { get; set; } = DateTime.UtcNow;
        public DateTime? UpdateDate { get; set; } 
    }
}
