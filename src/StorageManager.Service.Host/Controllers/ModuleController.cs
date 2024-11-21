using Microsoft.AspNetCore.Mvc;

using StorageManager.Client.Contracts;

namespace StorageManager.Service.Host.Controllers
{
    [ApiController]
    public class ModuleController : ModuleControllerBase
    {
        public override Task<ActionResult<Module>> CreateModule(string siteId, string areaId, [FromBody] CreateModuleRequest body)
        {
            throw new NotImplementedException();
        }

        public override Task<IActionResult> DeleteModule(string siteId, string areaId, string moduleId)
        {
            throw new NotImplementedException();
        }

        public override Task<ActionResult<ICollection<Module>>> GetAllModules(string siteId, string areaId)
        {
            throw new NotImplementedException();
        }

        public override Task<ActionResult<Module>> GetModuleById(string siteId, string areaId, string moduleId)
        {
            throw new NotImplementedException();
        }

        public override Task<ActionResult<Device>> Module_CreateDevice(string siteId, string areaId, string moduleId, [FromBody] CreateDeviceRequest body)
        {
            throw new NotImplementedException();
        }

        public override Task<IActionResult> Module_DeleteDevice(string siteId, string areaId, string moduleId, string deviceId)
        {
            throw new NotImplementedException();
        }

        public override Task<ActionResult<ICollection<Device>>> Module_GetAllDevices(string siteId, string areaId, string moduleId)
        {
            throw new NotImplementedException();
        }

        public override Task<ActionResult<Device>> Module_GetDevice(string siteId, string areaId, string moduleId, string deviceId)
        {
            throw new NotImplementedException();
        }

        public override Task<ActionResult<Device>> Module_UpdateDevice(string siteId, string areaId, string moduleId, string deviceId, [FromBody] UpdateDeviceRequest body)
        {
            throw new NotImplementedException();
        }

        public override Task<ActionResult<Module>> UpdateModule(string siteId, string areaId, string moduleId, [FromBody] UpdateModuleRequest body)
        {
            throw new NotImplementedException();
        }
    }
}
