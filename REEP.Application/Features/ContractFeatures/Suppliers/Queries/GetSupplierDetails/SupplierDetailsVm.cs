using AutoMapper;
using REEP.Application.Common.Mappings;
using REEP.Domain.Models.ContractModels;

namespace REEP.Application.Features.ContractFeatures.Suppliers.Queries.GetSupplierDetails
{
    public class SupplierDetailsVm : IMapWith<Supplier>
    {
        public string? FirstName { get; set; }
        public string? SecondName { get; set; }
        public string? LastName { get; set; }
        public string? OtherName { get; set; }
        public string? Number { get; set; }
        public string? Email { get; set; }
        public string? OtherContacts { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public DateTime? DeletedAt { get; set; }
        public bool IsDeleted { get; set; } = false;
        public string Type { get; set; } = null!;

        public void Mapping(Profile profile)
        {
            profile.CreateMap<Supplier, SupplierDetailsVm>()
                .ForMember(destination => destination.Type,
                    options => options.MapFrom(soure => soure.SupplierType.Type));
        }
    }
}
