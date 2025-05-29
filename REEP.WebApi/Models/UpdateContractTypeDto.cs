using AutoMapper;
using REEP.Application.Common.Mappings;
using REEP.Application.Features.ContractTypes.Commands.UpdateContractTypes;
using REEP.Application.Features.ContractTypes.Queries.GetContractTypesDetails;
using REEP.Domain.Models.ContractModels.ContractTypeModels;

namespace REEP.WebApi.Models
{
    public class UpdateContractTypeDto : IMapWith<UpdateContractTypeCommand>
    {
        public Guid Id { get; set; }
        public string Type { get; set; } 
        public DateTime CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public DateTime? DeletedAt { get; set; }
        public bool IsDeleted { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<UpdateContractTypeDto, UpdateContractTypeCommand>()
             .ForMember(contractTypeVm => contractTypeVm.Id,
                opt => opt.MapFrom(contractType => contractType.Id))
             .ForMember(contractTypeVm => contractTypeVm.Type,
                 opt => opt.MapFrom(contractType => contractType.Type))
             .ForMember(contractTypeVm => contractTypeVm.CreatedAt,
                 opt => opt.MapFrom(contractType => contractType.CreatedAt))
             .ForMember(contractTypeVm => contractTypeVm.UpdatedAt,
                 opt => opt.MapFrom(contractType => contractType.UpdatedAt))
             .ForMember(contractTypeVm => contractTypeVm.DeletedAt,
                 opt => opt.MapFrom(contractType => contractType.DeletedAt))
             .ForMember(contractTypeVm => contractTypeVm.IsDeleted,
                 opt => opt.MapFrom(contractType => contractType.IsDeleted));
        }
    }
}
