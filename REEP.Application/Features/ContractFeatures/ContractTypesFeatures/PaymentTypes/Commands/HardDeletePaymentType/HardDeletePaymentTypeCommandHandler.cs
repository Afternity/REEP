using MediatR;
using Microsoft.EntityFrameworkCore;
using REEP.Application.Interfaces.InterfaceDbContexts;
using REEP.Application.Common.Exceptions;

namespace REEP.Application.Features.ContractFeatures.ContractTypesFeatures.PaymentTypes.Commands.HardDeletePaymentType
{
    public class HardDeletePaymentTypeCommandHandler
        : IRequestHandler<HardDeletePaymentTypeCommand, Unit>
    {
        private readonly IReepDbContext _context;

        public HardDeletePaymentTypeCommandHandler(IReepDbContext context) =>
            _context = context;

        public async Task<Unit> Handle(HardDeletePaymentTypeCommand request,
            CancellationToken cancellationToken)
        {
            var entity = await _context.PaymentTypes.FirstOrDefaultAsync(paymentType =>
                paymentType.Id == request.Id, cancellationToken);

            if (entity == null || entity.Id != request.Id)
                throw new NotFoundException(nameof(entity), request.Id);

            _context.PaymentTypes.Remove(entity);
            await _context.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }
    }
}
