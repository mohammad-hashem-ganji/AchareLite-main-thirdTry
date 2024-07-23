using Microsoft.Extensions.Caching.Memory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Infra.Cache.InMemoryCache
{
    public class InMemoryCacheService : IInMemoryCacheService
    {
        private readonly IMemoryCache _memoryCache;

        public InMemoryCacheService(IMemoryCache memoryCache)
        {
            _memoryCache = memoryCache;
        }

        public void SetSliding<T>(string key, T value, int expirationTime)
        {
            var options = new MemoryCacheEntryOptions();
            options.SlidingExpiration = TimeSpan.FromSeconds(expirationTime);
            _memoryCache.Set(key, value, options);
        }

        public void Set<T>(string key, T value, int expirationTime)
        {
            var expireTime = TimeSpan.FromSeconds(expirationTime);
            _memoryCache.Set(key, value, expireTime);
        }

        public T Get<T>(string key)
        {
            return _memoryCache.Get<T>(key);
        }
    }
}
