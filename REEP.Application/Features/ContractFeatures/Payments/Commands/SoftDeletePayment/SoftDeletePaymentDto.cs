using AutoMapper;
using REEP.Application.Common.Mappings;

namespace REEP.Application.Features.ContractFeatures.Payments.Commands.SoftDeletePayment
{
    public class SoftDeletePaymentDto : IMapWith<SoftDeletePaymentCommand>
    {
        public Guid Id { get; set; }
        public bool IsDeleted { get; set; } = true;

        public void Mapping(Profile profile)
        {
            profile.CreateMap<SoftDeletePaymentDto,  SoftDeletePaymentCommand>();
        }
    }
}
