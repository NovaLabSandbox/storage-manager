using MediatR;

using OneOf;

using StorageManager.Client.Contracts;
using StorageManager.Core.Results;

namespace StorageManager.Application.CQRS.Commands.Device
{
    public class DeleteDeviceCommand : IRequest<OneOf<bool, NotFoundResult, ForbiddenResult, BusinessErrorResult>>
    {
        public string DeviceId { get; }

        public DeleteDeviceCommand(string deviceId)
        {
            DeviceId = deviceId;
        }
    }
}
