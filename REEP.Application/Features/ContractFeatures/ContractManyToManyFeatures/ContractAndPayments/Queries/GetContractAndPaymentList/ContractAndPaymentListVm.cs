namespace REEP.Application.Features.ContractFeatures.ContractManyToManyFeatures.ContractAndPayments.Queries.GetContractAndPaymentList
{
    public class ContractAndPaymentListVm
    {
        public ICollection<ContractAndPaymentLookupDto> ContractsAndPayments { get; set; } = [];
    }
}
