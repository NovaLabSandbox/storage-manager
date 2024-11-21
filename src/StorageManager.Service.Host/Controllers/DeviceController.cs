using Microsoft.AspNetCore.Mvc;

using StorageManager.Client.Contracts;

namespace StorageManager.Service.Host.Controllers
{
    [ApiController]
    public class DeviceController : DeviceControllerBase
    {
        public override Task<ActionResult<DeviceResponse>> CreateDevice([FromBody] CreateDeviceRequest body)
        {
            throw new NotImplementedException();
        }

        public override Task<IActionResult> DeleteDevice(string deviceId)
        {
            throw new NotImplementedException();
        }

        public override Task<ActionResult<ICollection<DeviceResponse>>> GetAllDevices()
        {
            throw new NotImplementedException();
        }

        public override Task<ActionResult<DeviceResponse>> GetDeviceById(string deviceId)
        {
            throw new NotImplementedException();
        }

        public override Task<ActionResult<DeviceResponse>> UpdateDevice(string deviceId, [FromBody] UpdateDeviceRequest body)
        {
            throw new NotImplementedException();
        }
    }
}
