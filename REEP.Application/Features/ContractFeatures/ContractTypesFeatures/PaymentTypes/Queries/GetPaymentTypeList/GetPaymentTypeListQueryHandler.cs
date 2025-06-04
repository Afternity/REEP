using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using REEP.Application.Interfaces.InterfaceDbContexts;

namespace REEP.Application.Features.ContractFeatures.ContractTypesFeatures.PaymentTypes.Queries.GetPaymentTypeList
{
    public class GetPaymentTypeListQueryHandler
        : IRequestHandler<GetPaymentTypeListQuery, PaymentTypeListVm>
    {
        private readonly IReepDbContext _context;
        private readonly IMapper _mapper;
        private readonly ILogger<GetPaymentTypeListQueryHandler> _logger;

        public GetPaymentTypeListQueryHandler(
            IReepDbContext context, IMapper mapper, ILogger<GetPaymentTypeListQueryHandler> logger) =>
            (_context, _mapper, _logger) = (context, mapper, logger);

        public async Task<PaymentTypeListVm> Handle(GetPaymentTypeListQuery request,
            CancellationToken cancellationToken)
        {
            var entities = await _context.PaymentTypes
                .Where(paymentType => paymentType.IsDeleted == request.IsDeleted)
                .ProjectTo<PaymentTypeLookupDto>(_mapper.ConfigurationProvider)
                .ToListAsync(cancellationToken);

            return new PaymentTypeListVm { PaymentTypes = entities };
        }
    }
}
