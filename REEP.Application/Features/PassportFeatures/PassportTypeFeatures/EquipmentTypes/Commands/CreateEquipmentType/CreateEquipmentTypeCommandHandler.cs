using MediatR;
using Microsoft.Extensions.Logging;
using REEP.Application.Interfaces.InterfaceDbContexts;
using REEP.Domain.Models.ContractModels.ContractTypeModels;

namespace REEP.Application.Features.EquipmentFeatures.EquipmentTypeFeatures.EquipmentTypes.Commands.CreateEquipmentType
{
    public class CreateStatusTypeCommandHandler
        : IRequestHandler<CreateStatusTypeCommand, Guid>
    {
        private readonly IReepDbContext _context;
        private readonly ILogger<CreateStatusTypeCommandHandler> _logger;

        public CreateStatusTypeCommandHandler(
            IReepDbContext context,
            ILogger<CreateStatusTypeCommandHandler> logger) =>
            (_context, _logger) = (context, logger);

        public async Task<Guid> Handle(CreateStatusTypeCommand request,
            CancellationToken cancellationToken)
        {
            var entity = new SupplierType
            {
                Type = request.Type,
                CreatedAt = DateTime.UtcNow,
                IsDeleted = request.IsDeleted
            };

            await _context.SupplierTypes.AddAsync(entity, cancellationToken);
            await _context.SaveChangesAsync(cancellationToken);

            return entity.Id;
        }
    }
}
