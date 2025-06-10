using AutoMapper;
using REEP.Application.Common.Mappings;
using REEP.Domain.Models.ContractModels.ContractTypeModels;

namespace REEP.Application.Features.ContractFeatures.ContractTypesFeatures.SupplierTypes.Commands.CreateSupplierType
{
    public class CreateWarrantyTypeDto : IMapWith<CreateWarrantyTypeCommand>
    {
        public string Type { get; set; } = null!;
        public bool IsDeleted { get; set; } 

        public void Mapping(Profile profile)
        {
            profile.CreateMap<CreateWarrantyTypeDto, CreateWarrantyTypeCommand>();
        }
    }
}
