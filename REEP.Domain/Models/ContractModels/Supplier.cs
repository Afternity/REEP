using REEP.Domain.Models.ContractModels.ContractManyToManyModels;
using REEP.Domain.Models.ContractModels.ContractTypeModels;
using REEP.Domain.InterfaceModels;

namespace REEP.Domain.Models.ContractModels
{
    public class Supplier : IAuditable
    {
        public Guid Id { get; set; }
        public string? FirstName { get; set; } 
        public string? SecondName { get; set; } 
        public string? LastName { get; set; }
        public string? OtherName { get; set; } 
        public string? Number {  get; set; } 
        public string? Email { get; set; } 
        public string? OtherContacts { get; set; }
        public DateTime CreateDate { get; set; } = DateTime.UtcNow;
        public DateTime? UpdateDate { get; set; }

        public Guid SupplierTypeId { get; set; }
        public SupplierType SupplierType { get; set; } = null!;
        public IList<ContractAndSupplier> ContractsAndSuppliers { get; set; } = [];
    }
}
