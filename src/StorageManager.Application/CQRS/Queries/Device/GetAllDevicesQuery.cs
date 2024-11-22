using MediatR;

using OneOf;

using StorageManager.Client.Contracts;
using StorageManager.Core.Results;

namespace StorageManager.Application.CQRS.Queries.Device
{
    public class GetAllDevicesQuery : IRequest<OneOf<List<DeviceResponse>, NotFoundResult, ForbiddenResult, BusinessErrorResult>>
    {
    }
}
