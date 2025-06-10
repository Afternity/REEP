using MediatR;
using Microsoft.Extensions.Logging;
using REEP.Application.Interfaces.InterfaceDbContexts;
using REEP.Domain.Models.ContractModels.ContractTypeModels;

namespace REEP.Application.Features.ContractFeatures.ContractTypesFeatures.SupplierTypes.Commands.CreateSupplierType
{
    public class CreateWarrantyTypeCommandHandler
        : IRequestHandler<CreateWarrantyTypeCommand, Guid>
    {
        private readonly IReepDbContext _context;
        private readonly ILogger<CreateWarrantyTypeCommandHandler> _logger;

        public CreateWarrantyTypeCommandHandler(
            IReepDbContext context,
            ILogger<CreateWarrantyTypeCommandHandler> logger) =>
            (_context, _logger) = (context, logger);

        public async Task<Guid> Handle(CreateWarrantyTypeCommand request,
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
