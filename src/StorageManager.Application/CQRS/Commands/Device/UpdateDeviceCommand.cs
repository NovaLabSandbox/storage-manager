using MediatR;

using OneOf;

using StorageManager.Client.Contracts;
using StorageManager.Core.Results;

namespace StorageManager.Application.CQRS.Commands.Device
{
    public class UpdateDeviceCommand : IRequest<OneOf<DeviceResponse, NotFoundResult, ForbiddenResult, BusinessErrorResult>>
    {
        public string DeviceId { get; }

        public UpdateDeviceRequest Payload { get; }

        public UpdateDeviceCommand(string deviceId, UpdateDeviceRequest payload)
        {
            DeviceId = deviceId;
            Payload = payload;
        }
    }
}
