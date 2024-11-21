using MediatR;

using Microsoft.AspNetCore.Mvc;

using StorageManager.Application.CQRS.Commands;
using StorageManager.Application.CQRS.Queries;
using StorageManager.Client.Contracts;


namespace StorageManager.Service.Host.Controllers
{
    [ApiController]
    public class SiteController(IMediator _mediator) : SiteControllerBase
    {
        [Produces("application/json")]
        public override async Task<ActionResult<ICollection<SiteResponse>>> GetAllSites()
            => Do(await _mediator.Send(new GetAllSitesQuery()));

        [Produces("application/json")]
        public override async Task<ActionResult<SiteResponse>> GetSiteById(string siteId)
            => Do(await _mediator.Send(new GetSiteQuery(siteId)));

        [Produces("application/json")]
        public override async Task<ActionResult<SiteResponse>> CreateSite([FromBody] SiteCreateRequest body)
            => Do(await _mediator.Send(new CreateSiteCommand(body)));

        [Produces("application/json")]
        public override async Task<ActionResult<SiteResponse>> UpdateSite(string siteId, [FromBody] SiteUpdateRequest body)
            => Do(await _mediator.Send(new UpdateSiteCommand(siteId, body)));

        [Produces("application/json")]
        public override async Task<IActionResult> DeleteSite(string siteId)
            => Do(await _mediator.Send(new DeleteSiteCommand(siteId)));

        public override Task<ActionResult<ICollection<DeviceResponse>>> GetAllDevicesInSite(string siteId)
        {
            throw new NotImplementedException();
        }

        public override Task<ActionResult<DeviceResponse>> CreateDeviceInSite(string siteId, [FromBody] CreateDeviceRequest body)
        {
            throw new NotImplementedException();
        }

        public override Task<ActionResult<DeviceResponse>> GetDeviceByIdInSite(string siteId, string deviceId)
        {
            throw new NotImplementedException();
        }

        public override Task<ActionResult<DeviceResponse>> UpdateDeviceInSite(string siteId, string deviceId, [FromBody] UpdateDeviceRequest body)
        {
            throw new NotImplementedException();
        }

        public override Task<IActionResult> DeleteDeviceInSite(string siteId, string deviceId)
        {
            throw new NotImplementedException();
        }
    }
}

