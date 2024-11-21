using Microsoft.AspNetCore.Mvc;

using StorageManager.Client.Contracts;

namespace StorageManager.Service.Host.Controllers
{
    [ApiController]
    public class AreaController : AreaControllerBase
    {
        [Produces("application/json")]
        public override Task<ActionResult<Area>> CreateArea(string siteId, [FromBody] CreateAreaRequest body)
        {
            throw new NotImplementedException();
        }

        [Produces("application/json")]
        public override Task<ActionResult<Device>> CreateDeviceInArea(string siteId, string areaId, [FromBody] CreateDeviceRequest body)
        {
            throw new NotImplementedException();
        }

        [Produces("application/json")]
        public override Task<IActionResult> DeleteArea(string siteId, string areaId)
        {
            throw new NotImplementedException();
        }

        [Produces("application/json")]
        public override Task<IActionResult> DeleteDeviceFromArea(string siteId, string areaId, string deviceId)
        {
            throw new NotImplementedException();
        }

        [Produces("application/json")]
        public override Task<ActionResult<ICollection<Area>>> GetAllAreas(string siteId)
        {
            throw new NotImplementedException();
        }

        [Produces("application/json")]
        public override Task<ActionResult<ICollection<Device>>> GetAllDevicesInArea(string siteId, string areaId)
        {
            throw new NotImplementedException();
        }

        [Produces("application/json")]
        public override Task<ActionResult<Area>> GetAreaById(string siteId, string areaId)
        {
            throw new NotImplementedException();
        }

        [Produces("application/json")]
        public override Task<ActionResult<Device>> GetDeviceByIdInArea(string siteId, string areaId, string deviceId)
        {
            throw new NotImplementedException();
        }

        [Produces("application/json")]
        public override Task<ActionResult<Area>> UpdateArea(string siteId, string areaId, [FromBody] UpdateAreaRequest body)
        {
            throw new NotImplementedException();
        }

        [Produces("application/json")]
        public override Task<ActionResult<Device>> UpdateDeviceInArea(string siteId, string areaId, string deviceId, [FromBody] UpdateDeviceRequest body)
        {
            throw new NotImplementedException();
        }
    }
}
