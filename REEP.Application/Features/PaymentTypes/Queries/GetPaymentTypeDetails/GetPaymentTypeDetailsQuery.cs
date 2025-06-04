using MediatR;

namespace REEP.Application.Features.PaymentTypes.Queries.GetPaymentTypeDetails
{
    public class GetPaymentTypeDetailsQuery : IRequest<PaymentTypeDetailsVm>
    {
        public Guid Id { get; set; }
    }
}
