using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DNH.Infastructure.Cache.Configuration
{
    public class CacheConfig
    {
        public bool RedisCachingEnabled { get; set; }
        public string RedisCachingConnectionString { get; set; }
        public bool PersistDataProtectionKeysToRedis { get; set; }
    }
}
