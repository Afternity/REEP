using AutoMapper;
using MediatR;
using REEP.Application.Common.Mappings;

namespace REEP.Application.Features.ContractFeatures.Payments.Commands.CreatePayment
{
    public class CreatePaymentDto : IMapWith<CreatePaymentDto>
    {
        public decimal Price { get; set; } = decimal.Zero;
        public DateOnly FirstPay { get; set; }
        public TimeSpan PeriodPay { get; set; }
        public DateOnly LastPay { get; set; }
        public bool IsDeleted { get; set; } = false;
        public string Type { get; set; } = null!;

        public void Mapping(Profile profile)
        {
            profile.CreateMap<CreatePaymentDto, CreatePaymentCommand>();
        }
    }
}
