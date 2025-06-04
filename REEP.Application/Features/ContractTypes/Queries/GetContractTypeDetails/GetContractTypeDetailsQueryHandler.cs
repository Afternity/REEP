using REEP.Application.Common.Exceptions;
using REEP.Domain.Models.ContractModels.ContractTypeModels;
using AutoMapper;
using MediatR;
using REEP.Application.Interfaces.InterfaceRepositories;
using Microsoft.Extensions.Logging;
using REEP.Application.Interfaces.InterfaceDbContexts;
using Microsoft.EntityFrameworkCore;

namespace REEP.Application.Features.ContractTypes.Queries.GetContractTypeDetails
{
    public class GetContractTypeDetailsQueryHandler
        : IRequestHandler<GetContractTypeDetailsQuery, ContractTypeDetailsVm>
    {
        private readonly IReepDbContext _context;
        private readonly IMapper _mapper;
        private readonly ILogger<GetContractTypeDetailsQueryHandler> _logger;

        public GetContractTypeDetailsQueryHandler(
            IReepDbContext context, IMapper mapper, ILogger<GetContractTypeDetailsQueryHandler> logger) =>
            (_context, _mapper, _logger) = (context, mapper, logger);
        
        public async Task<ContractTypeDetailsVm> Handle(
            GetContractTypeDetailsQuery request,
            CancellationToken cancellationToken)
        {
            _logger.LogInformation($"GetContractTypeDetailsQueryHandler reqest.Id: {request.Id}");

            var entity = await _context.ContractTypes.FirstOrDefaultAsync(contractType =>
                contractType.Id == request.Id, cancellationToken);

            if (entity == null || entity.Id != request.Id) 
                throw new NotFoundException(nameof(ContractType), request.Id);

            _logger.LogInformation($"GetContractTypeDetailsQueryHandler contractType == null? : {entity.Id}, {entity.Type}");

            return _mapper.Map<ContractTypeDetailsVm>(entity);
        }
    }
}
