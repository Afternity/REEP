using MediatR;

namespace REEP.Application.Features.ContractFeatures.Payments.Queries.GetPaymentList
{
    public class GetPaymentListQuery : IRequest<PaymentListVm>
    {
        public bool IsDeleted { get; set; } = false;
    }
}
