using MediatR;

namespace REEP.Application.Features.ContractFeatures.ContractTypesFeatures.ContractTypes.Commands.SoftDeleteContractType
{
    public class SoftDeleteContractTypeCommand : IRequest<Unit>
    {
        public Guid Id { get; set; }
        public bool IsDeleted { get; set; } = true;
    }
}
