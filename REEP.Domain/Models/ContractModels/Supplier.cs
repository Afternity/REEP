using REEP.Domain.Models.ContractModels.ContractManyToManyModels;
using REEP.Domain.Models.ContractModels.ContractTypeModels;

namespace REEP.Domain.Models.ContractModels
{
    public class Supplier
    {
        public Guid Id { get; set; }
        public string? FirstName { get; set; } = string.Empty;
        public string? SecondName { get; set; } = string.Empty;
        public string? LastName { get; set; }
        public string? OtherName { get; set; } = string.Empty;
        public string? Number {  get; set; } = string.Empty;
        public string? Email { get; set; } = string.Empty;
        public string? OtherContacts { get; set; }

        public Guid SupplierTypeId { get; set; }
        public SupplierType SupplierType { get; set; } = null!;
        public IList<ContractAndSupplier> ContractsAndSuppliers { get; set; } = [];
    }
}
