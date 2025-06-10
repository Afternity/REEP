using AutoMapper;
using REEP.Application.Common.Mappings;

namespace REEP.Application.Features.EquipmentFeatures.EquipmentTypeFeatures.EquipmentTypes.Commands.UpdateEquipmentType
{
    public class UpdateStatusTypeDto : IMapWith<UpdateStatusTypeCommand>
    {
        public Guid Id { get; set; }
        public string Type { get; set; } = null!;

        public void Mapping(Profile profile)
        {
            profile.CreateMap<UpdateStatusTypeDto, UpdateStatusTypeCommand>();
        }
    }
}
