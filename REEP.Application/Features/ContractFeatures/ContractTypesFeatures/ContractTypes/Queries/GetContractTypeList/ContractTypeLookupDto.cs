using REEP.Application.Common.Mappings;
using REEP.Domain.Models.ContractModels.ContractTypeModels;
using AutoMapper;

namespace REEP.Application.Features.ContractFeatures.ContractTypesFeatures.ContractTypes.Queries.GetContractTypeList
{
    public class ContractTypeLookupDto : IMapWith<ContractType>
    {
        public Guid Id { get; set; }
        public string Type { get; set; } = null!;

        public void Mapping(Profile profile)
        {
            profile.CreateMap<ContractType, ContractTypeLookupDto>()
                .ForMember(contractTypeDto => contractTypeDto.Type,
                    opt => opt.MapFrom(contractType => contractType.Type));
        }
    }
}
