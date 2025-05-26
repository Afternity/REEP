using REEP.Domain.Models.ContractModels.ContractManyToManyModels;
using REEP.Domain.Models.ContractModels.ContractTypeModels;
using REEP.Domain.InterfaceModels;

namespace REEP.Domain.Models.ContractModels
{
    public class Payment : IAuditable, ISoftDeletable
    {
        public Guid Id { get; set; }
        public decimal Price { get; set; } = decimal.Zero;
        public DateTime FirstPay { get; set; }
        public TimeSpan PeriodPay { get; set; }
        public DateTime LastPay { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        public DateTime? UpdatedAt { get; set; }
        public DateTime? DeletedAt { get; set; }
        public bool IsDeleted { get; set; } = false;

        public Guid PaymentTypeId { get; set; }
        public PaymentType PaymentType { get; set; } = null!;
        public ICollection<ContractAndPayment> ContractsAndPayments { get; set; } = [];
    }
}
