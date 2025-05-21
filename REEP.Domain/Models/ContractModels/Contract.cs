using REEP.Domain.Models.ContractModels.ContractManyToManyModels;

namespace REEP.Domain.Models.ContractModels
{
    public class Contract
    {
        public Guid Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public DateTime DateStart { get; set; }
        public DateTime DateEnd { get; set; }
        public IList<ContractAndPayment> ContractsAndPayments { get; set; } = [];
        public IList<ContractAndSupplier> ContractsAndSuppliers { get; set; } = [];
    }
}
