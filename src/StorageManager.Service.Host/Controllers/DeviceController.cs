using MediatR;

using Microsoft.AspNetCore.Mvc;

using StorageManager.Application.CQRS.Commands.Device;
using StorageManager.Application.CQRS.Queries.Device;
using StorageManager.Client.Contracts;

namespace StorageManager.Service.Host.Controllers
{
    [ApiController]
    public class DeviceController(IMediator _mediator) : DeviceControllerBase
    {
        public override async Task<ActionResult<DeviceResponse>> CreateDevice([FromBody] CreateDeviceRequest body)
            => Do(await _mediator.Send(new CreateDeviceCommand(body)));

        public override async Task<IActionResult> DeleteDevice(string deviceId)
            => Do(await _mediator.Send(new DeleteDeviceCommand(deviceId)));


        public override async Task<ActionResult<ICollection<DeviceResponse>>> GetAllDevices()
            => Do(await _mediator.Send(new GetAllDevicesQuery()));

        public override async Task<ActionResult<DeviceResponse>> GetDeviceById(string deviceId)
            => Do(await _mediator.Send(new GetDeviceByIdQuery(deviceId)));

        public override async Task<ActionResult<DeviceResponse>> UpdateDevice(string deviceId, [FromBody] UpdateDeviceRequest body)
            => Do(await _mediator.Send(new UpdateDeviceCommand(deviceId, body)));

    }
}
