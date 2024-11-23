using Microsoft.Extensions.Configuration;

using MongoDB.Driver;

using StorageManager.Domain.Entities;
using StorageManager.Infrastructure.Core;
using StorageManager.Infrastructure.Interfaces;

namespace StorageManager.Infrastructure.Repositories
{
    public class DeviceRepository : CoreRepository, IDeviceRepository
    {
        private readonly IMongoCollection<Device> _deviceCollection;

        public DeviceRepository(IMongoClient mongoClient, IConfiguration configuration) : base(mongoClient, configuration)
        {
            _deviceCollection = _database.GetCollection<Device>(nameof(Device));
        }

        public async Task<Device> GetDeviceByIdAsync(string deviceId)
        {
            return await _deviceCollection.Find(d => d.Id == deviceId).FirstOrDefaultAsync();
        }

        public async Task<bool> CreateDeviceAsync(Device device)
        {
            await _deviceCollection.InsertOneAsync(device);
            return true;
        }

        public async Task<bool> UpdateDeviceAsync(string deviceId, Device updatedDevice)
        {
            var result = await _deviceCollection.ReplaceOneAsync(d => d.Id == deviceId, updatedDevice);
            return result.MatchedCount > 0;
        }

        public async Task<bool> DeleteDeviceAsync(string deviceId)
        {
            var result = await _deviceCollection.DeleteOneAsync(d => d.Id == deviceId);
            return result.DeletedCount > 0;
        }

        public async Task<List<Device>> GetDevicesBySiteIdAsync(string siteId)
        {
            return await _deviceCollection.Find(d => d.SiteIds.Contains(siteId)).ToListAsync();
        }

        public async Task<List<Device>> GetDevicesByAreaIdAsync(string areaId)
        {
            return await _deviceCollection.Find(d => d.AreaIds.Contains(areaId)).ToListAsync();
        }

        public async Task<List<Device>> GetDevicesByModuleIdAsync(string moduleId)
        {
            return await _deviceCollection.Find(d => d.ModuleIds.Contains(moduleId)).ToListAsync();
        }

        public Task<List<Device>> GetAllDevices()
        {
            throw new NotImplementedException();
        }
    }
}
