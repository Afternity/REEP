using AutoMapper;
using REEP.Application.Common.Mappings;

namespace REEP.Application.Features.ContractFeatures.ContractTypesFeatures.SupplierTypes.Commands.SoftDeleteSupplierType
{
    public class SoftDeleteSupplierTypeDto : IMapWith<SoftDeleteSupplierTypeCommand>
    {
        public Guid Id { get; set; }
        public bool IsDeleted { get; set; } = true;
        public void Mapping(Profile profile)
        {
            profile.CreateMap<SoftDeleteSupplierTypeDto, SoftDeleteSupplierTypeCommand>();
        }
    }
}
