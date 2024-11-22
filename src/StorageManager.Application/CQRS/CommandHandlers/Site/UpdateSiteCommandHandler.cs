using AutoMapper;

using MediatR;

using OneOf;

using StorageManager.Application.CQRS.Commands.Site;
using StorageManager.Application.Interfaces;
using StorageManager.Core.Results;
using StorageManager.Infrastructure.Interfaces;

namespace StorageManager.Application.CQRS.CommandHandlers.Site
{
    public class UpdateSiteCommandHandler(ISiteRepository _siteRepository, IMapper _mapper, ICacheService _cacheService)
        : IRequestHandler<UpdateSiteCommand, OneOf<bool, NotFoundResult, ForbiddenResult, BusinessErrorResult>>
    {
        public async Task<OneOf<bool, NotFoundResult, ForbiddenResult, BusinessErrorResult>> Handle(UpdateSiteCommand request, CancellationToken cancellationToken)
        {
            var site = await _siteRepository.GetSiteByIdAsync(request.SiteId);
            if (site == null)
            {
                return new NotFoundResult();
            }

            if (!UserHasPermissionToUpdateSite(request.SiteId))
            {
                return new ForbiddenResult();
            }

            site.Name = request.Payload.Name;
            site.Description = request.Payload.Description;

            var updatedSite = await _siteRepository.UpdateSiteAsync(request.SiteId, site);

            if (updatedSite)
            {
                await _cacheService.ClearAllSiteKey();
            }

            return updatedSite;
        }

        private bool UserHasPermissionToUpdateSite(string siteId)
        {
            // Implémenter la logique de vérification des permissions
            return true;
        }
    }
}
