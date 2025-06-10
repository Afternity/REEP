using AutoMapper;
using REEP.Application.Common.Mappings;

namespace REEP.Application.Features.ContractFeatures.ContractManyToManyFeatures.ContractAndSuppliers.Commands.CreateContractAndSupplier
{
    public class CreateContractAndSupplierDto
        : IMapWith<CreateContractAndSupplierCommand>
    {
        public Guid ContractId { get; set; }
        public Guid SupplierId { get; set; }
        public bool IsActive { get; set; } = true;
        public bool IsDeleted { get; set; } = false;

        public void Mapping(Profile profile)
        {
            profile.CreateMap<CreateContractAndSupplierDto, CreateContractAndSupplierCommand>();
        }
    }
}
