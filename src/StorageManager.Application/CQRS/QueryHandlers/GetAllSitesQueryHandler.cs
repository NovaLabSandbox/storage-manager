﻿using AutoMapper;

using MediatR;

using OneOf;

using StorageManager.Application.CQRS.Queries;
using StorageManager.Application.Interfaces;
using StorageManager.Client.Contracts;
using StorageManager.Core.Results;
using StorageManager.Infrastructure.Interfaces;

namespace StorageManager.Application.CQRS.QueryHandlers
{
    public class GetAllSitesQueryHandler(ISiteRepository _siteRepository, IMapper _mapper, ICacheService _cacheService)
        : IRequestHandler<GetAllSitesQuery, OneOf<List<Site>, NotFoundResult, ForbiddenResult, BusinessErrorResult>>
    {
        public async Task<OneOf<List<Site>, NotFoundResult, ForbiddenResult, BusinessErrorResult>> Handle(GetAllSitesQuery request, CancellationToken cancellationToken)
        {
            var cacheSites = await _cacheService.RestoreAllSite();
            if (cacheSites != null)
                return cacheSites;

            var sites = await _siteRepository.GetAllSitesAsync();

            if (sites == null || !sites.Any())
            {
                return new List<Site>();
            }

            var sitesResponse = sites.Select(s => _mapper.Map<Site>(s)).ToList();
            await _cacheService.StoreAllSite(sitesResponse);

            return sitesResponse;
        }
    }
}