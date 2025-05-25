using REEP.Domain.Models.ContractModels.ContractManyToManyModels;
using REEP.Domain.Models.WarrantyModels;
using REEP.Domain.Models.ContractModels.ContractTypeModels;
using REEP.Domain.InterfaceModels;

namespace REEP.Domain.Models.ContractModels
{
    public class Contract : IAuditable
    {
        public Guid Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public DateTime DateStart { get; set; }
        public DateTime DateEnd { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        public DateTime? UpdateDate { get; set; }

        public Guid ContractTypeId { get; set; }
        public ContractType ContractType { get; set; } = null!;
        public ICollection<ContractAndPayment> ContractsAndPayments { get; set; } = [];
        public ICollection<ContractAndSupplier> ContractsAndSuppliers { get; set; } = [];
        public ICollection<Warranty> Warranties { get; set; } = [];
    }
}
