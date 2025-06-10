﻿using AutoMapper;
using REEP.Application.Common.Mappings;

namespace REEP.Application.Features.StatusFeatures.StatusTypeFeatures.StatusTypes.Commands.CreateStatusType
{
    public class CreateUserTypeDto : IMapWith<CreateUserTypeCommand>
    {
        public string Type { get; set; } = null!;
        public bool IsDeleted { get; set; } 

        public void Mapping(Profile profile)
        {
            profile.CreateMap<CreateUserTypeDto, CreateUserTypeCommand>();
        }
    }
}
