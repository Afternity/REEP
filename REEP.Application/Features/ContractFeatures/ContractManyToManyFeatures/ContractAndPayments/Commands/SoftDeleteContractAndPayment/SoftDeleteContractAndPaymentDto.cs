using AutoMapper;
using REEP.Application.Common.Mappings;

namespace REEP.Application.Features.ContractFeatures.ContractManyToManyFeatures.ContractAndPayments.Commands.SoftDeleteContractAndPayment
{
    public class SoftDeleteContractAndPaymentDto
        : IMapWith<SoftDeleteContractAndPaymentCommand>
    {
        public Guid ContractId { get; set; }
        public Guid PaymentId { get; set; }
        public bool IsDeleted { get; set; } = true;

        public void Mapping(Profile profile)
        {
            profile.CreateMap<SoftDeleteContractAndPaymentDto,  SoftDeleteContractAndPaymentCommand>();
        }
    }
}
