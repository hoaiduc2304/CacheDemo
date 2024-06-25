using Demo.Module.Notification.Services;


using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Newtonsoft.Json.Linq;
using Plugin.Abstraction.Plugins;
using Plugin.Abstraction.Settings;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo.Module.Notification
{
    internal class NotificationPlugin : IPlugin
    {
        public string Id => "";
        private string _tokenType = "Bearer";
        public void RegisterDI(IServiceCollection services, IConfiguration config)
        {
            services.AddScoped<INotificationService, NotificationService>();
        }
    }
}
