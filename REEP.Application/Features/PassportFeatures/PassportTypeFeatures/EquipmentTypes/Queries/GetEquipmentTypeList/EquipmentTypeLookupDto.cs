using AutoMapper;
using REEP.Application.Common.Mappings;
using REEP.Domain.Models.PassportModels.PassportTypeModels;

namespace REEP.Application.Features.EquipmentFeatures.EquipmentTypesFeatures.EquipmentTypes.Queries.GetEquipmentTypeList
{
    public class StatusTypeLookupDto : IMapWith<EquipmentType>
    {
        public Guid Id { get; set; }
        public string Type { get; set; } = null!;

        public void Mapping(Profile profile)
        {
            profile.CreateMap<EquipmentType, StatusTypeLookupDto>();
        }
    }
}
