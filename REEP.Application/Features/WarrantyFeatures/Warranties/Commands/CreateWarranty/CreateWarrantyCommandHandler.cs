using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using REEP.Application.Interfaces.InterfaceDbContexts;
using REEP.Application.Common.Exceptions;
using REEP.Domain.Models.WarrantyModels;

namespace REEP.Application.Features.WarrantyFeatures.Warranties.Commands.CreateWarranty
{
    public class CreateWarrantyCommandHandler
        : IRequestHandler<CreateWarrantyCommand, Guid>
    {
        private readonly IReepDbContext _context;
        private readonly ILogger<CreateWarrantyCommandHandler> _logger;

        public CreateWarrantyCommandHandler(
            IReepDbContext context,
            ILogger<CreateWarrantyCommandHandler> logger)
        {
            _context = context;
            _logger = logger;
        }

        public async Task<Guid> Handle(
            CreateWarrantyCommand request,
            CancellationToken cancellationToken)
        {
            _logger.LogInformation($"Вход в {nameof(CreateWarrantyCommandHandler)}");

            var contract = await _context.Contracts
                .FirstOrDefaultAsync(parent =>
                    parent.Id == request.ContractId,
                    cancellationToken);

            if (contract == null) 
                throw new NotFoundException(nameof(contract), request.ContractId);

            _logger.LogInformation($"Был найден: {nameof(contract)}");

            var warrantyType = await _context.WarrantyTypes
                .FirstOrDefaultAsync(parent =>
                    parent.Id == request.WarrantyTypeId,
                    cancellationToken);

            if (warrantyType == null)
                throw new NotFoundException(nameof(warrantyType), request.WarrantyTypeId);

            _logger.LogInformation($"Был найден: {nameof(warrantyType)}");

            var warranty = new Warranty()
            {
                Id = Guid.NewGuid(),
                Name = request.Name,
                Description = request.Description,
                StartedAt = request.StartedAt,
                EndedAt = request.EndedAt,
                CreatedAt = DateTime.UtcNow,
                IsDeleted = request.IsDeleted,
                ContractId = contract.Id,
                WarrantyTypeId = warrantyType.Id,
            };

            _logger.LogInformation($"Сборка {nameof(warranty)} завершина");

            await _context.Warranties.AddAsync(warranty, cancellationToken);
            await _context.SaveChangesAsync(cancellationToken);

            _logger.LogInformation($"Выход из {nameof(CreateWarrantyCommandHandler)}");

            return warranty.Id;
        }
    }
}
