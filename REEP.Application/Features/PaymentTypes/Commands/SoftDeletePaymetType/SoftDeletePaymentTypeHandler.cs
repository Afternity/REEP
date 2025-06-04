using MediatR;
using Microsoft.EntityFrameworkCore;
using REEP.Application.Interfaces.InterfaceDbContexts;
using REEP.Application.Common.Exceptions;

namespace REEP.Application.Features.PaymentTypes.Commands.SoftDeletePaymetType
{
    public class SoftDeletePaymentTypeHandler
        : IRequestHandler<SoftDeletePaymentTypeCommand, Unit>

    {
        private readonly IReepDbContext _context;

        public SoftDeletePaymentTypeHandler(IReepDbContext context) =>
            _context = context;

        public async Task<Unit> Handle(SoftDeletePaymentTypeCommand request,
            CancellationToken cancellationToken)
        {
            var entity = await _context.PaymentTypes.FirstOrDefaultAsync(paymentType =>
                paymentType.Id == request.Id, cancellationToken);

            if (entity == null || entity.Id != request.Id) 
                throw new NotFoundException(nameof(entity), request.Id);

            entity.IsDeleted = request.IsDeleted;
            entity.DeletedAt = DateTime.UtcNow;

            _context.PaymentTypes.Update(entity);
            await _context.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }
    }
}
