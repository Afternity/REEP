namespace REEP.Application.Features.ContractFeatures.Suppliers.Queries.GetSupplierList
{
    public class SupplierListVm
    {
        public ICollection<SupplierLookupDto> Suppliers { get; set; } = [];
    }
}
