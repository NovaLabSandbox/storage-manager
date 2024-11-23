
using System.Text.Json;

using Microsoft.Extensions.Caching.Distributed;

using StorageManager.Application.Interfaces;
using StorageManager.Client.Contracts;
using StorageManager.Domain.Entities;

namespace StorageManager.Application.Services
{
    public class CacheService(IDistributedCache _cache) : ICacheService
    {
        private const string AllSiteKey = nameof(AllSiteKey);
        private const string AllDeviceKey = nameof(AllDeviceKey);

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

        public Task ClearAllDevices()
        {
            return _cache.RemoveAsync(AllDeviceKey);
        }

        public Task StoreAllDevices(List<DeviceResponse> devices)
        {
            return _cache.SetStringAsync(AllSiteKey, JsonSerializer.Serialize(devices), new DistributedCacheEntryOptions()
            {
                AbsoluteExpirationRelativeToNow = TimeSpan.FromMinutes(60)
            });
        }

        public async Task<List<DeviceResponse>> RestoreAllDevices()
        {
            var cacheValue = await _cache.GetStringAsync(AllDeviceKey);

            if (!string.IsNullOrEmpty(cacheValue))
                return JsonSerializer.Deserialize<List<DeviceResponse>>((cacheValue));

            return null;
        }
    }
}
