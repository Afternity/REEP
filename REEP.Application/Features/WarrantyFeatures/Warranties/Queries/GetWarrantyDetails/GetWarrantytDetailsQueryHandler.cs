using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using REEP.Application.Common.Exceptions;
using REEP.Application.Interfaces.InterfaceDbContexts;

namespace REEP.Application.Features.WarrantyFeatures.Warranties.Queries.GetWarrantyDetails
{
    public class GetWarrantytDetailsQueryHandler
        : IRequestHandler<GetWarrantyDetailsQuery, WarrantyDetailsVm>
    {
        private readonly IReepDbContext _context;
        private readonly IMapper _mapper;
        private readonly ILogger<GetWarrantytDetailsQueryHandler> _logger;

        public GetWarrantytDetailsQueryHandler(
            IReepDbContext context,
            IMapper mapper,
            ILogger<GetWarrantytDetailsQueryHandler> logger)
        {
            _context = context;
            _mapper = mapper;
            _logger = logger;
        }

        public async Task<WarrantyDetailsVm> Handle(
            GetWarrantyDetailsQuery request,
            CancellationToken cancellationToken)
        {
            _logger.LogInformation($"Вход в {nameof(GetWarrantytDetailsQueryHandler)}");

            var warranty = await _context.Warranties
                .AsNoTracking()
                .Include(parent => parent.Contract)
                    .ThenInclude(parent => parent.ContractType)
                .Include(parent => parent.WarrantyType)
                .FirstOrDefaultAsync(entity =>
                    entity.Id == request.Id,
                    cancellationToken);

            if (warranty == null)
                throw new NotFoundException(nameof(warranty), request.Id);

            _logger.LogInformation($"Выход из {nameof(GetWarrantytDetailsQueryHandler)}");

            return _mapper.Map<WarrantyDetailsVm>(warranty); 
        }
    }
}
