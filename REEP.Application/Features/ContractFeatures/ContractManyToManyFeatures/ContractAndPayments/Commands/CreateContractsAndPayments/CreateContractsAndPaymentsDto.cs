using AutoMapper;
using REEP.Application.Common.Mappings;

namespace REEP.Application.Features.ContractFeatures.ContractManyToManyFeatures.ContractAndPayments.Commands.CreateContractsAndPayments
{
    public class CreateContractsAndPaymentsDto 
        : IMapWith<CreateContractsAndPaymentsCommand>
    {
        public Guid ContractId { get; set; }
        public Guid PaymentId { get; set; }
        public bool IsActive { get; set; } = true;
        public bool IsDeleted { get; set; } = false;

        public void Mapping(Profile profile)
        {
            profile.CreateMap<CreateContractsAndPaymentsDto, CreateContractsAndPaymentsCommand>();
        }
    }
}
