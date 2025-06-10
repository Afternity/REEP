namespace REEP.Application.Features.ContractFeatures.ContractManyToManyFeatures.ContractAndSuppliers.Queries.GetContractAndPaymentList
{
    public class ContractAndSupplierListVm
    {
        public ICollection<ContractAndSupplierLookupDto> ContractsAndSuppliers { get; set; } = [];

    }
}
