namespace REEP.Domain.Models.ContractModels.ContractTypeModels
{
    public class PaymentType
    {
        public int Id { get; set; }
        public string Type { get; set; } = string.Empty;
        public IList<Payment> Payments { get; set; } = [];
    }
}
