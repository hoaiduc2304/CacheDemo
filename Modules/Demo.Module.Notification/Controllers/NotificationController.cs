using Demo.Module.Notification.Services;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo.Module.Notification.Controllers
{
    public class NotificationController : BaseApiController
    {
        INotificationService _notificationService;
        public NotificationController(INotificationService notificationService) {
            _notificationService = notificationService;
        }

        [HttpGet("template/{templateCode}")]
        public  async Task<IActionResult> GetTemplate(string templateCode)
        {
           var result = await  _notificationService.GetTemplate(templateCode);
            return Ok(result);
        }

       
    }
}
