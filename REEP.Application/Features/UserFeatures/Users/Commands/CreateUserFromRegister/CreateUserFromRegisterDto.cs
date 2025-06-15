using AutoMapper;
using REEP.Application.Common.Mappings;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace REEP.Application.Features.UserFeatures.Users.Commands.CreateUserFromRegister
{
    public class CreateUserFromRegisterDto
        : IMapWith<CreateUserFromRegisterCommand>
    {
        public string FirstName { get; set; } = null!;
        public string SecondName { get; set; } = null!;
        public string? LastName { get; set; }
        public string Email { get; set; } = null!;
        public string? OtherContacts { get; set; }
        public string Password { get; set; } = null!;

        public void Mapping(Profile profile)
        {
            profile.CreateMap<CreateUserFromRegisterDto, CreateUserFromRegisterCommand>();
        }
    }
}
