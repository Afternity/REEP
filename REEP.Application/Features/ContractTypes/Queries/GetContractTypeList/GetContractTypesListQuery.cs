﻿using MediatR;
using REEP.Application.Features.ContractTypes.Queries.GetContractTypeDetails;

namespace REEP.Application.Features.ContractTypes.Queries.GetContractTypeList
{
    public class GetContractTypesListQuery : IRequest<ContractTypeListVm>
    {
        public bool IsDeleted { get; set; } = false;
    }
}
