using AutoMapper;
using REEP.Application.Common.Mappings;

namespace REEP.Application.Features.ContractFeatures.ContractTypesFeatures.PaymentTypes.Commands.SoftDeletePaymetType
{
    public class SoftDeletePaymentTypeDto : IMapWith<SoftDeletePaymentTypeCommand>
    {
        public Guid Id { get; set; }
        public bool IsDeleted { get; set; } = true;
        public void Mapping(Profile profile)
        {
            profile.CreateMap<SoftDeletePaymentTypeDto, SoftDeletePaymentTypeCommand>();
        }
    }
}
