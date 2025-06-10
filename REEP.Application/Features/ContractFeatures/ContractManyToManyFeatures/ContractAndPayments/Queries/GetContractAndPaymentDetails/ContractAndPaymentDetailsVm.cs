using AutoMapper;
using REEP.Application.Common.Mappings;
using REEP.Domain.Models.ContractModels.ContractManyToManyModels;

namespace REEP.Application.Features.ContractFeatures.ContractManyToManyFeatures.ContractAndPayments.Queries.GetContractAndPaymentDetails
{
    public class ContractAndPaymentDetailsVm
        : IMapWith<ContractAndPayment>
    {
        public Guid ContractId { get; set; }
        public Guid PaymentId { get; set; }
        public bool IsActive { get; set; } 
        public DateTime CreatedAt { get; set; } 
        public DateTime? UpdatedAt { get; set; }
        public DateTime? DeletedAt { get; set; }
        public bool IsDeleted { get; set; }
        public string ContractName { get; set; } = null!;
        public string ContractType { get; set; } = null!;
        public decimal PaymentPrice { get; set; } 
        public string? PaymentOtherPrice { get; set; }
        public TimeSpan PaymentPeriodPay { get; set; }
        public string PaymentType { get; set; } = null!;

        public void Mapping(Profile profile)
        {
            profile.CreateMap<ContractAndPayment, ContractAndPaymentDetailsVm>()
                .ForMember(destination => destination.ContractName,
                    options => options.MapFrom(source => source.Contract.Name))
                .ForMember(destination => destination.ContractType,
                    options => options.MapFrom(source => source.Contract.ContractType.Type))
                .ForMember(destination => destination.PaymentPrice,
                    options => options.MapFrom(source => source.Payment.Price))
                .ForMember(destination => destination.PaymentOtherPrice,
                    options => options.MapFrom(source => source.Payment.OtherPrice))
                .ForMember(destination => destination.PaymentPeriodPay,
                    options => options.MapFrom(source => source.Payment.PeriodPay))
                .ForMember(destination => destination.PaymentType,
                    options => options.MapFrom(source => source.Payment.PaymentType.Type));
        }
    }
}
