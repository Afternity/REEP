using MediatR;

namespace REEP.Application.Features.PaymentTypes.Queries.GetPaymentTypeList
{
    public class GetPaymentTypeListQuery : IRequest<PaymentTypeListVm>
    {
        public bool IsDeleted { get; set; } = false;
    }
}
