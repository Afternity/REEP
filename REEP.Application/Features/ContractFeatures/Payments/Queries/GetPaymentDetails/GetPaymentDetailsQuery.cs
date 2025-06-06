using MediatR;

namespace REEP.Application.Features.ContractFeatures.Payments.Queries.GetPaymentDetails
{
    public class GetPaymentDetailsQuery : IRequest<PaymentDetailsVm>
    {
        public Guid Id { get; set; }
    }
}
