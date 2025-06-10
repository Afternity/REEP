﻿using AutoMapper;
using REEP.Application.Common.Mappings;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace REEP.Application.Features.ContractFeatures.ContractManyToManyFeatures.ContractAndPayments.Commands.UpdateContractAndPayment
{
    public class UpdateContractAndPaymentDto
        : IMapWith<UpdateContractAndPaymentCommand>
    {
        public Guid ContractId { get; set; }
        public Guid PaymentId { get; set; }
        public bool IsActive { get; set; } = false;

        public void Mapping(Profile profile)
        {
            profile.CreateMap<UpdateContractAndPaymentDto, UpdateContractAndPaymentCommand>();
        }
    }
}
