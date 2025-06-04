using MediatR;

namespace REEP.Application.Features.ContractFeatures.ContractTypesFeatures.ContractTypes.Commands.HardDeleteContractType
{
    public class HardDeleteContractTypeCommand : IRequest<Unit>
    {
        public Guid Id { get; set; }
    }
}
