using Microsoft.AspNetCore.Mvc;

using StorageManager.Client.Contracts;

namespace StorageManager.Service.Host.Controllers
{
    [ApiController]
    public class ModuleController : ModuleControllerBase
    {
        public override Task<ActionResult<DeviceResponse>> CreateDeviceInModule(string siteId, string areaId, string moduleId, [FromBody] CreateDeviceRequest body)
        {
            throw new NotImplementedException();
        }

        public override Task<ActionResult<ModuleResponse>> CreateModule(string siteId, string areaId, [FromBody] CreateModuleRequest body)
        {
            throw new NotImplementedException();
        }

        public override Task<IActionResult> DeleteDeviceInModule(string siteId, string areaId, string moduleId, string deviceId)
        {
            throw new NotImplementedException();
        }

        public override Task<IActionResult> DeleteModule(string siteId, string areaId, string moduleId)
        {
            throw new NotImplementedException();
        }

        public override Task<ActionResult<ICollection<DeviceResponse>>> GetAllDevicesInModule(string siteId, string areaId, string moduleId)
        {
            throw new NotImplementedException();
        }

        public override Task<ActionResult<ICollection<ModuleResponse>>> GetAllModules(string siteId, string areaId)
        {
            throw new NotImplementedException();
        }

        public override Task<ActionResult<DeviceResponse>> GetDeviceByIdInModule(string siteId, string areaId, string moduleId, string deviceId)
        {
            throw new NotImplementedException();
        }

        public override Task<ActionResult<ModuleResponse>> GetModuleById(string siteId, string areaId, string moduleId)
        {
            throw new NotImplementedException();
        }

        public override Task<ActionResult<DeviceResponse>> UpdateDeviceInModule(string siteId, string areaId, string moduleId, string deviceId, [FromBody] UpdateDeviceRequest body)
        {
            throw new NotImplementedException();
        }

        public override Task<ActionResult<ModuleResponse>> UpdateModule(string siteId, string areaId, string moduleId, [FromBody] UpdateModuleRequest body)
        {
            throw new NotImplementedException();
        }
    }
}
