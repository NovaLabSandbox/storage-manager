using StorageManager.Client.Contracts;

namespace StorageManager.Application.Interfaces
{
    public interface ICacheService
    {
        Task ClearAllSiteKey();
        Task StoreAllSite(List<SiteResponse> sites);
        Task<List<SiteResponse>> RestoreAllSite();
    }
}
