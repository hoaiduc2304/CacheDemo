using System;
using System.Collections.Generic;
using System.Text;

namespace DNH.Infastructure.Cache.Configuration
{
    public static partial class DNHCachingDefaults
    {
        public static int CacheTime => 60;

        /// <summary>
        /// Gets the key used to store the protection key list to Redis (used with the PersistDataProtectionKeysToRedis option enabled)
        /// </summary>
        public static string RedisDataProtectionKey => "DNH.DataProtectionKeys";
    }
}
