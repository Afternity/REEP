using MediatR;
using Microsoft.Extensions.Logging;
using REEP.Application.Interfaces.InterfaceDbContexts;
using REEP.Domain.Models.ContractModels.ContractTypeModels;

namespace REEP.Application.Features.ContractFeatures.ContractTypesFeatures.SupplierTypes.Commands.CreateSupplierType
{
    public class CreateSupplierTypeCommandHandler
        : IRequestHandler<CreateSupplierTypeCommand, Guid>
    {
        private readonly IReepDbContext _context;
        private readonly ILogger<CreateSupplierTypeCommandHandler> _logger;

        public CreateSupplierTypeCommandHandler(
            IReepDbContext context,
            ILogger<CreateSupplierTypeCommandHandler> logger) =>
            (_context, _logger) = (context, logger);

        public async Task<Guid> Handle(CreateSupplierTypeCommand request,
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
