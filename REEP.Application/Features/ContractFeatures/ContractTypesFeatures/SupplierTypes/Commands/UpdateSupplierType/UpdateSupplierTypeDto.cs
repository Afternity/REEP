using AutoMapper;
using REEP.Application.Common.Mappings;

namespace REEP.Application.Features.ContractFeatures.ContractTypesFeatures.SupplierTypes.Commands.UpdateSupplierType
{
    public class UpdateSupplierTypeDto : IMapWith<UpdateSupplierTypeCommand>
    {
        public Guid Id { get; set; }
        public string Type { get; set; } = null!;

        public void Mapping(Profile profile)
        {
            profile.CreateMap<UpdateSupplierTypeDto, UpdateSupplierTypeCommand>();
        }
    }
}
