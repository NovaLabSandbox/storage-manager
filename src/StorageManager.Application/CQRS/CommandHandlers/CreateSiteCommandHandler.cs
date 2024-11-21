using AutoMapper;

using MediatR;

using OneOf;

using StorageManager.Application.CQRS.Commands;
using StorageManager.Application.Interfaces;
using StorageManager.Client.Contracts;
using StorageManager.Core.Results;
using StorageManager.Infrastructure.Interfaces;

namespace StorageManager.Application.CQRS.CommandHandlers
{
    public class CreateSiteCommandHandler(ISiteRepository _siteRepository, IMapper _mapper, ICacheService _cacheService)
        : IRequestHandler<CreateSiteCommand, OneOf<CreatedResult<SiteResponse>, NotFoundResult, ForbiddenResult, BusinessErrorResult>>
    {

        public async Task<OneOf<CreatedResult<SiteResponse>, NotFoundResult, ForbiddenResult, BusinessErrorResult>> Handle(CreateSiteCommand request, CancellationToken cancellationToken)
        {
            if (!UserHasPermissionToCreateSite())
            {
                return new ForbiddenResult();
            }

            var site = new Domain.Entities.Site
            {
                Name = request.Payload.Name,
                Description = request.Payload.Description
            };

            var createdSite = await _siteRepository.CreateSiteAsync(site);

            if (createdSite)
            {
                await _cacheService.ClearAllSiteKey();
            }

            return new CreatedResult<SiteResponse>() { Data = _mapper.Map<SiteResponse>(site), EntityPath = nameof(SiteResponse), Id = site.Id };
        }

        private bool UserHasPermissionToCreateSite()
        {
            return true;
        }
    }
}
