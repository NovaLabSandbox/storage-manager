using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using MediatR;

using MongoDB.Driver;

using OneOf;

using StorageManager.Application.CQRS.Commands.Site;
using StorageManager.Application.Interfaces;
using StorageManager.Core.Results;
using StorageManager.Infrastructure.Interfaces;

namespace StorageManager.Application.CQRS.CommandHandlers.Site
{
    public class DeleteSiteCommandHandler(ISiteRepository _siteRepository, ICacheService _cacheService) : IRequestHandler<DeleteSiteCommand, OneOf<bool, NotFoundResult, ForbiddenResult, BusinessErrorResult>>
    {
        public async Task<OneOf<bool, NotFoundResult, ForbiddenResult, BusinessErrorResult>> Handle(DeleteSiteCommand request, CancellationToken cancellationToken)
        {
            var site = await _siteRepository.GetSiteByIdAsync(request.SiteId);
            if (site == null)
            {
                return new NotFoundResult();
            }

            if (!UserHasPermissionToDeleteSite(request.SiteId))
            {
                return new ForbiddenResult();
            }

            var deleted = await _siteRepository.DeleteSiteAsync(request.SiteId);

            if (deleted)
            {
                await _cacheService.ClearAllSiteKey();
                return true;
            }

            return new BusinessErrorResult("Failed to delete the site.");
        }

        private bool UserHasPermissionToDeleteSite(string siteId)
        {
            // Implémenter la logique de vérification des permissions
            return true;
        }
    }
}
