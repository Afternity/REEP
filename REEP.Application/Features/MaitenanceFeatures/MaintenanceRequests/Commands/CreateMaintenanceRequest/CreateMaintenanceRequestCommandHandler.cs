using MediatR;
using Microsoft.Extensions.Logging;
using REEP.Application.Interfaces.InterfaceDbContexts;
using REEP.Domain.Models.MaintenanceModels;

namespace REEP.Application.Features.MaitenanceFeatures.MaintenanceRequests.Commands.CreateMaintenanceRequest
{
    public class CreateMaintenanceRequestCommandHandler
        : IRequestHandler<CreateMaintenanceRequestCommand, Unit>
    {
        private readonly IReepDbContext _context;
        private readonly ILogger<CreateMaintenanceRequestCommandHandler> _logger;

        public CreateMaintenanceRequestCommandHandler(
            IReepDbContext context,
            ILogger<CreateMaintenanceRequestCommandHandler> logger)
        {
            _context = context;
            _logger = logger;
        }
        public async Task<Unit> Handle(
            CreateMaintenanceRequestCommand request,
            CancellationToken cancellationToken)
        {
            var entity = new MaintenanceRequest()
            {
                Id = Guid.NewGuid(),
                IsActive = false,
                Description = request.Description,
                ReceiptedAt = DateTime.UtcNow,
                CreatedAt = DateTime.UtcNow,
                IsDeleted = false,
                CreateByUserId = request.CreateByUserId
            };

            await _context.MaintenanceRequests.AddAsync(entity, cancellationToken);
            await _context.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }
    }
}
