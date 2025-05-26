using REEP.Domain.Models.ContractModels.ContractManyToManyModels;
using REEP.Domain.Models.ContractModels.ContractTypeModels;
using REEP.Domain.InterfaceModels;

namespace REEP.Domain.Models.ContractModels
{
    public class Supplier : IAuditable, ISoftDeletable
    {
        public Guid Id { get; set; }
        public string? FirstName { get; set; } 
        public string? SecondName { get; set; } 
        public string? LastName { get; set; }
        public string? OtherName { get; set; } 
        public string? Number {  get; set; } 
        public string? Email { get; set; } 
        public string? OtherContacts { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        public DateTime? UpdatedAt { get; set; }
        public DateTime? DeletedAt { get; set; }
        public bool IsDeleted { get; set; } = false;

        public Guid SupplierTypeId { get; set; }
        public SupplierType SupplierType { get; set; } = null!;
        public ICollection<ContractAndSupplier> ContractsAndSuppliers { get; set; } = [];
    }
}
