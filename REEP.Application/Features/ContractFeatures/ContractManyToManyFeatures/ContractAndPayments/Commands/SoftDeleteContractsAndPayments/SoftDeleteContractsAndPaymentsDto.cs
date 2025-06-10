using AutoMapper;
using REEP.Application.Common.Mappings;

namespace REEP.Application.Features.ContractFeatures.ContractManyToManyFeatures.ContractAndPayments.Commands.SoftDeleteContractsAndPayments
{
    public class SoftDeleteContractsAndPaymentsDto
        : IMapWith<SoftDeleteContractsAndPaymentsCommand>
    {
        public Guid ContractId { get; set; }
        public Guid PaymentId { get; set; }
        public bool IsDeleted { get; set; } = true;

        public void Mapping(Profile profile)
        {
            profile.CreateMap<SoftDeleteContractsAndPaymentsDto,  SoftDeleteContractsAndPaymentsCommand>();
        }
    }
}
