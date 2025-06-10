using AutoMapper;
using REEP.Application.Common.Mappings;
using REEP.Domain.Models.ContractModels;

namespace REEP.Application.Features.ContractFeatures.Contracts.Queries.GetContractList
{
    public class ContractLookupDto : IMapWith<Contract>
    {
        public Guid Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public DateTime StartedAt { get; set; }
        public DateTime EndedAt { get; set; }
        public string Type { get; set; } = null!;

        public void Mapping(Profile profile)
        {
            profile.CreateMap<Contract, ContractLookupDto>()
                 .ForMember(destination => destination.Type,
                     options => options.MapFrom(soure => soure.ContractType.Type));
        }
    }
}
