using AutoMapper;

using MediatR;

using OneOf;

using StorageManager.Application.CQRS.Queries.Device;
using StorageManager.Application.Interfaces;
using StorageManager.Client.Contracts;
using StorageManager.Core.Results;
using StorageManager.Infrastructure.Interfaces;

namespace StorageManager.Application.CQRS.QueryHandlers.Device
{
    public class GetAllDevicesQueryHandler(IDeviceRepository _deviceRepository, IMapper _mapper, ICacheService _cacheService)
        : IRequestHandler<GetAllDevicesQuery, OneOf<List<DeviceResponse>, NotFoundResult, ForbiddenResult, BusinessErrorResult>>
    {
        public async Task<OneOf<List<DeviceResponse>, NotFoundResult, ForbiddenResult, BusinessErrorResult>> Handle(GetAllDevicesQuery request, CancellationToken cancellationToken)
        {
            var devices = await _deviceRepository.GetAllDevices();
            if (devices == null || !devices.Any())
            {
                return new List<DeviceResponse>();
            }

            var devicesResponse = devices.Select(s => _mapper.Map<DeviceResponse>(s)).ToList();

            return devicesResponse;
        }
    }
}
