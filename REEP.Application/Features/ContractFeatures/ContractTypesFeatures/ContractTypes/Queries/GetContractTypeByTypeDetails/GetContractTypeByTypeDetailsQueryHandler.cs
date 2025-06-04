using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using REEP.Application.Interfaces.InterfaceDbContexts;
using REEP.Application.Common.Exceptions;
using AutoMapper;

namespace REEP.Application.Features.ContractFeatures.ContractTypesFeatures.ContractTypes.Queries.GetContractTypeByTypeDetails
{
    public class GetContractTypeByTypeDetailsQueryHandler
        : IRequestHandler<GetContractTypeByTypeDetailsQuery, ContractTypeByTypeDetailsVm>
    {
        private readonly IReepDbContext _context;
        private readonly IMapper _mapper;
        private readonly ILogger<GetContractTypeByTypeDetailsQueryHandler> _logger;

        public GetContractTypeByTypeDetailsQueryHandler(
            IReepDbContext context,
            IMapper mapper,
            ILogger<GetContractTypeByTypeDetailsQueryHandler> logger) =>
            (_context, _mapper, _logger) = (context, mapper, logger);

        public async Task<ContractTypeByTypeDetailsVm> Handle(GetContractTypeByTypeDetailsQuery request, CancellationToken cancellationToken)
        {
            var entity = await _context.ContractTypes.FirstOrDefaultAsync(contractType =>
                contractType.Type == request.Type, cancellationToken);

            if (entity == null || entity.Type != request.Type)
                throw new NotFoundException(nameof(entity), request.Type);

            return _mapper.Map<ContractTypeByTypeDetailsVm>(entity);
        }
    }
}
