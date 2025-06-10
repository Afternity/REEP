using AutoMapper;
using REEP.Application.Common.Mappings;
using REEP.Domain.Models.UserModels.UserTypeModels;

namespace REEP.Application.Features.UserFeatures.UserTypesFeatures.UserTypes.Queries.GetUserTypeDetails
{
    public class UserTypeDetailsVm : IMapWith<UserType>
    {
        public string Type { get; set; } = null!;
        public DateTime CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public DateTime? DeletedAt { get; set; }
        public bool IsDeleted { get; set; } = false;

        public void Mapping(Profile profile)
        {
            profile.CreateMap<UserType, UserTypeDetailsVm>();
        }
    }
}
