using MediatR;

namespace REEP.Application.Features.ContractFeatures.ContractTypesFeatures.ContractTypes.Commands.CreateContractType
{
    public class CreateContractTypeCommand : IRequest<Guid>
    {
        public string Type { get; set; } = null!; 
        public bool IsDeleted { get; set; } = false;    
    }
}
