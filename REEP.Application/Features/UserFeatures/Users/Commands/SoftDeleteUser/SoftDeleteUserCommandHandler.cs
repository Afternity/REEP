using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using REEP.Application.Common.Exceptions;
using REEP.Application.Interfaces.InterfaceDbContexts;

namespace REEP.Application.Features.UserFeatures.Users.Commands.SoftDeleteUser
{
    public class SoftDeleteUserCommandHandler
        : IRequestHandler<SoftDeleteUserCommand, Unit>
    {
        private readonly IReepDbContext _context;
        private readonly ILogger<SoftDeleteUserCommandHandler> _logger;

        public SoftDeleteUserCommandHandler(
            IReepDbContext context,
            ILogger<SoftDeleteUserCommandHandler> logger) =>
            (_context, _logger) = (context, logger);

        public async Task<Unit> Handle(SoftDeleteUserCommand request,
            CancellationToken cancellationToken)
        {
            var entity = await _context.Users
                .FirstOrDefaultAsync(user => 
                    user.Id == request.Id,
                    cancellationToken);

            if (entity == null)
                throw new NotFoundException(nameof(entity), request.Id);

            entity.DeletedAt = DateTime.UtcNow;
            entity.IsDeleted = request.IsDeleted;

            _context.Users.Update(entity);
            await _context.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }
    }
}
