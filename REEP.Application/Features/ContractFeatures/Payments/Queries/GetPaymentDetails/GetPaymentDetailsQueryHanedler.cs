using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using REEP.Application.Interfaces.InterfaceDbContexts;
using REEP.Application.Common.Exceptions;

namespace REEP.Application.Features.ContractFeatures.Payments.Queries.GetPaymentDetails
{
    public class GetPaymentDetailsQueryHanedler
        : IRequestHandler<GetPaymentDetailsQuery, PaymentDetailsVm>
    {
        private readonly IReepDbContext _context;
        private readonly IMapper _mapper;
        private readonly ILogger<GetPaymentDetailsQueryHanedler> _logger;

        public GetPaymentDetailsQueryHanedler(
            IReepDbContext context,
            IMapper mapper,
            ILogger<GetPaymentDetailsQueryHanedler> logger) =>
            (_context, _mapper, _logger) = (context, mapper, logger);

        public async Task<PaymentDetailsVm> Handle(GetPaymentDetailsQuery request,
            CancellationToken cancellationToken)
        {
            var entity = await _context.Payments
                .Include(parent => parent.PaymentType)
                .FirstOrDefaultAsync(payment => payment.Id == request.Id, cancellationToken);

            if (entity == null)
                throw new NotFoundException(nameof(entity), request.Id);
            _logger.LogInformation($"entity.FirstPay = {entity.FirstPay} and entity.LastPay = {entity.LastPay}");
            return _mapper.Map<PaymentDetailsVm>(entity);
        }
    }
}
