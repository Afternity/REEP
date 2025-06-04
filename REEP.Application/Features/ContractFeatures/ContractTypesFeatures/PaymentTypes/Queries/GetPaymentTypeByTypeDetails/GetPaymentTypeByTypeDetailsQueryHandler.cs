using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using REEP.Application.Common.Exceptions;
using REEP.Application.Interfaces.InterfaceDbContexts;

namespace REEP.Application.Features.ContractFeatures.ContractTypesFeatures.PaymentTypes.Queries.GetPaymentTypeByTypeDetails
{
    internal class GetPaymentTypeByTypeDetailsQueryHandler
        : IRequestHandler<GetPaymentTypeByTypeDetailsQuery, PaymentTypeByTypeDelailsVm>
    {
        private readonly IReepDbContext _context;
        private readonly IMapper _mapper;
        private readonly ILogger<GetPaymentTypeByTypeDetailsQueryHandler> _logger;

        public GetPaymentTypeByTypeDetailsQueryHandler(
            IReepDbContext context,
            IMapper mapper,
            ILogger<GetPaymentTypeByTypeDetailsQueryHandler> logger) =>
            (_context, _mapper, _logger) = (context, mapper, logger);

        public async Task<PaymentTypeByTypeDelailsVm> Handle(GetPaymentTypeByTypeDetailsQuery request,
            CancellationToken cancellationToken)
        {
            var entity = await _context.PaymentTypes.FirstOrDefaultAsync(paymentType =>
                paymentType.Type == request.Type, cancellationToken);

            if (entity == null || entity.Type != request.Type)
                throw new NotFoundException(nameof(entity), request.Type);

            return _mapper.Map<PaymentTypeByTypeDelailsVm>(entity);
        }
    }
}
