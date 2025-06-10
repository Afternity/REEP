using AutoMapper;
using REEP.Application.Common.Mappings;
using REEP.Domain.Models.PassportModels.PassportTypeModels;

namespace REEP.Application.Features.StatusFeatures.StatusTypesFeatures.StatusTypes.Queries.GetStatusTypeDetails
{
    public class UserTypeDetailsVm : IMapWith<StatusType>
    {
        public string Type { get; set; } = null!;
        public DateTime CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public DateTime? DeletedAt { get; set; }
        public bool IsDeleted { get; set; } = false;

        public void Mapping(Profile profile)
        {
            profile.CreateMap<StatusType, UserTypeDetailsVm>();
        }
    }
}
