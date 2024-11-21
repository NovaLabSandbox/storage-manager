using StorageManager.Client.Contracts;

namespace StorageManager.Application.Interfaces
{
    public interface ICacheService
    {
        Task ClearAllSiteKey();
        Task StoreAllSite(List<Site> sites);
        Task<List<Site>> RestoreAllSite();
    }
}
