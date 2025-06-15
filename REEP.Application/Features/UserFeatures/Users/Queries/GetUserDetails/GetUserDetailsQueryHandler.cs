using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using REEP.Application.Common.Exceptions;
using REEP.Application.Interfaces.InterfaceDbContexts;

namespace REEP.Application.Features.UserFeatures.Users.Queries.GetUserDetails
{
    public class GetUserDetailsQueryHandler
        : IRequestHandler<GetUserDetailsQuery, UserDetailsVm>
    {
        private readonly IReepDbContext _context;
        private readonly IMapper _mapper;
        private readonly ILogger<GetUserDetailsQueryHandler> _logger;

        public GetUserDetailsQueryHandler(
            IReepDbContext context,
            IMapper mapper,
            ILogger<GetUserDetailsQueryHandler> logger) =>
            (_context, _mapper, _logger) = (context, mapper, logger);

        public async Task<UserDetailsVm> Handle(GetUserDetailsQuery request, 
            CancellationToken cancellationToken)
        {
            var entity = await _context.Users
                .Include(parent =>
                    parent.UserType)
                .FirstOrDefaultAsync(user => 
                    user.Id == request.Id,
                    cancellationToken);

            if (entity == null)
                throw new NotFoundException(nameof(entity), request.Id);

            return _mapper.Map<UserDetailsVm>(entity);
        }
    }
}
