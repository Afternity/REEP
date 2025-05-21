using REEP.Domain.Models.ContractModels.ContractManyToManyModels;
using REEP.Domain.Models.ContractModels.ContractTypeModels;
using REEP.Domain.InterfaceModels;

namespace REEP.Domain.Models.ContractModels
{
    public class Payment : IAuditable
    {
        public Guid Id { get; set; }
        public decimal Price { get; set; } = decimal.Zero;
        public DateTime FirstPay { get; set; }
        public TimeSpan PeriodPay { get; set; }
        public DateTime LastPay { get; set; }
        public DateTime CreateDate { get; set; } = DateTime.UtcNow;
        public DateTime? UpdateDate { get; set; }

        public Guid PaymentTypeId { get; set; }
        public PaymentType PaymentType { get; set; } = null!;
        public IList<ContractAndPayment> ContractsAndPayments { get; set; } = [];
    }
}
