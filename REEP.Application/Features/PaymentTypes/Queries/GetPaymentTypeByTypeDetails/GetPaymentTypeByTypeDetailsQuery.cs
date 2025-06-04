using MediatR;

namespace REEP.Application.Features.PaymentTypes.Queries.GetPaymentTypeByTypeDetails
{
    public class GetPaymentTypeByTypeDetailsQuery : IRequest<PaymentTypeByTypeDelailsVm>
    {
        public string Type { get; set; } = null!;
    }
}
