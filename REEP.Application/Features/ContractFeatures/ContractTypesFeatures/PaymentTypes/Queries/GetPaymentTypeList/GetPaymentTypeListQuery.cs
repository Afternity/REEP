using MediatR;

namespace REEP.Application.Features.ContractFeatures.ContractTypesFeatures.PaymentTypes.Queries.GetPaymentTypeList
{
    public class GetPaymentTypeListQuery : IRequest<PaymentTypeListVm>
    {
        public bool IsDeleted { get; set; } = false;
    }
}
