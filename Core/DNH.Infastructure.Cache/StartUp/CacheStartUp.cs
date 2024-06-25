
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;
using Microsoft.AspNetCore.Builder;
using DNH.Infastructure.Cache.Configuration;


namespace DNH.Infastructure.Cache.StartUp
{
    public static class CacheStartUp 
    {

        public static IServiceCollection RegisterCache(this IServiceCollection services, IConfiguration config)
        {
            // needed to store rate limit counters and ip rules
            //cache manager
            CacheConfig setting = new CacheConfig();
            config.Bind("Redis", setting);
            services.AddSingleton(setting);
            services.AddTransient<ICacheManager, PerRequestCacheManager>();
            //static cache manager
            if (setting.RedisCachingEnabled)
            {
                services.AddSingleton<ILocker, RedisConnectionWrapper>();
                services.AddSingleton<IRedisConnectionWrapper, RedisConnectionWrapper>();
                services.AddTransient<IStaticCacheManager, RedisCacheManager>();
            }
            else
            {
                services.AddSingleton<ILocker, MemoryCacheManager>();
                services.AddSingleton<IStaticCacheManager, MemoryCacheManager>();
            }
            return services;
        }
      
    }
}
