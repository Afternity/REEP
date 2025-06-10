using AutoMapper;
using REEP.Application.Common.Mappings;
using REEP.Application.Features.ContractFeatures.ContractManyToManyFeatures.ContractAndSuppliers.Queries.GetContractAndPaymentDetails;
using REEP.Domain.Models.ContractModels.ContractManyToManyModels;

namespace REEP.Application.Features.ContractFeatures.ContractManyToManyFeatures.ContractAndSuppliers.Queries.GetContractAndPaymentList
{
    public class ContractAndSupplierLookupDto
        : IMapWith<ContractAndSupplier>
    {
        public Guid ContractId { get; set; }
        public Guid SupplierId { get; set; }
        public bool IsActive { get; set; }
        public string ContractName { get; set; } = null!;
        public string ContractType { get; set; } = null!;
        public string? SupplierFirstName { get; set; }
        public string? SupplierSecondName { get; set; }
        public string? SupplierLastName { get; set; }
        public string? SupplierOtherName { get; set; }
        public string? SupplierNumber { get; set; }
        public string? SupplierEmail { get; set; }
        public string? SupplierOtherContacts { get; set; }
        public string SupplierType { get; set; } = null!;

        public void Mapping(Profile profile)
        {
            profile.CreateMap<ContractAndSupplier, ContractAndSupplierDetailsVm>()
                .ForMember(destination => destination.ContractName,
                    options => options.MapFrom(source => source.Contract.Name))
                .ForMember(destination => destination.ContractType,
                    options => options.MapFrom(source => source.Contract.ContractType.Type))
                .ForMember(destination => destination.SupplierFirstName,
                    options => options.MapFrom(source => source.Supplier.FirstName))
                .ForMember(destination => destination.SupplierSecondName,
                    options => options.MapFrom(source => source.Supplier.SecondName))
                .ForMember(destination => destination.SupplierLastName,
                    options => options.MapFrom(source => source.Supplier.LastName))
                .ForMember(destination => destination.SupplierOtherName,
                    options => options.MapFrom(source => source.Supplier.OtherName))
                .ForMember(destination => destination.SupplierNumber,
                    options => options.MapFrom(source => source.Supplier.Number))
                .ForMember(destination => destination.SupplierEmail,
                    options => options.MapFrom(source => source.Supplier.Email))
                .ForMember(destination => destination.SupplierOtherContacts,
                    options => options.MapFrom(source => source.Supplier.OtherContacts))
                .ForMember(destination => destination.SupplierType,
                    options => options.MapFrom(source => source.Supplier.SupplierType.Type));
        }
    }
}
