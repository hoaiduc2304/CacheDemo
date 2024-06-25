
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Demo.Module.Notification.Models;
using Demo.Module.Notification.Enums;
using DNH.Infastructure.Cache;
using System.Text.Json.Serialization;

namespace Demo.Module.Notification.Services
{
    public interface INotificationService
    {
        Task<TemplateResponse> GetTemplate(string TemplateCode);
    }
    public class NotificationService : INotificationService
    {
        IStaticCacheManager _cacheManager;
        const string getTemplate = "template.{0}";
        public NotificationService(IStaticCacheManager cacheManager)
        {
            _cacheManager = cacheManager;
        }

       
        public async Task<TemplateResponse> GetTemplate(string TemplateCode)
        {
            string cacheKey = string.Format(getTemplate, TemplateCode);
            var data =   _cacheManager.Get(cacheKey,   () =>  getTemplateCode(TemplateCode),15);
            return await  _cacheManager.GetAsync(cacheKey, async () =>  await getTemplateCodeAsync(TemplateCode),15);
            
        }

        private  TemplateResponse getTemplateCode(string TemplateCode)
        {
            return new TemplateResponse()
            {
                data = new GenerateTemplateContent()
                {
                    content = "It is a tempalte "
                }
            };
        }

        private async Task<TemplateResponse> getTemplateCodeAsync(string TemplateCode)
        {
            return new TemplateResponse()
            {
                data = new GenerateTemplateContent()
                {
                    content = "It is a tempalte "
                }
            };
        }
    }
}
