namespace REEP.Application.Features.ContractFeatures.ContractManyToManyFeatures.ContractAndPayments.Queries.GetContractsAndPaymentsList
{
    public class ContractsAndPaymentsListVm
    {
        public ICollection<ContractsAndPaymentsLookupDto> ContractsAndPayments { get; set; } = [];
    }
}
