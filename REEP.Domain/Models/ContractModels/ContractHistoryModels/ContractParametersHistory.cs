namespace REEP.Domain.Models.ContractModels.ContractHistoryModels
{
    public class ContractParametersHistory
    {
        public Guid Id { get; set; }
        public DateTime CreateDate { get; set; } = DateTime.UtcNow;
        public string ChangeReason { get; set; } = "Update";
        public string Comment { get; set; } = string.Empty;

        public string ContractName {  get; set; } = string.Empty;
        public decimal PaymentPrice { get; set; } = decimal.Zero;
        public string PaymentFirstPay { get; set; } = string.Empty;
        public string PaymentPeriodPay { get; set; } = string.Empty;
        public string PaymentLastPay { get; set; } = string.Empty;
        public string? SupplierFirstName { get; set; }
        public string? SupplierSecondName { get; set; }
        public string? SupplierLastName { get; set; }
        public string? SupplierOtherName { get; set; }
        public string? SupplierNumber { get; set; }
        public string? SupplierEmail { get; set; }
        public string? SupplierOtherContacts { get; set; }

        public Guid ModifiedByUserId { get; set; }
        public string ModifiedByUserName { get; set; } = string.Empty;
        public Guid ContractId { get; set; }
    }
}
