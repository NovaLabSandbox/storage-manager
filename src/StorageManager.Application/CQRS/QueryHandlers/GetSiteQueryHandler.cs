using AutoMapper;

using MediatR;

using OneOf;

using StorageManager.Application.CQRS.Queries;
using StorageManager.Client.Contracts;
using StorageManager.Core.Results;
using StorageManager.Infrastructure.Interfaces;

namespace StorageManager.Application.CQRS.QueryHandlers
{
    public class GetSiteQueryHandler(ISiteRepository _siteRepository, IMapper _mapper) : IRequestHandler<GetSiteQuery, OneOf<Site, NotFoundResult, ForbiddenResult, BusinessErrorResult>>
    {
        public async Task<OneOf<Site, NotFoundResult, ForbiddenResult, BusinessErrorResult>> Handle(GetSiteQuery request, CancellationToken cancellationToken)
        {
            var site = await _siteRepository.GetSiteByIdAsync(request.SiteId);
            if (site == null)
            {
                return new NotFoundResult();
            }

            if (!UserHasPermissionToViewSite(request.SiteId))
            {
                return new ForbiddenResult();
            }

            return _mapper.Map<Site>(site);
        }

        private bool UserHasPermissionToViewSite(string siteId)
        {
            return true;
        }
    }
}
