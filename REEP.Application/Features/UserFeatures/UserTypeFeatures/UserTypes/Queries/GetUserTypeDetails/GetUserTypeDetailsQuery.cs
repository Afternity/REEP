using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace REEP.Application.Features.UserFeatures.UserTypeFeatures.UserTypes.Queries.GetUserTypeDetails
{
    public class GetUserTypeDetailsQuery
        : IRequest<UserTypeDetailsVm>
    {
        public Guid Id { get; set; }
    }
}
