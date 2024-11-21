
using System.Text.Json;

using Microsoft.Extensions.Caching.Distributed;

using StorageManager.Application.Interfaces;
using StorageManager.Client.Contracts;

namespace StorageManager.Application.Services
{
    public class CacheService(IDistributedCache _cache) : ICacheService
    {
        private const string AllSiteKey = nameof(AllSiteKey);

        public Task ClearAllSiteKey()
        {
            return _cache.RemoveAsync(AllSiteKey);
        }

        public Task StoreAllSite(List<SiteResponse> sites)
        {
            return _cache.SetStringAsync(AllSiteKey, JsonSerializer.Serialize(sites), new DistributedCacheEntryOptions()
            {
                AbsoluteExpirationRelativeToNow = TimeSpan.FromMinutes(10)
            });
        }

        public async Task<List<SiteResponse>> RestoreAllSite()
        {
            var cacheValue = await _cache.GetStringAsync(AllSiteKey);

            if (!string.IsNullOrEmpty(cacheValue))
                return JsonSerializer.Deserialize<List<SiteResponse>>((cacheValue));

            return null;
        }
    }
}
