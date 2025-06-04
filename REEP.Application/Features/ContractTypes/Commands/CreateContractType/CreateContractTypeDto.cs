using REEP.Application.Common.Mappings;
using AutoMapper;

namespace REEP.Application.Features.ContractTypes.Commands.CreateContractType
{
    public class CreateContractTypeDto : IMapWith<CreateContractTypeCommand>
    {
        public string Type { get; set; } = null!;
        public bool IsDeleted { get; set; } = false;

        public void Mapping(Profile profile)
        {
            profile.CreateMap<CreateContractTypeDto, CreateContractTypeCommand>()
                .ForMember(contractTypeVm => contractTypeVm.Type,
                    opt => opt.MapFrom(contractType => contractType.Type))
                .ForMember(contractTypeVm => contractTypeVm.IsDeleted,
                    opt => opt.MapFrom(contractType => contractType.IsDeleted));
        }
    }
}
