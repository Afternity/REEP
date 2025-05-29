using AutoMapper;
using MediatR;
using REEP.Application.Features.ContractTypes.Commands.CreateContractType;
using REEP.Application.Features.ContractTypes.Queries.GetContractTypesDetails;
using REEP.Domain.Models.ContractModels.ContractTypeModels;

namespace REEP.WebApi.Models
{
    public class CreateContractTypeDto : IRequest<CreateContractTypeCommand>
    {
        public string Type { get; set; } = string.Empty;
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
