using Microsoft.AspNetCore.Mvc;

using StorageManager.Client.Contracts;

namespace StorageManager.Service.Host.Controllers
{
    [ApiController]
    public class AreaController : AreaControllerBase
    {
        public override Task<ActionResult<AreaResponse>> CreateArea(string siteId, [FromBody] CreateAreaRequest body)
        {
            throw new NotImplementedException();
        }

        public override Task<ActionResult<DeviceResponse>> CreateDeviceInArea(string siteId, string areaId, [FromBody] CreateDeviceRequest body)
        {
            throw new NotImplementedException();
        }

        public override Task<IActionResult> DeleteArea(string siteId, string areaId)
        {
            throw new NotImplementedException();
        }

        public override Task<IActionResult> DeleteDeviceFromArea(string siteId, string areaId, string deviceId)
        {
            throw new NotImplementedException();
        }

        public override Task<ActionResult<ICollection<AreaResponse>>> GetAllAreas(string siteId)
        {
            throw new NotImplementedException();
        }

        public override Task<ActionResult<ICollection<DeviceResponse>>> GetAllDevicesInArea(string siteId, string areaId)
        {
            throw new NotImplementedException();
        }

        public override Task<ActionResult<AreaResponse>> GetAreaById(string siteId, string areaId)
        {
            throw new NotImplementedException();
        }

        public override Task<ActionResult<DeviceResponse>> GetDeviceByIdInArea(string siteId, string areaId, string deviceId)
        {
            throw new NotImplementedException();
        }

        public override Task<ActionResult<AreaResponse>> UpdateArea(string siteId, string areaId, [FromBody] UpdateAreaRequest body)
        {
            throw new NotImplementedException();
        }

        public override Task<ActionResult<DeviceResponse>> UpdateDeviceInArea(string siteId, string areaId, string deviceId, [FromBody] UpdateDeviceRequest body)
        {
            throw new NotImplementedException();
        }
    }
}
