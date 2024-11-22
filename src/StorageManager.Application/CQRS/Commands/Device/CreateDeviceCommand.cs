using MediatR;

using OneOf;

using StorageManager.Client.Contracts;
using StorageManager.Core.Results;
using StorageManager.Domain.Entities;

namespace StorageManager.Application.CQRS.Commands.Device
{
    public class CreateDeviceCommand
        : IRequest<OneOf<CreatedResult<DeviceResponse>, NotFoundResult, ForbiddenResult, BusinessErrorResult>>
    {
        public CreateDeviceRequest Payload { get; }

        public CreateDeviceCommand(CreateDeviceRequest payload)
        {
            Payload = payload;
        }
    }
}
