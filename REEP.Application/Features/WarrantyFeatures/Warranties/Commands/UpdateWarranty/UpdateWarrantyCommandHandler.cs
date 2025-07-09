using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using REEP.Application.Common.Exceptions;
using REEP.Application.Interfaces.InterfaceDbContexts;

namespace REEP.Application.Features.WarrantyFeatures.Warranties.Commands.UpdateWarranty
{
    public class UpdateWarrantyCommandHandler
        : IRequestHandler<UpdateWarrantyCommand, Unit>
    {
        private readonly IReepDbContext _context;
        private readonly ILogger<UpdateWarrantyCommandHandler> _logger;

        public UpdateWarrantyCommandHandler(
            IReepDbContext context,
            ILogger<UpdateWarrantyCommandHandler> logger)
        {
            _context = context;
            _logger = logger;
        }

        public async Task<Unit> Handle(
            UpdateWarrantyCommand request,
            CancellationToken cancellationToken)
        {
            _logger.LogInformation($"Вход в {nameof(UpdateWarrantyCommandHandler)}");

            var warranty = await _context.Warranties
                .FirstOrDefaultAsync(entity =>
                    entity.Id == request.Id,
                    cancellationToken);

            if (warranty == null) 
                throw new NotFoundException(nameof(warranty), request.Id);

            _logger.LogInformation($"Был найден: {nameof(warranty)}");

            warranty.Name = request.Name;
            warranty.Description = request.Description;
            warranty.StartedAt = request.StartedAt;
            warranty.EndedAt = request.EndedAt;
            warranty.UpdatedAt = DateTime.UtcNow;
            warranty.ContractId = request.ContractId;
            warranty.WarrantyTypeId = request.WarrantyTypeId;

            _logger.LogInformation($"Сборка {nameof(warranty)} завершина");

            _context.Warranties.Update(warranty);
            await _context.SaveChangesAsync(cancellationToken);

            _logger.LogInformation($"Выход из {nameof(UpdateWarrantyCommandHandler)}");

            return Unit.Value;
        }
    }
}
