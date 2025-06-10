using AutoMapper;
using MediatR;

namespace REEP.Application.Features.ContractFeatures.ContractTypesFeatures.SupplierTypes.Commands.CreateSupplierType
{
    public class CreateWarrantyTypeCommand : IRequest<Guid>
    {
        public string Type { get; set; } = null!;
        public bool IsDeleted { get; set; } = false;
    }
}
