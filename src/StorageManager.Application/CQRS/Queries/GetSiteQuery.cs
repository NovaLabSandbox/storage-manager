using MediatR;

using OneOf;

using StorageManager.Client.Contracts;
using StorageManager.Core.Results;

namespace StorageManager.Application.CQRS.Queries
{
    public class GetSiteQuery : IRequest<OneOf<SiteResponse, NotFoundResult, ForbiddenResult, BusinessErrorResult>>
    {
        public string SiteId { get; }

        public GetSiteQuery(string siteId)
        {
            SiteId = siteId;
        }
    }
}
