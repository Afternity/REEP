using AutoMapper;
using REEP.Application.Common.Mappings;
using REEP.Application.Features.ContractTypes.Commands.UpdateContractType;

namespace REEP.Application.Features.ContractTypes.Commands.SoftDeleteContractType
{
    public class SoftDeleteContractTypeDto : IMapWith<SoftDeleteContractTypeCommand>
    {
        public Guid Id { get; set; }
        public bool IsDeleted { get; set; } = true;

        public void Mapping(Profile profile)
        {
            profile.CreateMap<SoftDeleteContractTypeDto, SoftDeleteContractTypeCommand>();
        }
    }
}
