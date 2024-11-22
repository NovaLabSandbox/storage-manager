using AutoMapper;

using MediatR;

using OneOf;

using StorageManager.Application.CQRS.Commands.Device;
using StorageManager.Client.Contracts;
using StorageManager.Core.Results;
using StorageManager.Infrastructure.Interfaces;

namespace StorageManager.Application.CQRS.CommandHandlers.Device
{
    public class CreateDeviceCommandHandler(IDeviceRepository _deviceRepository, IMapper _mapper) : IRequestHandler<CreateDeviceCommand, OneOf<CreatedResult<DeviceResponse>, NotFoundResult, ForbiddenResult, BusinessErrorResult>>
    {
        public async Task<OneOf<CreatedResult<DeviceResponse>, NotFoundResult, ForbiddenResult, BusinessErrorResult>> Handle(CreateDeviceCommand request, CancellationToken cancellationToken)
        {
            var device = new Domain.Entities.Device
            {
                Name = request.Payload.Name,
                Type = request.Payload.Type,
                Description = request.Payload.Description
            };

            await _deviceRepository.CreateDeviceAsync(device);
            return new CreatedResult<DeviceResponse>()
            {
                Data = _mapper.Map<DeviceResponse>(device),
                EntityPath = nameof(DeviceResponse),
                Id = device.Id
            };
        }
    }
}
