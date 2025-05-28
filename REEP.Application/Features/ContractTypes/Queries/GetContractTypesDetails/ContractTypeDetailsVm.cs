using REEP.Application.Common.Mappings;
using REEP.Domain.Models.ContractModels.ContractTypeModels;
using AutoMapper;

namespace REEP.Application.Features.ContractTypes.Queries.GetContractTypesDetails
{
    public class ContractTypeDetailsVm : IMapWith<ContractType>
    {
        public string Type { get; set; } 
        public DateTime CreatedAt { get; set; } 
        public DateTime? UpdatedAt { get; set; }
        public DateTime? DeletedAt { get; set; }
        public bool IsDeleted { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<ContractType, ContractTypeDetailsVm>()
                .ForMember(contractTypeVm => contractTypeVm.Type,
                    opt => opt.MapFrom(contractType => contractType.Type))
                .ForMember(contractTypeVm => contractTypeVm.CreatedAt,
                    opt => opt.MapFrom(contractType => contractType.CreatedAt))
                .ForMember(contractTypeVm => contractTypeVm.UpdatedAt,
                    opt => opt.MapFrom(contractType => contractType.UpdatedAt))
                .ForMember(contractTypeVm => contractTypeVm.DeletedAt,
                    opt => opt.MapFrom(contractType => contractType.DeletedAt))
                .ForMember(contractTypeVm => contractTypeVm.IsDeleted,
                    opt => opt.MapFrom(contractType => contractType.IsDeleted));
        }
    }
}
