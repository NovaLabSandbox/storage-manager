using MediatR;

using OneOf;

using StorageManager.Client.Contracts;
using StorageManager.Core.Results;

namespace StorageManager.Application.CQRS.Queries.Site
{
    public class GetSiteByIdQuery : IRequest<OneOf<SiteResponse, NotFoundResult, ForbiddenResult, BusinessErrorResult>>
    {
        public string SiteId { get; }

        public GetSiteByIdQuery(string siteId)
        {
            SiteId = siteId;
        }
    }
}
