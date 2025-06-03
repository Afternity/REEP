using Microsoft.EntityFrameworkCore;
using REEP.Application.Interfaces.InterfaceRepositories;
using REEP.Domain.Models.ContractModels.ContractTypeModels;
using REEP.Persistence.Data.DbContexts;

namespace REEP.Persistence.Data.Repositories
{
    public class ContractTypeRepository : IContractTypeRepository
    {
        private readonly ReepDbContext _context;

        public ContractTypeRepository(ReepDbContext context) =>
            _context = context;


        public async Task CreateAsync(ContractType contractType, CancellationToken cancellationToken)
        {
            await _context.ContractTypes.AddAsync(contractType, cancellationToken);
            await _context.SaveChangesAsync(cancellationToken);
        }

        public async Task DeleteAsync(ContractType contractType)
        {
            _context.ContractTypes.Remove(contractType);
            await _context.SaveChangesAsync();
        }

        public async Task<ContractType> GetByIdAsync(Guid id, CancellationToken cancellationToken)
        {
            return await _context.ContractTypes.FirstOrDefaultAsync(x => x.Id == id, cancellationToken);
        }

        public async Task UpdateAsync(ContractType contractType)
        {
            _context.ContractTypes.Update(contractType);
            await _context.SaveChangesAsync();
        }
    }
}
