using MediatR;

namespace REEP.Application.Features.ContractFeatures.ContractManyToManyFeatures.ContractAndPayments.Commands.SoftDeleteContractsAndPayments
{
    public class SoftDeleteContractsAndPaymentsCommand
        : IRequest<Unit>
    {
        public Guid ContractId { get; set; }
        public Guid PaymentId { get; set; }
        public bool IsDeleted { get; set; } = false;
    }
}
