using Microsoft.AspNetCore.Mvc;

using StorageManager.Client.Contracts;

namespace StorageManager.Service.Host.Controllers
{
    [ApiController]
    public class DeviceController : DeviceControllerBase
    {
        public override Task<ActionResult<DeviceResponse>> Device_Create([FromBody] CreateDeviceRequest body)
        {
            throw new NotImplementedException();
        }

        public override Task<IActionResult> Device_Delete(string deviceId)
        {
            throw new NotImplementedException();
        }

        public override Task<ActionResult<ICollection<DeviceResponse>>> Device_GetAll()
        {
            throw new NotImplementedException();
        }

        public override Task<ActionResult<DeviceResponse>> Device_GetOne(string deviceId)
        {
            throw new NotImplementedException();
        }

        public override Task<ActionResult<DeviceResponse>> Device_Update(string deviceId, [FromBody] UpdateDeviceRequest body)
        {
            throw new NotImplementedException();
        }
    }
}
