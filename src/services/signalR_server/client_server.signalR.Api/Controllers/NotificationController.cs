using client_server.signalR.Application.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace client_server.signalR.Api.Controllers
{
    [ApiController]
    [Route("api/v1/notifications")]
    public class NotificationController : ControllerBase
    {
        private readonly IAppNotificationService _notification;
        public NotificationController(IAppNotificationService notification)
        {
            _notification = notification;
        }

        [HttpPost("publish")]
        public async Task<IActionResult> Publish(string message)
        {
            await _notification.Publish(message);

            return Ok();
        }

    }
}
