using AutoMapper;
using REEP.Application.Common.Mappings;
using REEP.Domain.Models.ContractModels.ContractManyToManyModels;

namespace REEP.Application.Features.ContractFeatures.ContractManyToManyFeatures.ContractAndSuppliers.Queries.GetContractAndPaymentDetails
{
    public class ContractAndSupplierDetailsDto
        : IMapWith<GetContractAndSupplierDetailsQuery>
    {
        public Guid ContractId { get; set; }
        public Guid SupplierId { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<ContractAndSupplierDetailsDto, GetContractAndSupplierDetailsQuery>();
        }
    }
}
