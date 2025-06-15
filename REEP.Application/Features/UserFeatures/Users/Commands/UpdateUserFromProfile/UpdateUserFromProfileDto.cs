using AutoMapper;
using REEP.Application.Common.Mappings;

namespace REEP.Application.Features.UserFeatures.Users.Commands.UpdateUserFromProfile
{
    public class UpdateUserFromProfileDto
        : IMapWith<UpdateUserFromProfileCommand>
    {
        public Guid Id { get; set; }
        public string FirstName { get; set; } = null!;
        public string SecondName { get; set; } = null!;
        public string? LastName { get; set; }
        public string Email { get; set; } = null!;
        public string? OtherContacts { get; set; }
        public string Password { get; set; } = null!;

        public void Mapping(Profile profile)
        {
            profile.CreateMap<UpdateUserFromProfileDto, UpdateUserFromProfileCommand>();
        }
    }
}
