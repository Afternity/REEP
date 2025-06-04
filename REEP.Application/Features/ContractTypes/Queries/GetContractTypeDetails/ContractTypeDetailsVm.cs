using REEP.Application.Common.Mappings;
using REEP.Domain.Models.ContractModels.ContractTypeModels;
using AutoMapper;

namespace REEP.Application.Features.ContractTypes.Queries.GetContractTypeDetails
{
    public class ContractTypeDetailsVm : IMapWith<ContractType>
    {
        public string Type { get; set; } = null!;
        public DateTime CreatedAt { get; set; } 
        public DateTime? UpdatedAt { get; set; }
        public DateTime? DeletedAt { get; set; }
        public bool IsDeleted { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<ContractType, ContractTypeDetailsVm>();
        }
    }
}
