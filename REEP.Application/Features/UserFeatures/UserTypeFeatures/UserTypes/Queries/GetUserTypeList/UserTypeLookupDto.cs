using AutoMapper;
using REEP.Application.Common.Mappings;
using REEP.Domain.Models.UserModels.UserTypeModels;


namespace REEP.Application.Features.UserFeatures.UserTypeFeatures.UserTypes.Queries.GetUserTypeList
{
    public class UserTypeLookupDto
        : IMapWith<UserType>
    {
        public Guid Id { get; set; }
        public string Type { get; set; } = null!;

        public void Mapping(Profile profile)
        {
            profile.CreateMap<UserType, UserTypeLookupDto>();
        }
    }
}
