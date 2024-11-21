using StorageManager.Domain.Entities;

namespace StorageManager.Infrastructure.Interfaces
{
    public interface IDeviceRepository
    {
        Task<Device> GetDeviceByIdAsync(string deviceId);
        Task<bool> CreateDeviceAsync(Device device);
        Task<bool> UpdateDeviceAsync(string deviceId, Device updatedDevice);
        Task<bool> DeleteDeviceAsync(string deviceId);
        Task<List<Device>> GetDevicesBySiteIdAsync(string siteId);
        Task<List<Device>> GetDevicesByAreaIdAsync(string areaId);
        Task<List<Device>> GetDevicesByModuleIdAsync(string moduleId);
    }
}
