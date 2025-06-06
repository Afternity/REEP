namespace REEP.Application.Features.ContractFeatures.Payments.Queries.GetPaymentList
{
    public class PaymentListVm 
    {
        public ICollection<PaymentLookupDto> Payments { get; set; } = [];
    }
}
