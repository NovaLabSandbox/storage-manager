using MediatR;

using Microsoft.AspNetCore.Mvc;

using StorageManager.Application.CQRS.Commands;
using StorageManager.Application.CQRS.Queries;
using StorageManager.Client.Contracts;

namespace StorageManager.Service.Host.Controllers
{
    [ApiController]
    public class StorageManagerController(IMediator _mediator) : StorageManagerControllerBase
    {
        [Produces("application/json")]
        public override async Task<ActionResult<ICollection<Site>>> GetAllSites()
            => Do(await _mediator.Send(new GetAllSitesQuery()));

        [Produces("application/json")]
        public override async Task<ActionResult<Site>> GetSiteById(string siteId)
            => Do(await _mediator.Send(new GetSiteQuery(siteId)));

        [Produces("application/json")]
        public override async Task<ActionResult<Site>> CreateSite([FromBody] SiteCreateRequest body)
            => Do(await _mediator.Send(new CreateSiteCommand(body)));

        [Produces("application/json")]
        public override async Task<ActionResult<Site>> UpdateSite(string siteId, [FromBody] SiteUpdateRequest body)
            => Do(await _mediator.Send(new UpdateSiteCommand(siteId, body)));

        [Produces("application/json")]
        public override async Task<IActionResult> DeleteSite(string siteId)
            => Do(await _mediator.Send(new DeleteSiteCommand(siteId)));

    }
}
