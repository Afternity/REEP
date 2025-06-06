using AutoMapper;
using REEP.Application.Common.Mappings;
using REEP.Domain.Models.ContractModels;

namespace REEP.Application.Features.ContractFeatures.Payments.Queries.GetPaymentDetails
{
    public class PaymentDetailsVm : IMapWith<Payment>
    {
        public decimal Price { get; set; } 
        public DateOnly FirstPay { get; set; }
        public TimeSpan PeriodPay { get; set; }
        public DateOnly LastPay { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public DateTime? DeletedAt { get; set; }
        public bool IsDeleted { get; set; }
        public string Type { get; set; } = null!;

        public void Mapping(Profile profile)
        {
            profile.CreateMap<Payment, PaymentDetailsVm>()
                .ForMember(destination => destination.Type,
                    options => options.MapFrom(soure => soure.PaymentType.Type));
        }
    }
}
