﻿using AutoMapper;
using REEP.Application.Common.Mappings;
using REEP.Domain.Models.UserModels.UserTypeModels;

namespace REEP.Application.Features.UserFeatures.UserTypeFeatures.UserTypes.Queries.GetUserTypeByTypeDetails
{
    public class UserTypeByTypeDetailsVm
        : IMapWith<UserType>
    {
        public string Type { get; set; } = null!;
        public DateTime CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public DateTime? DeletedAt { get; set; }
        public bool IsDeleted { get; set; } = false;

        public void Mapping(Profile profile)
        {
            profile.CreateMap<UserType, UserTypeByTypeDetailsVm>();
        }
    }
}
