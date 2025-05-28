using REEP.Application.Common.Mappings;
using REEP.Domain.Models.ContractModels.ContractTypeModels;
using AutoMapper;

namespace REEP.Application.Features.ContractTypes.Queries.GetContractTypesList
{
    public class ContractTypeLookupDto : IMapWith<ContractType>
    {
        public string Type { get; set; } 
        public bool IsDeleted { get; set; } 

        public void Mapping(Profile profile)
        {
            profile.CreateMap<ContractType, ContractTypeLookupDto>()
                .ForMember(contractTypeDto => contractTypeDto.Type,
                    opt => opt.MapFrom(contractType => contractType.Type))
                .ForMember(contractTypeDto => contractTypeDto.IsDeleted,
                    opt => opt.MapFrom(contractType => contractType.IsDeleted));
        }
    }
}
