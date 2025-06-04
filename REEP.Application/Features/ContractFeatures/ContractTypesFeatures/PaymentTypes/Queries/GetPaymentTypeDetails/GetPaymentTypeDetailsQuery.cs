using MediatR;

namespace REEP.Application.Features.ContractFeatures.ContractTypesFeatures.PaymentTypes.Queries.GetPaymentTypeDetails
{
    public class GetPaymentTypeDetailsQuery : IRequest<PaymentTypeDetailsVm>
    {
        public Guid Id { get; set; }
    }
}
