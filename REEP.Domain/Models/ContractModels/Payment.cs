using REEP.Domain.Models.ContractModels.ContractManyToManyModels;
using REEP.Domain.Models.ContractModels.ContractTypeModels;

namespace REEP.Domain.Models.ContractModels
{
    public class Payment
    {
        public Guid Id { get; set; }
        public decimal Price { get; set; }
        public DateTime FirstPay { get; set; }
        public DateTime PeriodPay { get; set; }
        public DateTime LastPay { get; set; }

        public Guid PaymentTypeId { get; set; }
        public PaymentType PaymentType { get; set; } = null!;
        public IList<ContractAndPayment> ContractsAndPayments { get; set; } = [];
    }
}
