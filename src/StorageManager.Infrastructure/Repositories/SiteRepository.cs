using Microsoft.Extensions.Configuration;

using MongoDB.Driver;

using StorageManager.Domain.Entities;
using StorageManager.Infrastructure.Core;
using StorageManager.Infrastructure.Interfaces;

namespace StorageManager.Infrastructure.Repositories
{
    public class SiteRepository : CoreRepository, ISiteRepository
    {
        private readonly IMongoCollection<Site> _siteCollection;
        private readonly IDeviceRepository _deviceRepository;

        public SiteRepository(IMongoClient mongoClient, IConfiguration configuration, IDeviceRepository deviceRepository) :
            base(mongoClient, configuration)
        {
            _siteCollection = _database.GetCollection<Site>(nameof(Site));
            _deviceRepository = deviceRepository;
        }

        public async Task<Site> GetSiteByIdAsync(string siteId)
        {
            return await _siteCollection.Find(s => s.Id == siteId).FirstOrDefaultAsync();
        }

        public async Task<List<Site>> GetAllSitesAsync()
        {
            return await _siteCollection.Find(s => true).ToListAsync();
        }

        public async Task<bool> CreateSiteAsync(Site site)
        {
            await _siteCollection.InsertOneAsync(site);
            return true;
        }

        public async Task<bool> UpdateSiteAsync(string siteId, Site updatedSite)
        {
            var result = await _siteCollection.ReplaceOneAsync(s => s.Id == siteId, updatedSite);
            return result.MatchedCount > 0;
        }

        public async Task<bool> DeleteSiteAsync(string siteId)
        {
            var result = await _siteCollection.DeleteOneAsync(s => s.Id == siteId);
            return result.DeletedCount > 0;
        }

        public async Task<bool> AddAreaToSiteAsync(string siteId, Area area)
        {
            var site = await _siteCollection.Find(s => s.Id == siteId).FirstOrDefaultAsync();
            if (site == null) return false;

            // Ajouter l'Area à Site
            site.Areas.Add(area);
            await _siteCollection.ReplaceOneAsync(s => s.Id == siteId, site);
            return true;
        }

        public async Task<bool> RemoveAreaFromSiteAsync(string siteId, string areaId)
        {
            var site = await _siteCollection.Find(s => s.Id == siteId).FirstOrDefaultAsync();
            if (site == null) return false;

            var area = site.Areas.FirstOrDefault(a => a.Id == areaId);
            if (area == null) return false;

            site.Areas.Remove(area);
            await _siteCollection.ReplaceOneAsync(s => s.Id == siteId, site);
            return true;
        }

        public async Task<bool> AddModuleToAreaAsync(string siteId, string areaId, Module module)
        {
            var site = await _siteCollection.Find(s => s.Id == siteId).FirstOrDefaultAsync();
            if (site == null) return false;

            var area = site.Areas.FirstOrDefault(a => a.Id == areaId);
            if (area == null) return false;

            area.Modules.Add(module);
            await _siteCollection.ReplaceOneAsync(s => s.Id == siteId, site);
            return true;
        }

        public async Task<bool> RemoveModuleFromAreaAsync(string siteId, string areaId, string moduleId)
        {
            var site = await _siteCollection.Find(s => s.Id == siteId).FirstOrDefaultAsync();
            if (site == null) return false;

            var area = site.Areas.FirstOrDefault(a => a.Id == areaId);
            if (area == null) return false;

            var module = area.Modules.FirstOrDefault(m => m.Id == moduleId);
            if (module == null) return false;

            area.Modules.Remove(module);
            await _siteCollection.ReplaceOneAsync(s => s.Id == siteId, site);
            return true;
        }

        public async Task<bool> AddDeviceToSiteAsync(string siteId, string deviceId)
        {
            var site = await _siteCollection.Find(s => s.Id == siteId).FirstOrDefaultAsync();
            if (site == null) return false;

            if (!site.DeviceIds.Contains(deviceId))
            {
                site.DeviceIds.Add(deviceId);
            }

            await _siteCollection.ReplaceOneAsync(s => s.Id == siteId, site);
            return true;
        }

        public async Task<bool> RemoveDeviceFromSiteAsync(string siteId, string deviceId)
        {
            var site = await _siteCollection.Find(s => s.Id == siteId).FirstOrDefaultAsync();
            if (site == null) return false;

            site.DeviceIds.Remove(deviceId);

            await _siteCollection.ReplaceOneAsync(s => s.Id == siteId, site);
            return true;
        }

        public async Task<bool> AddDeviceToAreaAsync(string siteId, string areaId, string deviceId)
        {
            var site = await _siteCollection.Find(s => s.Id == siteId).FirstOrDefaultAsync();
            if (site == null) return false;

            var area = site.Areas.FirstOrDefault(a => a.Id == areaId);
            if (area == null) return false;

            if (!area.DeviceIds.Contains(deviceId))
            {
                area.DeviceIds.Add(deviceId);
            }

            await _siteCollection.ReplaceOneAsync(s => s.Id == siteId, site);
            return true;
        }

        public async Task<bool> RemoveDeviceFromAreaAsync(string siteId, string areaId, string deviceId)
        {
            var site = await _siteCollection.Find(s => s.Id == siteId).FirstOrDefaultAsync();
            if (site == null) return false;

            var area = site.Areas.FirstOrDefault(a => a.Id == areaId);
            if (area == null) return false;

            area.DeviceIds.Remove(deviceId);

            await _siteCollection.ReplaceOneAsync(s => s.Id == siteId, site);
            return true;
        }

        public async Task<bool> AddDeviceToModuleAsync(string siteId, string areaId, string moduleId, string deviceId)
        {
            var site = await _siteCollection.Find(s => s.Id == siteId).FirstOrDefaultAsync();
            if (site == null) return false;

            var area = site.Areas.FirstOrDefault(a => a.Id == areaId);
            if (area == null) return false;

            var module = area.Modules.FirstOrDefault(m => m.Id == moduleId);
            if (module == null) return false;

            if (!module.DeviceIds.Contains(deviceId))
            {
                module.DeviceIds.Add(deviceId);
            }

            await _siteCollection.ReplaceOneAsync(s => s.Id == siteId, site);
            return true;
        }

        public async Task<bool> RemoveDeviceFromModuleAsync(string siteId, string areaId, string moduleId, string deviceId)
        {
            var site = await _siteCollection.Find(s => s.Id == siteId).FirstOrDefaultAsync();
            if (site == null) return false;

            var area = site.Areas.FirstOrDefault(a => a.Id == areaId);
            if (area == null) return false;

            var module = area.Modules.FirstOrDefault(m => m.Id == moduleId);
            if (module == null) return false;

            module.DeviceIds.Remove(deviceId);

            await _siteCollection.ReplaceOneAsync(s => s.Id == siteId, site);
            return true;
        }

        public async Task<List<Device>> GetDevicesForSiteAsync(string siteId)
        {
            return await _deviceRepository.GetDevicesBySiteIdAsync(siteId);
        }

        public async Task<List<Device>> GetDevicesForAreaAsync(string siteId, string areaId)
        {
            return await _deviceRepository.GetDevicesByAreaIdAsync(areaId);
        }
        
        public async Task<List<Device>> GetDevicesForModuleAsync(string siteId, string areaId, string moduleId)
        {
            return await _deviceRepository.GetDevicesByModuleIdAsync(moduleId);
        }
    }
}
