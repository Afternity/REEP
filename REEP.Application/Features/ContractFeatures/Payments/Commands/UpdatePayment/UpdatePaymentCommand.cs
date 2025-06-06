using MediatR;

namespace REEP.Application.Features.ContractFeatures.Payments.Commands.UpdatePayment
{
    public class UpdatePaymentCommand : IRequest<Unit>
    {
        public Guid Id { get; set; }
        public decimal Price { get; set; } = decimal.Zero;
        public DateOnly FirstPay { get; set; }
        public TimeSpan PeriodPay { get; set; }
        public DateOnly LastPay { get; set; }
        public string Type { get; set; } = null!;
    }
}
