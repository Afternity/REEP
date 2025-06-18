using AutoMapper;
using REEP.Application.Common.Mappings;

namespace REEP.Application.Features.MaitenanceFeatures.MaintenanceRequests.Commands.CreateMaintenanceRequest
{
    public class CreateMaintenanceRequestDto
        : IMapWith<CreateMaintenanceRequestCommand>
    {
        public string Description { get; set; } = null!;
        public Guid CreateByUserId { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<CreateMaintenanceRequestDto, CreateMaintenanceRequestCommand>();
        }
    }
}
