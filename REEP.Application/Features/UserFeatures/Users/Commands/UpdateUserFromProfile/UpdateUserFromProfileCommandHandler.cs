using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using REEP.Application.Common.Exceptions;
using REEP.Application.Interfaces.InterfaceDbContexts;

namespace REEP.Application.Features.UserFeatures.Users.Commands.UpdateUserFromProfile
{
    public class UpdateUserFromProfileCommandHandler
        : IRequestHandler<UpdateUserFromProfileCommand, Unit>
    {
        private readonly IReepDbContext _context;
        private readonly ILogger<UpdateUserFromProfileCommandHandler> _logger;

        public UpdateUserFromProfileCommandHandler(
            IReepDbContext context,
            ILogger<UpdateUserFromProfileCommandHandler> logger) =>
            (_context, _logger) = (context, logger);

        public async Task<Unit> Handle(UpdateUserFromProfileCommand request,
            CancellationToken cancellationToken)
        {
            var parent = await _context.UserTypes
                .FirstOrDefaultAsync(userType =>
                    userType.Type == "Сотрудник",
                    cancellationToken);

            if (parent == null)
                throw new NotFoundException(nameof(parent), request);

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
            entity.IsDeleted = false;
            entity.UserTypeId = parent.Id;

            await _context.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }
    }
}
