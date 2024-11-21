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
        : IRequestHandler<CreateSiteCommand, OneOf<CreatedResult<Site>, NotFoundResult, ForbiddenResult, BusinessErrorResult>>
    {

        public async Task<OneOf<CreatedResult<Site>, NotFoundResult, ForbiddenResult, BusinessErrorResult>> Handle(CreateSiteCommand request, CancellationToken cancellationToken)
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

            return new CreatedResult<Site>() { Data = _mapper.Map<Site>(site), EntityPath = nameof(Site), Id = site.Id };
        }

        private bool UserHasPermissionToCreateSite()
        {
            return true;
        }
    }
}
