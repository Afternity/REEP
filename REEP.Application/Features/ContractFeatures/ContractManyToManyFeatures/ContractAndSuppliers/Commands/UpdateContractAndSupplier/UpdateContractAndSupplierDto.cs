using AutoMapper;
using REEP.Application.Common.Mappings;

namespace REEP.Application.Features.ContractFeatures.ContractManyToManyFeatures.ContractAndSuppliers.Commands.UpdateContractAndSupplier
{
    public class UpdateContractAndSupplierDto
        : IMapWith<UpdateContractAndSupplierCommand>
    {
        public Guid ContractId { get; set; }
        public Guid SupplierId { get; set; }
        public bool IsActive { get; set; } = false;

        public void Mapping(Profile profile)
        {
            profile.CreateMap<UpdateContractAndSupplierDto, UpdateContractAndSupplierCommand>();
        }
    }
}
