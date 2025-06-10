using AutoMapper;
using REEP.Application.Common.Mappings;

namespace REEP.Application.Features.ContractFeatures.ContractManyToManyFeatures.ContractAndSuppliers.Commands.HardDeleteContractAndSupplier
{
    public class HardDeleteContractAndSupplierDto
        : IMapWith<HardDeleteContractAndSupplierCommand>
    {
        public Guid ContractId { get; set; }
        public Guid SupplierId { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<HardDeleteContractAndSupplierDto, HardDeleteContractAndSupplierCommand>();
        }
    }
}
