using AutoMapper;
using REEP.Application.Common.Mappings;

namespace REEP.Application.Features.EquipmentFeatures.EquipmentTypeFeatures.EquipmentTypes.Commands.SoftDeleteEquipmentType
{
    public class SoftDeleteStatusTypeDto : IMapWith<SoftDeleteStatusTypeCommand>
    {
        public Guid Id { get; set; }
        public bool IsDeleted { get; set; } = true;
        public void Mapping(Profile profile)
        {
            profile.CreateMap<SoftDeleteStatusTypeDto, SoftDeleteStatusTypeCommand>();
        }
    }
}
