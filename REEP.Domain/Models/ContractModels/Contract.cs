using REEP.Domain.Models.ContractModels.ContractManyToManyModels;
using REEP.Domain.Models.WarrantyModels;
using REEP.Domain.Models.ContractModels.ContractTypeModels;
using REEP.Domain.InterfaceModels;

namespace REEP.Domain.Models.ContractModels
{
    public class Contract : IAuditable, ISoftDeletable
    {
        public Guid Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public DateTime StartedAt { get; set; }
        public DateTime EndedAt { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        public DateTime? UpdatedAt { get; set; }
        public DateTime? DeletedAt { get; set; }
        public bool IsDeleted { get; set; } = false;

        public Guid ContractTypeId { get; set; }
        public ContractType ContractType { get; set; } = null!;
        public ICollection<ContractAndPayment> ContractsAndPayments { get; set; } = [];
        public ICollection<ContractAndSupplier> ContractsAndSuppliers { get; set; } = [];
        public ICollection<Warranty> Warranties { get; set; } = [];
    }
}
