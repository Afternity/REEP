﻿using AutoMapper;
using REEP.Application.Common.Mappings;
using REEP.Application.Features.ContractTypes.Queries.GetContractTypeByTypeDetails;
using REEP.Domain.Models.ContractModels.ContractTypeModels;

namespace REEP.Application.Features.PaymentTypes.Queries.GetPaymentTypeByTypeDetails
{
    public class PaymentTypeByTypeDelailsVm : IMapWith<PaymentType>
    {
        public string Type { get; set; } = null!;
        public DateTime CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public DateTime? DeletedAt { get; set; }
        public bool IsDeleted { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<PaymentType, PaymentTypeByTypeDelailsVm>();
        }
    }
}
