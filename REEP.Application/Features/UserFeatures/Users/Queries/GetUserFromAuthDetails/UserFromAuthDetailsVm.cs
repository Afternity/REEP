using AutoMapper;
using REEP.Application.Common.Mappings;
using REEP.Domain.Models.UserModels;

namespace REEP.Application.Features.UserFeatures.Users.Queries.GetUserFromAuthDetails
{
    public class UserFromAuthDetailsVm
        : IMapWith<User>
    {
        public string FirstName { get; set; } = null!;
        public string SecondName { get; set; } = null!;
        public string? LastName { get; set; }
        public string Email { get; set; } = null!;
        public string? OtherContacts { get; set; }
        public string Password { get; set; } = null!;
        public DateTime CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public DateTime? DeletedAt { get; set; }
        public bool IsDeleted { get; set; }
        public string Type { get; set; } = null!;

        public void Mapping(Profile profile)
        {
            profile.CreateMap<User, UserFromAuthDetailsVm>()
                 .ForMember(destination => destination.Type,
                    options => options.MapFrom(soure => soure.UserType.Type));
        }
    }
}
