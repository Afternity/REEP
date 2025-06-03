using REEP.Application.Common.Exceptions;
using REEP.Domain.Models.ContractModels.ContractTypeModels;
using MediatR;
using REEP.Application.Interfaces.InterfaceRepositories;
using REEP.Application.Interfaces.InterfaceDbContexts;
using Microsoft.EntityFrameworkCore;

namespace REEP.Application.Features.ContractTypes.Commands.HardDeleteContractType
{
    public class HardDeleteContractTypeHandler : IRequestHandler<HardDeleteContractTypeCommand, Unit>
    {
        private readonly IReepDbContext _context;

        public HardDeleteContractTypeHandler(IReepDbContext context) =>
            _context = context;


        public async Task<Unit> Handle(HardDeleteContractTypeCommand request,
            CancellationToken cancellationToken)
        {
            var entiry = await _context.ContractTypes.FirstOrDefaultAsync(contractType =>
                contractType.Id == request.Id, cancellationToken);

            if (entiry == null || entiry.Id != request.Id)
                throw new NotFoundException(nameof(ContractType), request.Id);

            _context.ContractTypes.Remove(entiry);
            await _context.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }
    }
}
