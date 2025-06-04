using REEP.Application.Common.Exceptions;
using MediatR;
using Microsoft.EntityFrameworkCore;
using REEP.Application.Interfaces.InterfaceDbContexts;

namespace REEP.Application.Features.ContractFeatures.ContractTypesFeatures.ContractTypes.Commands.SoftDeleteContractType
{
    public class SoftDeleteContractTypeCommandHandler
        : IRequestHandler<SoftDeleteContractTypeCommand, Unit>
    {
        private readonly IReepDbContext _context;

        public SoftDeleteContractTypeCommandHandler(IReepDbContext context) =>
            _context = context;

        public async Task<Unit> Handle(SoftDeleteContractTypeCommand request,
            CancellationToken cancellationToken)
        {
            var entity = await _context.ContractTypes.FirstOrDefaultAsync(contractType =>
                contractType.Id == request.Id, cancellationToken);

            if (entity == null || entity.Id != request.Id)
                throw new NotFoundException(nameof(entity), request.Id);

            entity.DeletedAt = DateTime.UtcNow;
            entity.IsDeleted = request.IsDeleted;

            await _context.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }
    }
}
