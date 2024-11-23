using StorageManager.Client.Contracts;

namespace StorageManager.Application.Interfaces
{
    public interface ICacheService
    {
        Task ClearAllSiteKey();
        Task StoreAllSite(List<SiteResponse> sites);
        Task<List<SiteResponse>> RestoreAllSite();

        Task ClearAllDevices();
        Task StoreAllDevices(List<DeviceResponse> devices);
        Task<List<DeviceResponse>> RestoreAllDevices();
    }
}
