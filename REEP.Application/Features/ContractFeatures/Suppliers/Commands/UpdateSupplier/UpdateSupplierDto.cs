using AutoMapper;
using MediatR;
using REEP.Application.Common.Mappings;

namespace REEP.Application.Features.ContractFeatures.Suppliers.Commands.UpdateSupplier
{
    public class UpdateSupplierDto : IMapWith<UpdateSupplierCommand>
    {
        public Guid Id { get; set; }
        public string? FirstName { get; set; }
        public string? SecondName { get; set; }
        public string? LastName { get; set; }
        public string? OtherName { get; set; }
        public string? Number { get; set; }
        public string? Email { get; set; }
        public string? OtherContacts { get; set; }
        public string Type { get; set; } = null!;

        public void Mapping(Profile profile)
        {
            profile.CreateMap<UpdateSupplierDto, UpdateSupplierCommand>();
        }
    }
}
