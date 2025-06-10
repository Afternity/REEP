using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using REEP.Application.Interfaces.InterfaceDbContexts;

namespace REEP.Application.Features.UserFeatures.UserTypesFeatures.UserTypes.Queries.GetUserTypeList
{
    public class GetUserTypeListQueryHandler
        : IRequestHandler<GetUserTypeListQuery, UserTypeListVm>
    {
        private readonly IReepDbContext _context;
        private readonly IMapper _mapper;
        private readonly ILogger<GetUserTypeListQueryHandler> _logger;

        public GetUserTypeListQueryHandler(
            IReepDbContext context, IMapper mapper, ILogger<GetUserTypeListQueryHandler> logger) =>
            (_context, _mapper, _logger) = (context, mapper, logger);

        public async Task<UserTypeListVm> Handle(GetUserTypeListQuery request,
            CancellationToken cancellationToken)
        {
            var entities = await _context.SupplierTypes
                .Where(supplierTypes =>supplierTypes.IsDeleted == request.IsDeleted)
                .ProjectTo<UserTypeLookupDto>(_mapper.ConfigurationProvider)
                .ToListAsync(cancellationToken);

            return new UserTypeListVm { EquipmentTypes = entities };
        }
    }
}
