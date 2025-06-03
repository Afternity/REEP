﻿using MediatR;
using Microsoft.Extensions.Logging;

namespace REEP.Application.Features.ContractTypes.Queries.GetContractTypesDetails
{
    public class GetContractTypeDetailsQuery : IRequest<ContractTypeDetailsVm>
    {
        public Guid Id { get; set; }
    }
}
