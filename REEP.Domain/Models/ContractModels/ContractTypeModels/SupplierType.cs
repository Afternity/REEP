namespace REEP.Domain.Models.ContractModels.ContractTypeModels
{
    public class SupplierType
    {
        public Guid Id { get; set; }
        public string Type { get; set; } = string.Empty;
        public IList<Supplier> Suppliers { get; set; } = [];
    }
}
