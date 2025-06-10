using MediatR;
using Microsoft.Extensions.Logging;
using REEP.Application.Features.ContractFeatures.ContractTypesFeatures.SupplierTypes.Commands.CreateSupplierType;
using REEP.Application.Interfaces.InterfaceDbContexts;
using REEP.Domain.Models.ContractModels.ContractTypeModels;
using REEP.Domain.Models.WarrantyModels.WarrantyTypeModels;

namespace REEP.Application.Features.WarrantyFeatures.WarrantyTypeFeatures.WarrantyTypes.Commands.CreateWarrantyType
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
            var entity = new WarrantyType
            {
                Type = request.Type,
                CreatedAt = DateTime.UtcNow,
                IsDeleted = request.IsDeleted
            };

            await _context.WarrantyTypes.AddAsync(entity, cancellationToken);
            await _context.SaveChangesAsync(cancellationToken);

            return entity.Id;
        }
    }
}
