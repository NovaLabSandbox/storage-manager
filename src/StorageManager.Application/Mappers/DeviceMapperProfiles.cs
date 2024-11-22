using AutoMapper;

using StorageManager.Client.Contracts;

namespace StorageManager.Application.Mappers
{
    public class DeviceMapperProfiles : Profile
    {
        public DeviceMapperProfiles()
        {
            CreateMap<Domain.Entities.Device, DeviceResponse>();
            CreateMap<DeviceResponse, Domain.Entities.Device>();
        }
    }
}
