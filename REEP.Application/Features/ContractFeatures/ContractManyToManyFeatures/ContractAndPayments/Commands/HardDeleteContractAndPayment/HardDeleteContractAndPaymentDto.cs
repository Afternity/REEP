using AutoMapper;
using REEP.Application.Common.Mappings;

namespace REEP.Application.Features.ContractFeatures.ContractManyToManyFeatures.ContractAndPayments.Commands.HardDeleteContractAndPayment
{
    public class HardDeleteContractAndPaymentDto
        : IMapWith<HardDeleteContractAndPaymentCommand>
    {
        public Guid ContractId { get; set; }
        public Guid PaymentId { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<HardDeleteContractAndPaymentDto, HardDeleteContractAndPaymentCommand>();
        }
    }
}
