using StorageManager.Domain.Entities;

namespace StorageManager.Infrastructure.Interfaces
{
    public interface ISiteRepository
    {
        Task<Site> GetSiteByIdAsync(string siteId);
        Task<List<Site>> GetAllSitesAsync();
        Task<bool> CreateSiteAsync(Site site);
        Task<bool> UpdateSiteAsync(string siteId, Site updatedSite);
        Task<bool> DeleteSiteAsync(string siteId);

        Task<bool> AddAreaToSiteAsync(string siteId, Area area);
        Task<bool> RemoveAreaFromSiteAsync(string siteId, string areaId);

        Task<bool> AddModuleToAreaAsync(string siteId, string areaId, Module module);
        Task<bool> RemoveModuleFromAreaAsync(string siteId, string areaId, string moduleId);

        Task<bool> AddDeviceToSiteAsync(string siteId, string deviceId);
        Task<bool> RemoveDeviceFromSiteAsync(string siteId, string deviceId);

        Task<bool> AddDeviceToAreaAsync(string siteId, string areaId, string deviceId);
        Task<bool> RemoveDeviceFromAreaAsync(string siteId, string areaId, string deviceId);

        Task<bool> AddDeviceToModuleAsync(string siteId, string areaId, string moduleId, string deviceId);
        Task<bool> RemoveDeviceFromModuleAsync(string siteId, string areaId, string moduleId, string deviceId);

        Task<List<Device>> GetDevicesForSiteAsync(string siteId);
        Task<List<Device>> GetDevicesForAreaAsync(string siteId, string areaId);
        Task<List<Device>> GetDevicesForModuleAsync(string siteId, string areaId, string moduleId);
    }
}
