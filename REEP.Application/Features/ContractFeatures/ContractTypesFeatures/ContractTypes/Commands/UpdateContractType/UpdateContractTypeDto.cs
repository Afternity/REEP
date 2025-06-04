using AutoMapper;
using REEP.Application.Common.Mappings;

namespace REEP.Application.Features.ContractFeatures.ContractTypesFeatures.ContractTypes.Commands.UpdateContractType
{
    public class UpdateContractTypeDto : IMapWith<UpdateContractTypeCommand>
    {
        public Guid Id { get; set; }
        public string Type { get; set; } = null!;

        public void Mapping(Profile profile)
        {
            profile.CreateMap<UpdateContractTypeDto, UpdateContractTypeCommand>()
             .ForMember(contractTypeVm => contractTypeVm.Id,
                opt => opt.MapFrom(contractType => contractType.Id))
             .ForMember(contractTypeVm => contractTypeVm.Type,
                 opt => opt.MapFrom(contractType => contractType.Type));
        }
    }
}
