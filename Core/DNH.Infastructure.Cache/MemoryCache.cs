using System;
using System.Collections.Generic;
using System.Text;

namespace DNH.Infastructure.Cache
{
    public class MemoryCache
    {
        private static Dictionary<string, object> _cache = new Dictionary<string, object>();

        public MemoryCache()
        {
        }

        public static T Get<T>(string key) where T : class
        {
            if (_cache.ContainsKey(key))
                return _cache[key] as T;

            return null;
        }

        public static bool Remove(string key)
        {
            _cache.Remove(key);
            return true;
        }

        public static void Set<T>(string key, T value) where T : class
        {
            if (_cache.ContainsKey(key))
                _cache[key] = value;
            else
                _cache.Add(key, value);
        }
        public static bool AllowCache
        {
            get
            {
                return false;
            }
        }
    }
}
