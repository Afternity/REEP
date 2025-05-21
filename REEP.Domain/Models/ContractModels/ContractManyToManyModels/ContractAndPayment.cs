using System.ComponentModel.DataAnnotations;

namespace REEP.Domain.Models.ContractModels.ContractManyToManyModels
{
    public class ContractAndPayment
    {
        [Key]
        public Guid ContractId { get; set; }
        public Contract Contract { get; set; } = null!;

        [Key]
        public Guid PaymentId { get; set; }
        public Payment Payment { get; set; } = null!;

        public DateTime CreateDate { get; set; } = DateTime.UtcNow;
        public DateTime? UpdateDate { get; set; }
    }
}
