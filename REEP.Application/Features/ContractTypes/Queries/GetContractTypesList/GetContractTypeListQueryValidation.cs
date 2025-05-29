using FluentValidation;
using System.Data;

namespace REEP.Application.Features.ContractTypes.Queries.GetContractTypesList
{
    public class GetContractTypeListQueryValidation : AbstractValidator<GetContractTypesListQuery>
    {
        public GetContractTypeListQueryValidation()
        {
            RuleFor(getContractTypesListQuery => getContractTypesListQuery.IsDeleted).NotEmpty();
        }
    }
}
