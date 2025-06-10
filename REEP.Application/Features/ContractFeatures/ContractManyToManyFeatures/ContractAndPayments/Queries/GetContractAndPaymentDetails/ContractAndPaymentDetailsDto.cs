using AutoMapper;
using REEP.Application.Common.Mappings;

namespace REEP.Application.Features.ContractFeatures.ContractManyToManyFeatures.ContractAndPayments.Queries.GetContractAndPaymentDetails
{
    public class ContractAndPaymentDetailsDto
        : IMapWith<GetContractAndPaymentDetailsQuery>
    {
        public Guid ContractId { get; set; }
        public Guid PaymentId { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<ContractAndPaymentDetailsDto, GetContractAndPaymentDetailsQuery>();
        }
    }
}
