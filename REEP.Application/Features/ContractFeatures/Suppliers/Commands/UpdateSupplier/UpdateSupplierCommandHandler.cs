using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using REEP.Application.Interfaces.InterfaceDbContexts;
using REEP.Application.Common.Exceptions;

namespace REEP.Application.Features.ContractFeatures.Suppliers.Commands.UpdateSupplier
{
    public class UpdateSupplierCommandHandler
        : IRequestHandler<UpdateSupplierCommand, Unit>
    {
        private readonly IReepDbContext _context;
        private readonly ILogger<UpdateSupplierCommandHandler> _logger;

        public UpdateSupplierCommandHandler(
            IReepDbContext context,
            ILogger<UpdateSupplierCommandHandler> logger) =>
            (_context, _logger) = (context, logger);

        public async Task<Unit> Handle(UpdateSupplierCommand request, CancellationToken cancellationToken)
        {
            var entity = await _context.Suppliers
                .FirstOrDefaultAsync(supplier => supplier.Id == request.Id, cancellationToken);

            if (entity == null) 
                throw new NotFoundException(nameof(entity), request.Id);

            var parent = await _context.SupplierTypes
                .FirstOrDefaultAsync(supplierType => supplierType.Type == request.Type, cancellationToken);

            if (parent == null)
                throw new NotFoundException(nameof(parent), request.Type);

            entity.FirstName = request.FirstName;
            entity.SecondName = request.SecondName;
            entity.LastName = request.LastName;
            entity.OtherName = request.OtherName;  
            entity.Email = request.Email;
            entity.Number = request.Number;
            entity.OtherContacts = request.OtherContacts;
            entity.UpdatedAt = DateTime.UtcNow;
            entity.SupplierTypeId = parent.Id;

            _context.Suppliers.Update(entity);
            await _context.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }
    }
}
