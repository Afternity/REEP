using MediatR;
using REEP.Application.Interfaces.InterfaceDbContexts;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using Microsoft.EntityFrameworkCore;

namespace REEP.Application.Features.ContractTypes.Queries.GetContractTypeList
{
    public class GetContractTypesListHandler
        : IRequestHandler<GetContractTypesListQuery, ContractTypeListVm>
    {
        private readonly IReepDbContext _context;
        private readonly IMapper _mapper;

        public GetContractTypesListHandler(
            IReepDbContext context, IMapper mapper) =>
            (_context, _mapper) = (context, mapper);

        public async Task<ContractTypeListVm> Handle(
            GetContractTypesListQuery request,
            CancellationToken cancellationToken)
        {
            var contractTypesQuary = await _context.ContractTypes
                .Where(note => note.IsDeleted == request.IsDeleted)
                .ProjectTo<ContractTypeLookupDto>(_mapper.ConfigurationProvider)
                .ToListAsync(cancellationToken);

            return new ContractTypeListVm { ContractTypes = contractTypesQuary };
        }
    }
}
