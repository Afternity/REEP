namespace REEP.Application.Features.ContractFeatures.ContractTypesFeatures.ContractTypes.Queries.GetContractTypeList
{
    public class ContractTypeListVm 
    {
        public ICollection<ContractTypeLookupDto> ContractTypes { get; set; } = [];
    }
}
