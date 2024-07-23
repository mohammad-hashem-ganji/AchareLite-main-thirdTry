using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Infra.Cache.InMemoryCache
{
    public interface IInMemoryCacheService
    {
        void SetSliding<T>(string key, T value, int expirationTime);
        void Set<T>(string key, T value, int expirationTime);
        T Get<T>(string key);
    }
}
