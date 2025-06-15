using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using REEP.Application.Common.Exceptions;
using REEP.Application.Features.ContractFeatures.ContractTypesFeatures.SupplierTypes.Commands.SoftDeleteSupplierType;
using REEP.Application.Interfaces.InterfaceDbContexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace REEP.Application.Features.UserFeatures.UserTypeFeatures.UserTypes.Commands.SoftDeleteUserType
{
    public class SoftDeleteUserTypeCommandHandler
        : IRequestHandler<SoftDeleteUserTypeCommand, Unit>
    {
        private readonly IReepDbContext _context;
        private readonly ILogger<SoftDeleteUserTypeCommandHandler> _logger;

        public SoftDeleteUserTypeCommandHandler(
            IReepDbContext context,
            ILogger<SoftDeleteUserTypeCommandHandler> logger) =>
            (_context, _logger) = (context, logger);

        public async Task<Unit> Handle(SoftDeleteUserTypeCommand request,
            CancellationToken cancellationToken)
        {
            var entity = await _context.UserTypes.FirstOrDefaultAsync(userType =>
                userType.Id == request.Id, cancellationToken);

            if (entity == null || entity.Id != request.Id)
                throw new NotFoundException(nameof(entity), request.Id);

            entity.DeletedAt = DateTime.UtcNow;
            entity.IsDeleted = request.IsDeleted;

            _context.UserTypes.Update(entity);
            await _context.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }
    }
}
