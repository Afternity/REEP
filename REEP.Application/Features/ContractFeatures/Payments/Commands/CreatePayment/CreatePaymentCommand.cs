using MediatR;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace REEP.Application.Features.ContractFeatures.Payments.Commands.CreatePayment
{
    public class CreatePaymentCommand : IRequest<Guid>
    {
        public decimal Price { get; set; } = decimal.Zero;
        public DateOnly FirstPay { get; set; }
        public TimeSpan PeriodPay { get; set; }
        public DateOnly LastPay { get; set; }
        public bool IsDeleted { get; set; } = false;
        public string Type { get; set; } = null!;
    }
}
