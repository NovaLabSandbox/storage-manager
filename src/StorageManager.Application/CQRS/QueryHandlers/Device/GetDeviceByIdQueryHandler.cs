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
    public class GetDeviceByIdQueryHandler(IDeviceRepository _deviceRepository, IMapper _mapper, ICacheService _cacheService)
        : IRequestHandler<GetDeviceByIdQuery, OneOf<DeviceResponse, NotFoundResult, ForbiddenResult, BusinessErrorResult>>

    {
        public async Task<OneOf<DeviceResponse, NotFoundResult, ForbiddenResult, BusinessErrorResult>> Handle(GetDeviceByIdQuery request, CancellationToken cancellationToken)
        {
            var device = await _deviceRepository.GetDeviceByIdAsync(request.DeviceId);
            if (device == null) return new NotFoundResult();
            return _mapper.Map<DeviceResponse>(device);
        }
    }
}
