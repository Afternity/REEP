using AutoMapper;
using REEP.Application.Common.Mappings;
using REEP.Domain.Models.ContractModels;

namespace REEP.Application.Features.ContractFeatures.Suppliers.Queries.GetSupplierList
{
    public class SupplierLookupDto : IMapWith<Supplier>
    {
        public Guid Id {  get; set; }
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
            profile.CreateMap<Supplier, SupplierLookupDto>()
                .ForMember(destination => destination.Type,
                    options => options.MapFrom(soure => soure.SupplierType.Type));
        }
    }
}
