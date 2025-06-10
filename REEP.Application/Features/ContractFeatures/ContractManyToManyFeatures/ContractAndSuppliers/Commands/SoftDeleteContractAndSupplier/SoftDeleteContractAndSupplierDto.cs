using AutoMapper;
using REEP.Application.Common.Mappings;

namespace REEP.Application.Features.ContractFeatures.ContractManyToManyFeatures.ContractAndSuppliers.Commands.SoftDeleteContractAndSupplier
{
    public class SoftDeleteContractAndSupplierDto
        : IMapWith<SoftDeleteContractAndSupplierCommand>
    {
        public Guid ContractId { get; set; }
        public Guid SupplierId { get; set; }
        public bool IsDeleted { get; set; } = true;

        public void Mapping(Profile profile)
        {
            profile.CreateMap<SoftDeleteContractAndSupplierDto, SoftDeleteContractAndSupplierCommand>();
        }
    }
}
