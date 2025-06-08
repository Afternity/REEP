using MediatR;

namespace REEP.Application.Features.ContractFeatures.Suppliers.Commands.HardDeleteSupplier
{
    public class HardDeleteSupplierCommand : IRequest<Unit>
    {
        public Guid Id { get; set; }
    }
}
