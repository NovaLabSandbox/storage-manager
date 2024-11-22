using AutoMapper;

using MediatR;

using OneOf;

using StorageManager.Application.CQRS.Commands.Device;
using StorageManager.Application.Interfaces;
using StorageManager.Core.Results;
using StorageManager.Infrastructure.Interfaces;

namespace StorageManager.Application.CQRS.CommandHandlers.Device
{
    public class DeleteDeviceCommandHandler(IDeviceRepository _deviceRepository, IMapper _mapper, ICacheService _cacheService) 
        : IRequestHandler<DeleteDeviceCommand, OneOf<bool, NotFoundResult, ForbiddenResult, BusinessErrorResult>>
    {
        public async Task<OneOf<bool, NotFoundResult, ForbiddenResult, BusinessErrorResult>> Handle(DeleteDeviceCommand request, CancellationToken cancellationToken)
        {
            var device = await _deviceRepository.GetDeviceByIdAsync(request.DeviceId);
            if (device == null)
                return new NotFoundResult();

            var deleted = await _deviceRepository.DeleteDeviceAsync(request.DeviceId);
            if (deleted)
            {
                return true;
            }

            return new BusinessErrorResult("Failed to delete the device.");
        }
    }
}
