using MediatR;

using OneOf;

using StorageManager.Client.Contracts;
using StorageManager.Core.Results;

namespace StorageManager.Application.CQRS.Queries.Device
{
    public class GetDeviceByIdQuery : IRequest<OneOf<DeviceResponse, NotFoundResult, ForbiddenResult, BusinessErrorResult>>
    {
        public string DeviceId { get;  }

        public GetDeviceByIdQuery(string deviceId)
        {
            DeviceId = deviceId;
        }
    }
}
