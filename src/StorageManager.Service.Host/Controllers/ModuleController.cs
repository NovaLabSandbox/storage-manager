using Microsoft.AspNetCore.Mvc;

using StorageManager.Client.Contracts;

namespace StorageManager.Service.Host.Controllers
{
    [ApiController]
    public class ModuleController : ModuleControllerBase
    {
        public override Task<ActionResult<ModuleResponse>> CreateModule(string siteId, string areaId, [FromBody] CreateModuleRequest body)
        {
            throw new NotImplementedException();
        }

        public override Task<IActionResult> DeleteModule(string siteId, string areaId, string moduleId)
        {
            throw new NotImplementedException();
        }

        public override Task<ActionResult<ICollection<ModuleResponse>>> GetAllModules(string siteId, string areaId)
        {
            throw new NotImplementedException();
        }

        public override Task<ActionResult<ModuleResponse>> GetModuleById(string siteId, string areaId, string moduleId)
        {
            throw new NotImplementedException();
        }

        public override Task<ActionResult<DeviceResponse>> Module_CreateDevice(string siteId, string areaId, string moduleId, [FromBody] CreateDeviceRequest body)
        {
            throw new NotImplementedException();
        }

        public override Task<IActionResult> Module_DeleteDevice(string siteId, string areaId, string moduleId, string deviceId)
        {
            throw new NotImplementedException();
        }

        public override Task<ActionResult<ICollection<DeviceResponse>>> Module_GetAllDevices(string siteId, string areaId, string moduleId)
        {
            throw new NotImplementedException();
        }

        public override Task<ActionResult<DeviceResponse>> Module_GetDevice(string siteId, string areaId, string moduleId, string deviceId)
        {
            throw new NotImplementedException();
        }

        public override Task<ActionResult<DeviceResponse>> Module_UpdateDevice(string siteId, string areaId, string moduleId, string deviceId, [FromBody] UpdateDeviceRequest body)
        {
            throw new NotImplementedException();
        }

        public override Task<ActionResult<ModuleResponse>> UpdateModule(string siteId, string areaId, string moduleId, [FromBody] UpdateModuleRequest body)
        {
            throw new NotImplementedException();
        }
    }
}
