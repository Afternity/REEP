using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using REEP.Application.Common.Exceptions;
using REEP.Application.Interfaces.InterfaceDbContexts;

namespace REEP.Application.Features.UserFeatures.Users.Commands.HardDeleteUser
{
    public class HardDeleteUserCommandHandler
    {
        private readonly IReepDbContext _context;
        private readonly ILogger<HardDeleteUserCommandHandler> _logger;

        public HardDeleteUserCommandHandler(
            IReepDbContext context,
            ILogger<HardDeleteUserCommandHandler> logger) =>
            (_context, _logger) = (context, logger);

        public async Task<Unit> Handle(HardDeleteUserCommand request,
            CancellationToken cancellationToken)
        {
            var entity = await _context.Users
                .FirstOrDefaultAsync(user =>
                    user.Id == request.Id, 
                    cancellationToken);

            if (entity == null)
                throw new NotFoundException(nameof(entity), request.Id);

            _context.Users.Remove(entity);
            await _context.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }
    }
}
