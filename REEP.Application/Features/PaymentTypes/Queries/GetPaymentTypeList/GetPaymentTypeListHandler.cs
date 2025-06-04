using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using REEP.Application.Features.ContractTypes.Queries.GetContractTypesDetails;
using REEP.Application.Features.ContractTypes.Queries.GetContractTypesList;
using REEP.Application.Interfaces.InterfaceDbContexts;

namespace REEP.Application.Features.PaymentTypes.Queries.GetPaymentTypeList
{
    public class GetPaymentTypeListHandler
        : IRequestHandler<GetPaymentTypeListQuery, PaymentTypeListVm>
    {
        private readonly IReepDbContext _context;
        private readonly IMapper _mapper;
        private readonly ILogger<GetPaymentTypeListHandler> _logger;

        public GetPaymentTypeListHandler(
            IReepDbContext context, IMapper mapper, ILogger<GetPaymentTypeListHandler> logger) =>
            (_context, _mapper, _logger) = (context, mapper, logger);

        public async Task<PaymentTypeListVm> Handle(GetPaymentTypeListQuery request,
            CancellationToken cancellationToken)
        {
            _logger.LogInformation($"request.IsDeleted = {request.IsDeleted}");
            var entities = await _context.PaymentTypes
                .Where(paymentType => paymentType.IsDeleted == request.IsDeleted)
                .ProjectTo<PaymentTypeLookupDto>(_mapper.ConfigurationProvider)
                .ToListAsync(cancellationToken);

            return new PaymentTypeListVm { PaymentTypes = entities };
        }
    }
}
