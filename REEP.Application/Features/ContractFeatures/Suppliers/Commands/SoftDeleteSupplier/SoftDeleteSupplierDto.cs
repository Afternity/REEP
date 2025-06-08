using AutoMapper;
using REEP.Application.Common.Mappings;

namespace REEP.Application.Features.ContractFeatures.Suppliers.Commands.SoftDeleteSupplier
{
    public class SoftDeleteSupplierDto : IMapWith<SoftDeleteSupplierCommand>
    {
        public Guid Id { get; set; }
        public bool IsDeleted { get; set; } = true;
        
        public void Mapping(Profile profile)
        {
            profile.CreateMap<SoftDeleteSupplierDto,  SoftDeleteSupplierCommand>();
        }
    }
}
