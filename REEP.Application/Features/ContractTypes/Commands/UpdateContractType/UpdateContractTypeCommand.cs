using MediatR;

namespace REEP.Application.Features.ContractTypes.Commands.UpdateContractType
{
    public class UpdateContractTypeCommand : IRequest<Unit>
    {
        public Guid Id { get; set; }
        public string Type { get; set; } = string.Empty;
    }
}
