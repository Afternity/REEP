using AutoMapper;
using REEP.Application.Common.Mappings;

namespace REEP.Application.Features.ContractFeatures.Contracts.Commands.SoftDeleteContract
{
    public class SoftDeleteContractDto : IMapWith<SoftDeleteContractCommand>
    {
        public Guid Id { get; set; }
        public bool IsDeleted { get; set; } = true;

        public void Mapping(Profile profile)
        {
            profile.CreateMap<SoftDeleteContractDto, SoftDeleteContractCommand>();
        }
    }
}
