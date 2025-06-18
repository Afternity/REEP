using MediatR;

namespace REEP.Application.Features.MaitenanceFeatures.MaintenanceRequests.Commands.CreateMaintenanceRequest
{
    public class CreateMaintenanceRequestCommand
        : IRequest<Unit>
    {
        public string Description { get; set; } = null!;
        public Guid CreateByUserId { get; set; }
    }
}
