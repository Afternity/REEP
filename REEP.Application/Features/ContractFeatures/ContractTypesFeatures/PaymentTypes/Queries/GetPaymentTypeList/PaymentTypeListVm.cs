namespace REEP.Application.Features.ContractFeatures.ContractTypesFeatures.PaymentTypes.Queries.GetPaymentTypeList
{
    public class PaymentTypeListVm
    {
        public ICollection<PaymentTypeLookupDto> PaymentTypes { get; set; } = [];
    }
}
