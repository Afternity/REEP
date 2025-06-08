using AutoMapper;
using REEP.Application.Common.Mappings;
using REEP.Domain.Models.ContractModels;

namespace REEP.Application.Features.ContractFeatures.Payments.Queries.GetPaymentList
{
    public class PaymentLookupDto : IMapWith<Payment>
    {
        public Guid Id { get; set; }
        public decimal Price { get; set; }
        public DateOnly FirstPay { get; set; }
        public TimeSpan PeriodPay { get; set; }
        public DateOnly LastPay { get; set; }
        public string Type { get; set; } = null!;

        public void Mapping(Profile profile)
        {
            profile.CreateMap<Payment, PaymentLookupDto>()
                .ForMember(destination => destination.Type,
                     options => options.MapFrom(soure => soure.PaymentType.Type));
        }
    }
}
