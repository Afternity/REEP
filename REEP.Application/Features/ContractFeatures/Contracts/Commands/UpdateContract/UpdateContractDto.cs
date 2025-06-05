using AutoMapper;
using REEP.Application.Common.Mappings;

namespace REEP.Application.Features.ContractFeatures.Contracts.Commands.UpdateContract
{
    public class UpdateContractDto : IMapWith<UpdateContractCommand>
    {
        public Guid Id { get; set; }
        public string Name { get; set; } = null!;
        public string Description { get; set; } = null!;
        public DateTime StartedAt { get; set; }
        public DateTime EndedAt { get; set; }
        public string Type { get; set; } = null!;

        public void Mapping(Profile profile)
        {
            profile.CreateMap<UpdateContractDto, UpdateContractCommand>();
        }
    }
}
