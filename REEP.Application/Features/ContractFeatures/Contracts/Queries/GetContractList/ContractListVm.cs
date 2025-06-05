namespace REEP.Application.Features.ContractFeatures.Contracts.Queries.GetContractList
{
    public class ContractListVm 
    {
        public ICollection<ContractLookupDto> Contracts { get; set; } = [];
    }
}
