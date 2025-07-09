using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using REEP.Application.Interfaces.InterfaceDbContexts;

namespace REEP.Application.Features.WarrantyFeatures.Warranties.Queries.GetWarrantyList
{
    public class GetWarrantyListQueryHandler
        : IRequestHandler<GetWarrantyListQuery, WarrantyListVm>
    {
        private readonly IReepDbContext _context;
        private readonly IMapper _mapper;
        private readonly ILogger<GetWarrantyListQueryHandler> _logger;

        public GetWarrantyListQueryHandler(
            IReepDbContext context,
            IMapper mapper,
            ILogger<GetWarrantyListQueryHandler> logger)
        {
            _context = context;
            _mapper = mapper;
            _logger = logger;
        }

        public async Task<WarrantyListVm> Handle(
            GetWarrantyListQuery request,
            CancellationToken cancellationToken)
        {
            _logger.LogInformation($"Вход в {nameof(GetWarrantyListQueryHandler)}");

            var warranties = await _context.Warranties
                .AsNoTracking()
                .Include(parent => parent.Contract)
                    .ThenInclude(parent => parent.ContractType)
                .Include(parent => parent.WarrantyType)
                .Where(entities =>
                    entities.IsDeleted == request.IsDeleted)
                .ProjectTo<WarrantyLookupDto>(_mapper.ConfigurationProvider)
                .ToListAsync(cancellationToken);

            _logger.LogInformation($"Выход из {nameof(GetWarrantyListQueryHandler)}");

            return new WarrantyListVm { Warranties = warranties };
        }
    }
}
