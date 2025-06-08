using MediatR;

namespace REEP.Application.Features.ContractFeatures.Suppliers.Commands.CreateSupplier
{
    public class CreateSupplierCommand : IRequest<Guid>
    {
        public string? FirstName { get; set; }
        public string? SecondName { get; set; }
        public string? LastName { get; set; }
        public string? OtherName { get; set; }
        public string? Number { get; set; }
        public string? Email { get; set; }
        public string? OtherContacts { get; set; }
        public bool IsDeleted { get; set; } = false;
        public string Type { get; set; } = null!;
    }
}
