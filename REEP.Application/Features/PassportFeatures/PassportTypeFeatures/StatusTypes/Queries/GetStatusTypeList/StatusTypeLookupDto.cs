using AutoMapper;
using REEP.Application.Common.Mappings;
using REEP.Domain.Models.PassportModels.PassportTypeModels;

namespace REEP.Application.Features.StatusFeatures.StatusTypesFeatures.StatusTypes.Queries.GetStatusTypeList
{
    public class UserTypeLookupDto : IMapWith<StatusType>
    {
        public Guid Id { get; set; }
        public string Type { get; set; } = null!;

        public void Mapping(Profile profile)
        {
            profile.CreateMap<StatusType, UserTypeLookupDto>();
        }
    }
}
