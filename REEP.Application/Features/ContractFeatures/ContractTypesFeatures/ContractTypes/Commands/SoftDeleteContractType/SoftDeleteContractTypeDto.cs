using AutoMapper;
using REEP.Application.Common.Mappings;

namespace REEP.Application.Features.ContractFeatures.ContractTypesFeatures.ContractTypes.Commands.SoftDeleteContractType
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
