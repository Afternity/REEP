using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using REEP.Application.Features.ContractFeatures.Payments.Queries.GetPaymentDetails;
using REEP.Application.Interfaces.InterfaceDbContexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace REEP.Application.Features.ContractFeatures.Payments.Queries.GetPaymentList
{
    public class GetPaymentListQueryHandler
        : IRequestHandler<GetPaymentListQuery, PaymentListVm>
    {
        private readonly IReepDbContext _context;
        private readonly IMapper _mapper;
        private readonly ILogger<GetPaymentListQueryHandler> _logger;

        public GetPaymentListQueryHandler(
            IReepDbContext context,
            IMapper mapper,
            ILogger<GetPaymentListQueryHandler> logger) =>
            (_context, _mapper, _logger) = (context, mapper, logger);

        public async Task<PaymentListVm> Handle(GetPaymentListQuery request,
            CancellationToken cancellationToken)
        {
            var entities = await _context.Payments
                .Include(parent => parent.PaymentType)
                .Where(payment => payment.IsDeleted == request.IsDeleted)
                .ProjectTo<PaymentLookupDto>(_mapper.ConfigurationProvider)
                .ToListAsync(cancellationToken);

            return new PaymentListVm { Payments = entities };
        }
    }
}
