using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using REEP.Application.Common.Exceptions;
using REEP.Application.Interfaces.InterfaceDbContexts;

namespace REEP.Application.Features.UserFeatures.Users.Queries.GetUserFromAuthDetails
{
    public class GetUserFromAuthDetailsQueryHandler
        : IRequestHandler<GetUserFromAuthDetailsQuery, UserFromAuthDetailsVm>
    {
        private readonly IReepDbContext _context;
        private readonly IMapper _mapper;
        private readonly ILogger<GetUserFromAuthDetailsQueryHandler> _logger;

        public GetUserFromAuthDetailsQueryHandler(
            IReepDbContext context,
            IMapper mapper,
            ILogger<GetUserFromAuthDetailsQueryHandler> logger) =>
            (_context, _mapper, _logger) = (context, mapper, logger);

        public async Task<UserFromAuthDetailsVm> Handle(
            GetUserFromAuthDetailsQuery request,
            CancellationToken cancellationToken)
        {
            var entity = await _context.Users
                .Include(parent =>
                    parent.UserType)
                .FirstOrDefaultAsync(user =>
                    user.Password == request.Password
                    && user.Email == request.Email,
                    cancellationToken);

            if (entity == null)
                throw new NotFoundException(nameof(entity), request.Password);

            return _mapper.Map<UserFromAuthDetailsVm>(entity);
        }
    }
}
