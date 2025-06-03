namespace REEP.WPF_Client.Models.ContractType.CommandDto
{
    public class SoftDeleteContractTypeDto
    {
        public Guid Id {get; set;}
        public bool IsDeleted { get; set; } = true;
    }
}
