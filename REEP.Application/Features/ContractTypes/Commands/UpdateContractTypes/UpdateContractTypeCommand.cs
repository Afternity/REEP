using MediatR;

namespace REEP.Application.Features.ContractTypes.Commands.UpdateContractTypes
{
    public class UpdateContractTypeCommand : IRequest<Unit>
    {
        public Guid Id { get; set; }
        public string Type { get; set; } = string.Empty;
        public DateTime CreatedAt { get; set; } 
        public DateTime? UpdatedAt { get; set; }
        public DateTime? DeletedAt { get; set; }
        public bool IsDeleted { get; set; } 
    }
}
