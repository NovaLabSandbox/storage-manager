using AutoMapper;

using MediatR;

using OneOf;

using StorageManager.Application.CQRS.Queries.Site;
using StorageManager.Application.Interfaces;
using StorageManager.Client.Contracts;
using StorageManager.Core.Results;
using StorageManager.Infrastructure.Interfaces;

namespace StorageManager.Application.CQRS.QueryHandlers.Site
{
    public class GetAllSitesQueryHandler(ISiteRepository _siteRepository, IMapper _mapper, ICacheService _cacheService)
        : IRequestHandler<GetAllSitesQuery, OneOf<List<SiteResponse>, NotFoundResult, ForbiddenResult, BusinessErrorResult>>
    {
        public async Task<OneOf<List<SiteResponse>, NotFoundResult, ForbiddenResult, BusinessErrorResult>> Handle(GetAllSitesQuery request, CancellationToken cancellationToken)
        {
            var cacheSites = await _cacheService.RestoreAllSite();
            if (cacheSites != null)
                return cacheSites;

            var sites = await _siteRepository.GetAllSitesAsync();

            if (sites == null || !sites.Any())
            {
                return new List<SiteResponse>();
            }

            var sitesResponse = sites.Select(s => _mapper.Map<SiteResponse>(s)).ToList();
            await _cacheService.StoreAllSite(sitesResponse);

            return sitesResponse;
        }
    }
}
