using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using REEP.Application.Common.Exceptions;
using REEP.Application.Interfaces.InterfaceDbContexts;
using REEP.Domain.Models.WarrantyModels;

namespace REEP.Application.Features.WarrantyFeatures.Warranties.Commands.CreateWarrantyByType
{
    internal class CreateWarrantyByTypeCommandHandler
        : IRequestHandler<CreateWarrantyByTypeCommand, Guid>
    {
        private readonly IReepDbContext _context;
        private readonly ILogger<CreateWarrantyByTypeCommandHandler> _logger;

        public CreateWarrantyByTypeCommandHandler(
            IReepDbContext context,
            ILogger<CreateWarrantyByTypeCommandHandler> logger)
        {
            _context = context;
            _logger = logger;
        }

        public async Task<Guid> Handle(
            CreateWarrantyByTypeCommand request,
            CancellationToken cancellationToken)
        {
            _logger.LogInformation($"Вход в {nameof(CreateWarrantyByTypeCommandHandler)}");

            var contract = await _context.Contracts
                .FirstOrDefaultAsync(parent =>
                    parent.Id == request.ContractId,
                    cancellationToken);

            if (contract == null)
                throw new NotFoundException(nameof(contract), request.ContractId);

            _logger.LogInformation($"Был найден: {nameof(contract)}");

            var warrantyType = await _context.WarrantyTypes
                .FirstOrDefaultAsync(parent =>
                    parent.Type == request.WarrantyType,
                    cancellationToken);

            if (warrantyType == null)
                throw new NotFoundException(nameof(warrantyType), request.WarrantyType);

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

            _logger.LogInformation($"Выход из {nameof(CreateWarrantyByTypeCommandHandler)}");

            return warranty.Id;
        }
    }
}
