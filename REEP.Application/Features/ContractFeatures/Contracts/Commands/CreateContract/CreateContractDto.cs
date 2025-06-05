using AutoMapper;
using REEP.Application.Common.Mappings;

namespace REEP.Application.Features.ContractFeatures.Contracts.Commands.CreateContract
{
    public class CreateContractDto : IMapWith<CreateContractCommand>
    {
        public string Name { get; set; } = null!;
        public string Description { get; set; } = null!;
        public DateTime StartedAt { get; set; }
        public DateTime EndedAt { get; set; }
        public bool IsDeleted { get; set; } = false;
        public string Type { get; set; } = null!;

        public void Mapping(Profile profile)
        {
            profile.CreateMap<CreateContractDto, CreateContractCommand>();
        }
    }
}
