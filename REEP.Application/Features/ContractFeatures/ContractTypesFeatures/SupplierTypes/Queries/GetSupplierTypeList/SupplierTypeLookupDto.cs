using AutoMapper;
using REEP.Application.Common.Mappings;
using REEP.Domain.Models.ContractModels.ContractTypeModels;

namespace REEP.Application.Features.ContractFeatures.ContractTypesFeatures.SupplierTypes.Queries.GetSupplierTypeList
{
    public class SupplierTypeLookupDto : IMapWith<SupplierType>
    {
        public Guid Id { get; set; }
        public string Type { get; set; } = null!;

        public void Mapping(Profile profile)
        {
            profile.CreateMap<SupplierType,  SupplierTypeLookupDto>();
        }
    }
}
