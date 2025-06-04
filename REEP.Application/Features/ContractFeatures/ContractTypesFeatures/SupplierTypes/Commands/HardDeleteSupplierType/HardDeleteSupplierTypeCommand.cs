using MediatR;

namespace REEP.Application.Features.ContractFeatures.ContractTypesFeatures.SupplierTypes.Commands.HardDeleteSupplierType
{
    public class HardDeleteSupplierTypeCommand : IRequest<Unit>
    {
        public Guid Id {  get; set; }
    }
}
