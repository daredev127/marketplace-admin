using Marketplace.Admin.Application.Dtos;
using MediatR;

namespace Marketplace.Admin.Application.AccountManagement
{
    public class GetAdminAccountsQuery : IRequest<ResponseBaseDto>
    {
        public string Search { get; set; }
        public string Status { get; set; }

        public GetAdminAccountsQuery(string search, string status)
        {
            Search = search;
            Status = status;
        }
    }
}
