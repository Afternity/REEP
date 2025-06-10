using AutoMapper;
using REEP.Application.Common.Mappings;
using REEP.Domain.Models.ContractModels;

namespace REEP.Application.Features.ContractFeatures.Contracts.Queries.GetContractDetails
{
    public class ContractDetailsVm : IMapWith<Contract>
    {
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public DateTime StartedAt { get; set; }
        public DateTime EndedAt { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        public DateTime? UpdatedAt { get; set; }
        public DateTime? DeletedAt { get; set; }
        public bool IsDeleted { get; set; } = false;
        public string Type { get; set; } = null!;

        public void Mapping(Profile profile)
        {
            profile.CreateMap<Contract, ContractDetailsVm>()
                .ForMember(destination => destination.Type,
                    options => options.MapFrom(source => source.ContractType.Type));
        }
    }
}
