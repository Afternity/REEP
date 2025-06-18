using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using REEP.Application.Common.Exceptions;
using REEP.Application.Interfaces.InterfaceDbContexts;

namespace REEP.Application.Features.UserFeatures.Users.Commands.UpdateUser
{
    public class UpdateUserCommandHandler
        : IRequestHandler<UpdateUserCommand, Unit>
    {
        private readonly IReepDbContext _context;
        private readonly ILogger<UpdateUserCommandHandler> _logger;

        public UpdateUserCommandHandler(
            IReepDbContext context,
            ILogger<UpdateUserCommandHandler> logger) =>
            (_context, _logger) = (context, logger);

        public async Task<Unit> Handle(UpdateUserCommand request,
            CancellationToken cancellationToken)
        {
            var parent = await _context.UserTypes
                .FirstOrDefaultAsync(userType =>
                    userType.Type == request.Type,
                    cancellationToken);

            if (parent == null)
                throw new NotFoundException(nameof(parent), request.Type);


            var entity = await _context.Users
                .FirstOrDefaultAsync(user =>
                    user.Id == request.Id,
                    cancellationToken);

            if (entity == null)
                throw new NotFoundException(nameof(entity), request.Id);

            entity.FirstName = request.FirstName;
            entity.SecondName = request.SecondName;
            entity.LastName = request.LastName;
            entity.Email = request.Email;
            entity.OtherContacts = request.OtherContacts;
            entity.Password = request.Password;
            entity.UpdatedAt = DateTime.UtcNow;
            entity.UserTypeId = parent.Id;
            
            _context.Users.Update(entity);
            await _context.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }
    }
}