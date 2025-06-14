namespace REEP.WPF_Client.Models.ContractType.QueryVm.DetailsVm
{
    public class ContractTypeDetailsVm
    {
        public string Type { get; set; } = null!;
        public DateTime CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public DateTime? DeletedAt { get; set; }
        public bool IsDeleted { get; set; }
    }
}
