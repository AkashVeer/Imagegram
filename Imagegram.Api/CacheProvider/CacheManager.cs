using Microsoft.Extensions.Caching.Memory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Imagegram.Api.CacheProvider
{
    public static class CacheManager
    {
        public static void RemoveItemIfExists(this IMemoryCache memoryCache, string key)
        {
            if (memoryCache.TryGetValue(key, out _))
            {
                memoryCache.Remove(CacheKey.POSTSCACHEKEY);
            }
        }

        public static void AddItemIfNotExists(this IMemoryCache memoryCache, string key, object item)
        {
            if (!memoryCache.TryGetValue(key, out _))
            {
                memoryCache.Set(key, item);
            }
        }

        public static object GetItem(this IMemoryCache memoryCache, string key)
        {
            return memoryCache.Get(key);
        }
    }
}
