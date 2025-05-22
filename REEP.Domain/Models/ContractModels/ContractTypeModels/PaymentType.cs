using REEP.Domain.InterfaceModels;

namespace REEP.Domain.Models.ContractModels.ContractTypeModels
{
    public class PaymentType : IAuditable
    {
        public int Id { get; set; }
        public string Type { get; set; } = string.Empty;
        public DateTime CreateDate { get; set; } = DateTime.UtcNow;
        public DateTime? UpdateDate { get; set; }

        public ICollection<Payment> Payments { get; set; } = [];
    }
}
