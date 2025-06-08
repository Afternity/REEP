using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using REEP.Application.Interfaces.InterfaceDbContexts;
using REEP.Application.Common.Exceptions;
using REEP.Domain.Models.ContractModels;

namespace REEP.Application.Features.ContractFeatures.Suppliers.Commands.CreateSupplier
{
    public class CreateSupplierCommandHandler
        : IRequestHandler<CreateSupplierCommand, Guid>
    {
        private readonly IReepDbContext _context;
        private readonly ILogger<CreateSupplierCommandHandler> _logger;

        public CreateSupplierCommandHandler(
            IReepDbContext context,
            ILogger<CreateSupplierCommandHandler> logger) =>
            (_context, _logger) = (context, logger);

        public async Task<Guid> Handle(CreateSupplierCommand request, CancellationToken cancellationToken)
        {
            var parent = await _context.SupplierTypes
                .FirstOrDefaultAsync(supplierType => supplierType.Type == request.Type, cancellationToken);

            if (parent == null)
                throw new NotFoundException(nameof(parent), request.Type);

            var entity = new Supplier()
            {
                Id = Guid.NewGuid(),
                FirstName = request.FirstName,
                SecondName = request.LastName,
                LastName = request.LastName,
                OtherName = request.LastName,
                Number = request.Number,
                Email = request.Email,
                OtherContacts = request.OtherContacts,
                CreatedAt = DateTime.UtcNow,
                IsDeleted = request.IsDeleted,
                SupplierTypeId = parent.Id,
            };

            await _context.Suppliers.AddAsync(entity, cancellationToken);
            await _context.SaveChangesAsync(cancellationToken);

            return entity.Id;
        }
    }
}
