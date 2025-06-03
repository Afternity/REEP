namespace REEP.WPF_Client.Models.ContractType.CommandDto
{
    public class CreateContractTypeDto 
    {
        public string Type { get; set; } = string.Empty;
        public bool IsDeleted { get; set; } = false;
    }
}
